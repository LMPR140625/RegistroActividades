﻿using MovilAppActivitiesRegister.Views;

namespace MovilAppActivitiesRegister;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        Navigation.PushAsync(new Login ());

        if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

