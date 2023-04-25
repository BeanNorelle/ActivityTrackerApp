using System;
using System.Windows;

namespace MauiApp2;

public partial class MainPage : ContentPage
{

    IDispatcherTimer timer;
    TimeSpan elapsed = TimeSpan.Zero;
    private bool timerStarted = false;
    public MainPage()
	{
		InitializeComponent();

    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
        if (timerStarted == false)
        {
            timer = Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);

            timer.Tick += (s, e) =>
            {
                elapsed += timer.Interval;
                timerLabel.Text = elapsed.ToString("hh\\:mm\\:ss\\:ff");
            };
            CounterBtn.Text = "Pause";
            timer.Start();
            timerStarted = true;
        }
        else
        {
            CounterBtn.Text = "Start";
            timer.Stop();
            timerStarted = false;
        }
        

    }

    private void OnResetClicked(object sender, EventArgs e)
    {
            timer.Stop();
            elapsed = TimeSpan.Zero;
            CounterBtn.Text = "Start";
    }

}

