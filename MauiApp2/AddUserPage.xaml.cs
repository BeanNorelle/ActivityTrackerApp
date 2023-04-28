namespace MauiApp2
{
    public partial class AddUserPage: ContentPage
    {
        public AddUserPage()
        {
            InitializeComponent();
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
}
