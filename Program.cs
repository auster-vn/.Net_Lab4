using Gtk;
using System;
using System.Collections.Generic;  // Add this for the List

public class Program
{
    public static void Main(string[] args)
    {
        Application.Init();

        // Create a list of users
        List<User> userList = new List<User>();

        // Show the login form first, passing the userList
        LoginForm loginForm = new LoginForm();
        loginForm.Show();

        Application.Run();
    }
}

