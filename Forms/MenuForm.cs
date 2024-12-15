using Gtk;
using System;
using System.Collections.Generic;

public class MenuForm : Window
{
    private Button btnViewTickets, btnBookFlight, btnLogout, btnProfile;
    private LoginForm parentForm;
    private User currentUser;
    private List<Flight> bookedFlights;

    public MenuForm(LoginForm parentForm, User currentUser, List<Flight> bookedFlights) : base("Menu")
    {
        this.parentForm = parentForm;
        this.currentUser = currentUser;
        this.bookedFlights = bookedFlights;

        SetDefaultSize(400, 300);
        SetPosition(WindowPosition.Center);

        Box layout = new Box(Orientation.Vertical, 10);

        Label lblTitle = new Label("Welcome! Please select an option:");
        layout.PackStart(lblTitle, false, false, 10);

        btnViewTickets = new Button("View Booked Tickets");
        btnViewTickets.Clicked += OnViewTicketsClicked;
        layout.PackStart(btnViewTickets, false, false, 10);

        btnBookFlight = new Button("Book Flight");
        btnBookFlight.Clicked += OnBookFlightClicked;
        layout.PackStart(btnBookFlight, false, false, 10);

        btnLogout = new Button("Logout");
        btnLogout.Clicked += OnLogoutClicked;
        layout.PackStart(btnLogout, false, false, 10);

        btnProfile = new Button("View Profile");
        btnProfile.Clicked += OnViewProfileClicked;
        layout.PackStart(btnProfile, false, false, 10);

        Add(layout);
        ShowAll();
    }

    private void OnViewTicketsClicked(object sender, EventArgs e)
    {
        BookedTicketsForm bookedTicketsForm = new BookedTicketsForm(this, bookedFlights);
        this.Hide();
        bookedTicketsForm.Show();
    }

    private void OnBookFlightClicked(object sender, EventArgs e)
    {
        AirTicketBookingForm bookingForm = new AirTicketBookingForm(currentUser, bookedFlights);
        this.Hide();
        bookingForm.Show();
    }

    private void OnLogoutClicked(object sender, EventArgs e)
    {
        this.Hide();
        parentForm.Show();
    }

    private void OnViewProfileClicked(object sender, EventArgs e)
    {
        MessageDialog profileDialog = new MessageDialog(
            this, 
            DialogFlags.Modal, 
            MessageType.Info, 
            ButtonsType.Ok, 
            $"Username: {currentUser.Username}\nFull Name: {currentUser.FullName}\nEmail: {currentUser.Email}\nBirthday: {currentUser.Birthday}"
        );
        profileDialog.Run();
        profileDialog.Destroy();
    }
}

