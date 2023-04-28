
using SQLite;


namespace MauiApp2
{
    public class UserRepository
    {

        private string _dbPath;
        public string StatusMessage { get; set; }
        private SQLiteConnection conn;
        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<User>();
        }
        public UserRepository(string dbPath)
        {
            _dbPath = dbPath;
        }
        public void AddNewUser(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name)) throw new Exception("Valid name required");

                result = conn.Insert(new User { Name = name });
                StatusMessage = string.Format("{0}  record(s) added(Name: {1})", result, name);
           
            }
            catch(Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                Init();
                return conn.Table<User>().ToList();
            }
            catch(Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<User>();
        }
    }
}
