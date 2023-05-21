using Microsoft.Maui;
using System;
using System.Reflection;

namespace Assist.Me_Demo.Views;

public partial class CalendarPage : ContentPage
{
    public static CalendarPage Instance { get; private set; }
    private static bool isChecked = false;
	private static Border temp;
	private static Button tempButton;
    private static DateTimeOffset now = DateTimeOffset.Now;
    private static int loadYear = now.Year;

    public CalendarPage()
	{
		InitializeComponent();
		Instance = this;
	}

    private Button getButtonByName(String name) //this method returns a button given the string name of the button
    {
        //since the type of field will always be a button
        //Button temp = this.Day1Content;
        Type type = this.GetType();
        var property = type.GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
        if (property != null)
        {
            Button myButton = (Button)property.GetValue(this);
            return myButton;
        }
        if (property == null) 
        {
            return null;
        }
        return null;

    }
    public static int CalculateDayOfWeek(int day, int month, int year)
    {
        DateTime date = new DateTime(year, month, day);
        int dayOfWeek = (int)date.DayOfWeek;
        return dayOfWeek + 1;
    }
    private bool IsLeapYear(int year)
    {
        if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void ReloadYearLayout(System.Object sender, System.EventArgs e) //reloads the calendar layout with a year as input parameter
    {
        Button button = sender as Button;
        int parameter = (int)button.CommandParameter;
        loadYear = parameter;
        OnAppearing();
    }
    protected override void OnAppearing()
    {
        //calculates the calendar year format using the CalculateDayofWeek method 
        //updates the xaml to reflect the proper layout and commandparameters

        //calculate jan 1st
        int day = now.Day;
        int month = now.Month;
        int year = loadYear;
        int janfirst = CalculateDayOfWeek(1, 1, year);
        switch (janfirst) //go through and instantiate the month of jan given its starting day of the week
        {
            //start keeps track of the button name while day keeps track of the day 
            case 1:
                JanDay1Content.Text = "1";
                JanDay1Content.TextColor = Colors.White;
                JanDay1Content.CommandParameter = "1,1,2023";
                int start1 = 2;
                for (int i = 0; i < 30; i++)
                {
                    String buttonName = "JanDay" + start1 + "Content";
                    Button temp = getButtonByName(buttonName);
                    temp.Text = start1.ToString();
                    temp.TextColor = Colors.White;
                    temp.CommandParameter = "1," + start1 + ",2023";
                    start1++;
                }
                break;
            case 2:
                JanDay2Content.Text = "1";
                JanDay2Content.TextColor = Colors.White;
                JanDay2Content.CommandParameter = "1,1,2023";
                int start2 = 3;
                int day2 = 2;
                for (int i = 0; i < 30; i++)
                {
                    String buttonName = "JanDay" + start2 + "Content";
                    Button temp = getButtonByName(buttonName);
                    temp.Text = day2.ToString();
                    temp.TextColor = Colors.White;
                    temp.CommandParameter = "1," + day2 + ",2023";
                    start2++;
                    day2++;
                }
                break;
            case 3:
                JanDay3Content.Text = "1";
                JanDay3Content.TextColor = Colors.White;
                JanDay3Content.CommandParameter = "1,1,2023";
                int start3 = 4;
                int day3 = 2;
                for (int i = 0; i < 30; i++)
                {
                    String buttonName = "JanDay" + start3 + "Content";
                    Button temp = getButtonByName(buttonName);
                    temp.Text = day3.ToString();
                    temp.TextColor = Colors.White;
                    temp.CommandParameter = "1," + day3 + ",2023";
                    start3++;
                    day3++;
                }
                break;
            case 4:
                JanDay4Content.Text = "1";
                JanDay4Content.TextColor = Colors.White;
                JanDay4Content.CommandParameter = "1,1,2023";
                int start4 = 5;
                int day4 = 2;
                for (int i = 0; i < 30; i++)
                {
                    String buttonName = "JanDay" + start4 + "Content";
                    Button temp = getButtonByName(buttonName);
                    temp.Text = day4.ToString();
                    temp.TextColor = Colors.White;
                    temp.CommandParameter = "1," + day4 + ",2023";
                    start4++;
                    day4++;
                }
                break;
            case 5:
                JanDay5Content.Text = "1";
                JanDay5Content.TextColor = Colors.White;
                JanDay5Content.CommandParameter = "1,1,2023";
                int start5 = 6;
                int day5 = 2;
                for (int i = 0; i < 30; i++)
                {
                    String buttonName = "JanDay" + start5 + "Content";
                    Button temp = getButtonByName(buttonName);
                    temp.Text = day5.ToString();
                    temp.TextColor = Colors.White;
                    temp.CommandParameter = "1," + day5 + ",2023";
                    start5++;
                    day5++;
                }
                break;
            case 6:
                JanDay6Content.Text = "1";
                JanDay6Content.TextColor = Colors.White;
                JanDay6Content.CommandParameter = "1,1,2023";
                int start6 = 7;
                int day6 = 2;
                for (int i = 0; i < 30; i++)
                {
                    String buttonName = "JanDay" + start6 + "Content";
                    Button temp = getButtonByName(buttonName);
                    temp.Text = day6.ToString();
                    temp.TextColor = Colors.White;
                    temp.CommandParameter = "1," + day6 + ",2023";
                    start6++;
                    day6++;
                }
                break;
            case 7:
                JanDay7Content.Text = "1";
                JanDay7Content.TextColor = Colors.White;
                JanDay7Content.CommandParameter = "1,1,2023";
                int start7 = 8;
                int day7 = 2;
                for (int i = 0; i < 30; i++)
                {
                    String buttonName = "JanDay" + start7 + "Content";
                    Button temp = getButtonByName(buttonName);
                    temp.Text = day7.ToString();
                    temp.TextColor = Colors.White;
                    temp.CommandParameter = "1," + day7 + ",2023";
                    start7++;
                    day7++;
                }
                break;
        }
        int febfirst = CalculateDayOfWeek(1, 2, year);
        Console.WriteLine("February 1st:" +  febfirst);
        int DaysInFebruary = 0;
        if (IsLeapYear(year)) DaysInFebruary = 29;
        else DaysInFebruary = 28;
        switch (febfirst) //go through and instantiate the month of jan given its starting day of the week
        {
            case 1:
                FebDay1Content.Text = "1";
                FebDay1Content.TextColor = Colors.White;
                FebDay1Content.CommandParameter = "2,1,2023";
                int start1 = 2;
                for (int i = 0; i < DaysInFebruary-1; i++)
                {
                    String buttonName = "FebDay" + start1 + "Content";
                    Button temp = getButtonByName(buttonName);
                    temp.Text = start1.ToString();
                    temp.TextColor = Colors.White;
                    temp.CommandParameter = "2," + start1 + ",2023";
                    start1++;
                }
                break;
            case 2:
                FebDay2Content.Text = "1";
                FebDay2Content.TextColor = Colors.White;
                FebDay2Content.CommandParameter = "2,1,2023";
                int start2 = 3;
                int day2 = 2;
                for (int i = 0; i < DaysInFebruary - 1; i++)
                {
                    String buttonName = "FebDay" + start2 + "Content";
                    Button temp = getButtonByName(buttonName);
                    temp.Text = day2.ToString();
                    temp.TextColor = Colors.White;
                    temp.CommandParameter = "2," + day2 + ",2023";
                    start2++;
                    day2++;
                }
                break;
            case 3:
                FebDay3Content.Text = "1";
                FebDay3Content.TextColor = Colors.White;
                FebDay3Content.CommandParameter = "2,1,2023";
                int start3 = 4;
                int day3 = 2;
                for (int i = 0; i < DaysInFebruary - 1; i++)
                {
                    String buttonName = "FebDay" + start3 + "Content";
                    Button temp = getButtonByName(buttonName);
                    temp.Text = day3.ToString();
                    temp.TextColor = Colors.White;
                    temp.CommandParameter = "2," + day3 + ",2023";
                    start3++;
                    day3++;
                }
                break;
            case 4:
                FebDay4Content.Text = "1";
                FebDay4Content.TextColor = Colors.White;
                FebDay4Content.CommandParameter = "2,1,2023";
                int start4 = 5;
                int day4 = 2;
                for (int i = 0; i < DaysInFebruary - 1; i++)
                {
                    String buttonName = "FebDay" + start4 + "Content";
                    Button temp = getButtonByName(buttonName);
                    temp.Text = day4.ToString();
                    temp.TextColor = Colors.White;
                    temp.CommandParameter = "2," + day4 + ",2023";
                    start4++;
                    day4++;
                }
                break;
            case 5:
                FebDay5Content.Text = "1";
                FebDay5Content.TextColor = Colors.White;
                FebDay5Content.CommandParameter = "2,1,2023";
                int start5 = 6;
                int day5 = 2;
                for (int i = 0; i < DaysInFebruary - 1; i++)
                {
                    String buttonName = "FebDay" + start5 + "Content";
                    Button temp = getButtonByName(buttonName);
                    temp.Text = day5.ToString();
                    temp.TextColor = Colors.White;
                    temp.CommandParameter = "2," + day5 + ",2023";
                    start5++;
                    day5++;
                }
                break;
            case 6:
                FebDay6Content.Text = "1";
                FebDay6Content.TextColor = Colors.White;
                FebDay6Content.CommandParameter = "2,1,2023";
                int start6 = 7;
                int day6 = 2;
                for (int i = 0; i < DaysInFebruary - 1; i++)
                {
                    String buttonName = "FebDay" + start6 + "Content";
                    Button temp = getButtonByName(buttonName);
                    temp.Text = day6.ToString();
                    temp.TextColor = Colors.White;
                    temp.CommandParameter = "2," + day6 + ",2023";
                    start6++;
                    day6++;
                }
                break;
            case 7:
                FebDay7Content.Text = "1";
                FebDay7Content.TextColor = Colors.White;
                FebDay7Content.CommandParameter = "2,1,2023";
                int start7 = 8;
                int day7 = 2;
                for (int i = 0; i < DaysInFebruary - 1; i++)
                {
                    String buttonName = "FebDay" + start7 + "Content";
                    Button temp = getButtonByName(buttonName);
                    temp.Text = day7.ToString();
                    temp.TextColor = Colors.White;
                    temp.CommandParameter = "2," + day7 + ",2023";
                    start7++;
                    day7++;
                }
                break;
        }

    }

    public void rightSwipe(System.Object sender, System.EventArgs e)
	{
		Views.StartPage.resetChat();
		Navigation.PopAsync();
	}

	//public async static void moveCalendarDown()
	//{
 //       Instance.DisplaySchedule.FadeTo(0, 200, Easing.Linear);
 //       await Task.Delay(300);
 //       Instance.EntireCalendar.TranslateTo(0, 0, 300, Easing.CubicIn);
 //   }

	public static void DayClicked(System.Object sender, System.EventArgs e)
	{
        Button button = sender as Button;
        Border border = (Border)button.Parent;
        string parameter = (string)button.CommandParameter;
        Console.WriteLine(parameter);

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
			//moveCalendarDown();
        }
		else
		{
			isChecked = true;
			temp = border;
			tempButton = button;
			//moveCalendarUp();
			Instance.ScheduleContent.Text = "Nothing scheduled for " + Instance.MonthName.Text + " " + button.Text;
            border.BackgroundColor = Microsoft.Maui.Graphics.Color.FromRgb(178, 164, 189);
            button.TextColor = Microsoft.Maui.Graphics.Color.FromRgb(18, 17, 18);
        }

    }
}
