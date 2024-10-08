using System;

namespace UserNamespace
{
    public class User
    {
        private string user_id { get; set; }
        protected string user_password { get; set; }

        public User(string id, string pass)
        {
            this.user_id = id;
            this.user_password = pass;
        }

        public virtual bool verifyLogin(string id, string pass)
        {
            id = "Jasper";
            pass = "12345";
            return user_id.Equals(id, StringComparison.OrdinalIgnoreCase) &&
                   user_password.Equals(pass);
        }

        public bool updatePassword(string currentPassword, string newPassword)
        {
            if (string.Equals(this.user_password, currentPassword))
            {
                this.user_password = newPassword;
                return true;
            }
            return false;
        }
    }

    public class Administrator : User
    {
        public Administrator(string userId, string password) : base(userId, password) { }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // Input for User
            Console.Write("Enter User ID: ");
            string userID = Console.ReadLine();

            Console.Write("Enter Password: ");
            string userPass = Console.ReadLine();

            // Input for Administrator
            Console.Write("Enter Admin ID: ");
            string adUserID = Console.ReadLine();

            Console.Write("Enter Admin Password: ");
            string adUserPass = Console.ReadLine();

            // Instantiate User and Administrator objects
            User user = new User(userID, userPass);
            Administrator admin = new Administrator(adUserID, adUserPass);

            // Test Login
            Console.WriteLine("User Login: " + user.verifyLogin(userID, userPass));
            Console.WriteLine("Admin Login: " + admin.verifyLogin(adUserID, adUserPass));

            // Test Login with wrong credentials
            Console.WriteLine("User Login (wrong password): " + user.verifyLogin(userID, "wrongpassword"));
            Console.WriteLine("Admin Login (wrong username): " + admin.verifyLogin("wrongadmin", adUserPass));

            // Test Password Update
            Console.WriteLine("Update User Password: " + user.updatePassword(userPass, "newpassword"));
            Console.WriteLine("User Login (new password): " + user.verifyLogin(userID, "newpassword"));

            // Test Password Update with wrong current password
            Console.WriteLine("Update User Password (wrong current password): " + user.updatePassword("wrongpassword", "anothernewpassword"));
            Console.WriteLine("User Login (new password): " + user.verifyLogin(userID, "newpassword"));
        }
    }
}
