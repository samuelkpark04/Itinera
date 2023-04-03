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

	public static void OpenCalendar(System.Object sender, System.EventArgs e)
	{
		loadCalender();
	}
	private static async void loadCalender()
	{
		await Instance.Navigation.PushAsync(new CalendarPage());
	}

	async void AssistClicked(System.Object sender, System.EventArgs e)
	{

		if (!gettingUserPrompt)
		{
            Button temp = (Button)sender;
			await temp.FadeTo(0, 200);
			await Task.Delay(200);
			await FullPage.TranslateTo(0, -300, 300, Easing.CubicIn);
			await Task.Delay(500);
			await user_in.FadeTo(1, 200);
			await SubmitButton.FadeTo(1, 200);
			gettingUserPrompt = true;
		}
	}

	async void SubmitClicked(System.Object sender, System.EventArgs e)
	{
		if (gettingUserPrompt)
		{
			
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


	public static void updateChat(string up)
	{
		Instance.Intro.Text = "";
		Instance.ChatBot.Text = up;
	}

}
