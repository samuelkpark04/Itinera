using System;
namespace Assist.Me_Demo
{
	public static class Database
	{
		public static string history = "";

		public static void addToSchedule(string GPT_output)
		{
			history += GPT_output + ", ";
		}

		public static void update()
		{
			try
			{

                addToSchedule(ProcessInput.cleanGPTOutput(GPTEngine.output_buffer.Last()));
				Console.WriteLine("Added to schedule");
            }
			catch
			{
				Console.WriteLine("FAILED");
			}
			
		}
	}
}

