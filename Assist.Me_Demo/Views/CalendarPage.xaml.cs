using Microsoft.Maui;

namespace Assist.Me_Demo.Views;

public partial class CalendarPage : ContentPage
{
    public static CalendarPage Instance { get; private set; }
    private static bool isChecked = false;
	private static Border temp;
	private static Button tempButton;

    public CalendarPage()
	{
		InitializeComponent();
		Instance = this;
	}

	public async static void moveCalendarUp()
	{
		Instance.EntireCalendar.TranslateTo(0, -143, 300, Easing.CubicIn);
		await Task.Delay(500);
		Instance.DisplaySchedule.FadeTo(1, 200, Easing.Linear);

	}

	public void CloseCalendar(System.Object sender, System.EventArgs e)
	{
		Navigation.PopAsync();
	}

	public async static void moveCalendarDown()
	{
        Instance.DisplaySchedule.FadeTo(0, 200, Easing.Linear);
        await Task.Delay(300);
        Instance.EntireCalendar.TranslateTo(0, 0, 300, Easing.CubicIn);
    }

	public static void Day1Clicked(System.Object sender, System.EventArgs e)
	{
        Button button = sender as Button;
        Border border = (Border)button.Parent;

        if (isChecked && border.BackgroundColor == Microsoft.Maui.Graphics.Colors.Transparent)
		{
			temp.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent;
			tempButton.TextColor = Microsoft.Maui.Graphics.Colors.White;
            border.BackgroundColor = Microsoft.Maui.Graphics.Color.FromRgb(178, 164, 189);
			button.TextColor = Microsoft.Maui.Graphics.Color.FromRgb(18, 17, 18);
            Instance.ScheduleContent.Text = "Nothing scheduled for " + Instance.MonthName.Text + " " + button.Text;
            temp = border;
			tempButton = button;
		}
		else if (isChecked && border.BackgroundColor != Microsoft.Maui.Graphics.Colors.Transparent)
		{
            border.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent;
            button.TextColor = Microsoft.Maui.Graphics.Colors.White;
			isChecked = false;
			moveCalendarDown();
        }
		else
		{
			isChecked = true;
			temp = border;
			tempButton = button;
			moveCalendarUp();
			Instance.ScheduleContent.Text = "Nothing scheduled for " + Instance.MonthName.Text + " " + button.Text;
            border.BackgroundColor = Microsoft.Maui.Graphics.Color.FromRgb(178, 164, 189);
            button.TextColor = Microsoft.Maui.Graphics.Color.FromRgb(18, 17, 18);
        }

    }
}
