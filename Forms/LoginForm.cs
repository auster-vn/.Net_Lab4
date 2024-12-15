using Gtk;
using System;
using System.Linq;
using System.Collections.Generic;

public class LoginForm : Window
{
    private Entry txtUsername, txtPassword;
    private Button btnLogin, btnRegister;
    private List<User> users;

    public LoginForm() : base("Login")
    {
        SetDefaultSize(400, 300);
        SetPosition(WindowPosition.Center);

        users = new List<User>
        {
            new User("admin", "1234", "Admin User", "admin@example.com", "01/01/1990") // Tài khoản mặc định
        };

        Box layout = new Box(Orientation.Vertical, 10);

        Label lblUsername = new Label("Username:");
        txtUsername = new Entry();
        layout.PackStart(lblUsername, false, false, 10);
        layout.PackStart(txtUsername, false, false, 10);

        Label lblPassword = new Label("Password:");
        txtPassword = new Entry { Visibility = false };
        layout.PackStart(lblPassword, false, false, 10);
        layout.PackStart(txtPassword, false, false, 10);

        btnLogin = new Button("Login");
        btnLogin.Clicked += OnLoginClicked;
        layout.PackStart(btnLogin, false, false, 10);

        btnRegister = new Button("Register");
        btnRegister.Clicked += OnRegisterClicked;
        layout.PackStart(btnRegister, false, false, 10);

        Add(layout);
        ShowAll();
    }

    private void OnLoginClicked(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string password = txtPassword.Text;

        User user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            MenuForm menuForm = new MenuForm(this, user, new List<Flight>());
            this.Hide();
            menuForm.Show();
        }
        else
        {
            MessageDialog md = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "Invalid credentials.");
            md.Run();
            md.Destroy();
        }
    }

    private void OnRegisterClicked(object sender, EventArgs e)
    {
        RegistrationForm registrationForm = new RegistrationForm(this, users);
        this.Hide();
        registrationForm.Show();
    }
}

