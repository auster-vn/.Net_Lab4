using Gtk;
using System;
using System.Collections.Generic;

public class RegistrationForm : Window
{
    private LoginForm parentForm;
    private List<User> users;
    private Entry txtUsername, txtPassword, txtFullName, txtEmail, txtBirthday;
    private Button btnCreate, btnCancel;

    public RegistrationForm(LoginForm parentForm, List<User> users) : base("Register Account")
    {
        this.parentForm = parentForm;
        this.users = users;  // Nhận danh sách người dùng từ LoginForm

        SetDefaultSize(400, 300);
        SetPosition(WindowPosition.Center);

        Box layout = new Box(Orientation.Vertical, 10);

        Label lblUsername = new Label("Username:");
        txtUsername = new Entry();
        layout.PackStart(lblUsername, false, false, 10);
        layout.PackStart(txtUsername, false, false, 10);

        Label lblPassword = new Label("Password:");
        txtPassword = new Entry { Visibility = false };
        layout.PackStart(lblPassword, false, false, 10);
        layout.PackStart(txtPassword, false, false, 10);

        Label lblFullName = new Label("Full Name:");
        txtFullName = new Entry();
        layout.PackStart(lblFullName, false, false, 10);
        layout.PackStart(txtFullName, false, false, 10);

        Label lblEmail = new Label("Email:");
        txtEmail = new Entry();
        layout.PackStart(lblEmail, false, false, 10);
        layout.PackStart(txtEmail, false, false, 10);

        Label lblBirthday = new Label("Birthday:");
        txtBirthday = new Entry();
        layout.PackStart(lblBirthday, false, false, 10);
        layout.PackStart(txtBirthday, false, false, 10);

        btnCreate = new Button("Create Account");
        btnCreate.Clicked += OnCreateClicked;
        layout.PackStart(btnCreate, false, false, 10);

        btnCancel = new Button("Cancel");
        btnCancel.Clicked += OnCancelClicked;
        layout.PackStart(btnCancel, false, false, 10);

        Add(layout);
        ShowAll();
    }

    private void OnCreateClicked(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string password = txtPassword.Text;
        string fullName = txtFullName.Text;
        string email = txtEmail.Text;
        string birthday = txtBirthday.Text;

        // Tạo đối tượng User và thêm vào danh sách users
        User newUser = new User(username, password, fullName, email, birthday);
        users.Add(newUser);

        // Thông báo thành công
        MessageDialog successDialog = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Account created successfully!");
        successDialog.Run();
        successDialog.Destroy();

        // Quay lại LoginForm
        this.Hide();
        parentForm.Show();
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        // Quay lại LoginForm
        this.Hide();
        parentForm.Show();
    }
}

