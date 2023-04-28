namespace MauiApp2;

public partial class StopWatchPage : ContentPage
{
    IDispatcherTimer timer;
    TimeSpan elapsed = TimeSpan.Zero;
    private bool timerStarted = false;
    public StopWatchPage()
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
            timer.Start();
            timerStarted = true;
        }
        else
        {
            timer.Stop();
            timerStarted = false;
        }

        StopWatchbuttonChange();
    }

    void StopWatchbuttonChange()
    {
        if (timerStarted)
        {
            CounterBtn.Text = "Pause";
            CounterBtn.BackgroundColor = Microsoft.Maui.Graphics.Color.FromArgb("#F05656");
        }
        else
        {
            CounterBtn.Text = "Start";
            CounterBtn.BackgroundColor = Microsoft.Maui.Graphics.Color.FromArgb("#565CF0");
        }
    }

}