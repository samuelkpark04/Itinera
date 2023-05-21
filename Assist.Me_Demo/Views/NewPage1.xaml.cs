using Microsoft.Maui.Layouts;

namespace Assist.Me_Demo.Views;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
        // Create a FlexLayout to hold the calendar cells
        FlexLayout calendarLayout = new FlexLayout()
        {
            Direction = FlexDirection.Row,
            Wrap = FlexWrap.Wrap,
            JustifyContent = FlexJustify.SpaceBetween,
            AlignItems = FlexAlignItems.Center
        };

        // Loop through each month of the year
        for (int month = 1; month <= 12; month++)
        {
            // Create a label for the month name
            Label monthLabel = new Label()
            {
                Text = new DateTime(1, month, 1).ToString("MMMM"),
                FontSize = 16,
                FontAttributes = FontAttributes.Bold
            };

            // Add the month label to the calendar layout
            calendarLayout.Children.Add(monthLabel);

            // Loop through each day of the month
            for (int day = 1; day <= DateTime.DaysInMonth(1, month); day++)
            {
                // Create a label for the day number
                Label dayLabel = new Label()
                {
                    Text = day.ToString(),
                    FontSize = 12
                };

                // Add the day label to the calendar layout
                calendarLayout.Children.Add(dayLabel);
            }
        }

        // Add the calendar layout to the page content
        Content = calendarLayout;
    }
}