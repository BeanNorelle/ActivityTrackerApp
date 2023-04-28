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

    private void AddNewUser_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";

        App.UserRepo.AddNewUser(newUser.Text);
        statusMessage.Text = App.UserRepo.StatusMessage;
    }

    private void GetAllUser_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";

        List<User> users = App.UserRepo.GetAllUsers();
        peopleList.ItemsSource = users;
    }

}

