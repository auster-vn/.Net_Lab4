public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Birthday { get; set; }

    public User(string username, string password, string fullName, string email, string birthday)
    {
        Username = username;
        Password = password;
        FullName = fullName;
        Email = email;
        Birthday = birthday;
    }
}

