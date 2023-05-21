using System;
using System.Text.RegularExpressions;

namespace Assist.Me_Demo
{
	public static class ProcessInput
	{
		public static void process(string to_command)
		{
			Console.WriteLine("called");
            Views.StartPage.updateChat("...");
            GPTEngine.classify(to_command);


			/*

			if (to_command.Contains("What is my schedule") || to_command.Contains("explain"))
			{
				GPTEngine.explain();
				
				Console.WriteLine("explained ---");
			}
            else if (to_command.Contains("I have") || to_command.Contains("schedule"))
            {
                GPTEngine.extractDate(cleanText(to_command));
                MainPage.updateChat("Noted");
                Console.WriteLine("Noteddddddd");
            }
            else
			{
                GPTEngine.extractDate(cleanText(to_command));
            }
			*/
		}

		public static string cleanGPTOutput(string output)
		{
			Console.WriteLine(output.IndexOf("output:") + 7);
			return output.Substring(output.IndexOf("output:") + 7);
		}
	}
}

