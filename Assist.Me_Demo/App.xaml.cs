﻿using Assist.Me_Demo.Views;

namespace Assist.Me_Demo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new NavigationPage(new Views.StartPage());
    }
}

