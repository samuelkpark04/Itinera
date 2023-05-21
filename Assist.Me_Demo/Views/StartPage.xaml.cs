//using Microsoft.UI.Xaml;

using System.Security.Cryptography.X509Certificates;

namespace Assist.Me_Demo.Views;

public partial class StartPage : ContentPage
{
	private bool gettingUserPrompt = false;

    public static StartPage Instance { get; private set; }
    public StartPage()
	{
		InitializeComponent();
		Instance = this;
		//loadCalender();
	}

	public static void leftSwipe(System.Object sender, System.EventArgs e)
	{
		Console.WriteLine("Calendar Opened");
        loadCalender();
	}
    public static void rightSwipe(System.Object sender, System.EventArgs e)
    {
        Console.WriteLine("Calendar Opened");
        loadTest();
    }
    private static async void loadCalender()
	{
		await Instance.Navigation.PushAsync(new CalendarPage());
	}
    private static async void loadTest()
    {
        await Instance.Navigation.PushAsync(new NewPage1());
    }

    async void AssistClicked(System.Object sender, System.EventArgs e)
	{
        Console.WriteLine("Assist Button Clicked confirm");
        if (!gettingUserPrompt)
		{
            Button temp = (Button)sender;
			await temp.FadeTo(0, 200);
			await Task.Delay(200);
			await FullPage.TranslateTo(0, -300, 300, Easing.CubicIn);
			await Task.Delay(500);
			await user_in.FadeTo(1, 200);
            await SubmitButton.FadeTo(1, 200);
			await CancelButton.FadeTo(1, 200);
			gettingUserPrompt = true;
		}
	}
    async void returnHome(System.Object sender, System.EventArgs e)
    {
		if (gettingUserPrompt)
		{
            Console.WriteLine("Cancel Button Clicked confirm");
            Button temp = (Button)sender;
            await temp.FadeTo(0, 200);
            await SubmitButton.FadeTo(0, 200);
			await user_in.FadeTo(0, 200);
            await Task.Delay(200);
            await FullPage.TranslateTo(0, 200, 350, Easing.CubicIn);
            await Task.Delay(200);
            await AssistButton.FadeTo(1, 200);
			gettingUserPrompt = false;
        }
        
    }

    async void SubmitClicked(System.Object sender, System.EventArgs e)
	{
		if (gettingUserPrompt)
		{
            Console.WriteLine("Submit Button Clicked confirm");
            Button temp = (Button)sender;
			await user_in.FadeTo(0, 200, Easing.CubicIn);
			await temp.FadeTo(0, 200, Easing.CubicIn);
			ChatBot.Text = "";
			Intro.Text = ". . .";
			await Task.Delay(400);
			await FullPage.TranslateTo(0, 200,350, Easing.CubicIn);
			await AssistButton.FadeTo(1, 200);
			string temp_user_in = Instance.user_in.Text;
			Instance.user_in.Text = "";
			ProcessInput.process(temp_user_in);
			gettingUserPrompt = false;
		}
    }
	public static async void resetChat()
	{
		Instance.Intro.Text = "Good Morning";
        Instance.ChatBot.Text = "What can I help you with today?";
    }

	public static async void updateChat(string up)
	{
		Instance.Intro.Text = "";
		Instance.ChatBot.Text = up;
    }
	public static async void askAgain()
	{
        Instance.ChatBot.Text = "Anything else I can help with?";
    }

}
