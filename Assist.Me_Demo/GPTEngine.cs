using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;

using System;
using System.Text.RegularExpressions;

namespace Assist.Me_Demo
{
	public static class GPTEngine
	{
		private static string api_key = "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";
        private static OpenAIClient api = new OpenAIClient(api_key);

		public static List<string> output_buffer = new List<string>();

		private static void output(string arg)
		{
			Console.WriteLine("GPTEngine DEBUG: " + arg);
		}


        public static async void classify(string user_in)
        {
			output("Classifying...");
            var chatPrompts = new List<ChatPrompt>
            {
                new ChatPrompt("system", "You are an assistant trying to classify the given phrase into categories"),
                new ChatPrompt("user", "Given a phrase, can you output 1 if it is asking to schedule something, output 2 if it is talking about a future event, output 3 if it is asking about their schedule, and output 4 for everything else? Here is the phrase: " + user_in)
            };

            var chatRequest = new ChatRequest(chatPrompts, Model.GPT3_5_Turbo);
            var result = await api.ChatEndpoint.GetCompletionAsync(chatRequest);

			output("Finished Classifying");

            string analyze = result.FirstChoice;
            string resultString = Regex.Match(analyze, @"\d+").Value;

			int classification = Int32.Parse(resultString);

			output("Result of classification conversion: " + classification);

			switch (classification)
			{
				case 1:
					output("Updating chat - 1");
                    Views.StartPage.updateChat("Of course!");
					extractDate(user_in);
                    
                    break;
				case 2:
                    output("Updating chat - 2");
                    Views.StartPage.updateChat("Noted!");
					extractDate(user_in);
                  
                    break;
				case 3:
					output("Updating chat - 3");
                    Views.StartPage.updateChat("Pulling up schedule...");
					explain();
					break;
				case 4:
                    output("Updating chat - 4");
                    Views.StartPage.updateChat("Sorry this is beyond my pay grade...");
                  
                    break;
			}
        }

        public static async void query(string system_in, string user_in, string original)
		{
			var chatPrompts = new List<ChatPrompt>
			{
				new ChatPrompt("system", system_in),
                new ChatPrompt("user", user_in)
			};

            var chatRequest = new ChatRequest(chatPrompts, Model.GPT3_5_Turbo);
            var result = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
			Console.WriteLine(result.FirstChoice + "FINISHED");

            string analyze = result.FirstChoice;

			string resultString = Regex.Match(analyze, @"\d+").Value;

        }

		public static void push_from_buffer(string rem)
		{
			for (int i = 0; i < output_buffer.Count; i++)
			{
				if (output_buffer[i] == rem)
				{
					output_buffer.RemoveAt(i);
					return;
				}
			}
		}

		public static async void extractDate(string sched)
		{
			output("Extracting dates...");
            var chatPrompts = new List<ChatPrompt>
            {
                new ChatPrompt("system", "You are an assistant that is trying to extract key dates and details to remember from the given phrase"),
                new ChatPrompt("user", "Can you extract any important dates to remember and any relevant details associated with it from this given phrase? Please output in the format of [date:time] : [event name: details associated with event]. If you are not given a concrete time in the format of the month and day, and instead given a time such as \"next Monday\", please deduce the exact date [month:day] from considering the present date. If you are given an ambiguous time frame such as \"Next week\", please deduce an exact date range[month:day:time - month:day:time] from the current date. Here is the current date: " + DateTime.Today + ". Here is the phrase: " + sched)
            };

            var chatRequest = new ChatRequest(chatPrompts, Model.GPT3_5_Turbo);
            var result = await api.ChatEndpoint.GetCompletionAsync(chatRequest);

            output_buffer.Add(result.FirstChoice);
			output("Extracted: " + result.FirstChoice);

			string temp = result.FirstChoice;
			temp = temp.Substring(temp.IndexOf("["));
			output("Adding : " + temp);

			Database.addToSchedule(temp);
			output(Database.history);

        }

		public static async void explain()
		{
			var chatPrompts = new List<ChatPrompt>
			{
				new ChatPrompt("system", "You are an assistant that is trying to explain someone's schedule"),
				new ChatPrompt("user", "Can you explain my given schedule? As well as important considerations I should keep in mind such as being extra mindful that I am more busy on a certain day. Here is my schedule: " + Database.history)
            };

            var chatRequest = new ChatRequest(chatPrompts, Model.GPT3_5_Turbo);
			string temp = "";
            await api.ChatEndpoint.StreamCompletionAsync(chatRequest, result =>
            {
				if (temp.Length > 200)
				{
					temp = "";
				}

				temp += result.FirstChoice;
                Views.StartPage.updateChat(temp);
            });

			Console.WriteLine("GPTEngine DEBUG explain: ");
        }

	}
}

