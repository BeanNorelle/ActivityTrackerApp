using System;
using System.Drawing;
using System.Windows;

namespace MauiApp2;

public partial class MainPage : ContentPage
{

    public MainPage()
	{
		InitializeComponent();

    }

    private async void OnNextPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("StopWatchPage");
    }

  

}

