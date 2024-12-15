using Gtk;
using System;
using System.Collections.Generic;

public class AirTicketBookingForm : Window
{
    private Button btnBack, btnBookFlight;
    private Entry txtFlightID, txtTimeDepart, txtTimeArrival, txtFlightType;
    private ComboBoxText flightComboBox;
    private List<Flight> flights;
    private User currentUser;
    private List<Flight> bookedFlights;

    public AirTicketBookingForm(User currentUser, List<Flight> bookedFlights) : base("Book Your Flight")
    {
        this.currentUser = currentUser;
        this.bookedFlights = bookedFlights;

        flights = new List<Flight>
        {
            new Flight("VN001", "07:00 AM", "09:00 AM", "Vietnam Airlines"),
            new Flight("VN002", "10:00 AM", "12:30 PM", "Bamboo Airways"),
            new Flight("VN003", "01:00 PM", "03:00 PM", "VietJet Air")
        };

        SetDefaultSize(400, 300);
        SetPosition(WindowPosition.Center);

        Box layout = new Box(Orientation.Vertical, 10);

        Label lblTitle = new Label("Book Your Flight");
        layout.PackStart(lblTitle, false, false, 10);

        Label lblChooseFlight = new Label("Select Flight:");
        layout.PackStart(lblChooseFlight, false, false, 10);

        flightComboBox = new ComboBoxText();
        foreach (var flight in flights)
        {
            flightComboBox.Append(flight.FlightID, flight.FlightID); 
        }
        flightComboBox.Active = 0;
        layout.PackStart(flightComboBox, false, false, 10);

        Label lblFlightID = new Label("Flight ID:");
        txtFlightID = new Entry();
        layout.PackStart(lblFlightID, false, false, 10);
        layout.PackStart(txtFlightID, false, false, 10);

        Label lblTimeDepart = new Label("Time Depart:");
        txtTimeDepart = new Entry();
        layout.PackStart(lblTimeDepart, false, false, 10);
        layout.PackStart(txtTimeDepart, false, false, 10);

        Label lblTimeArrival = new Label("Time Arrival:");
        txtTimeArrival = new Entry();
        layout.PackStart(lblTimeArrival, false, false, 10);
        layout.PackStart(txtTimeArrival, false, false, 10);

        Label lblFlightType = new Label("Flight Type:");
        txtFlightType = new Entry();
        layout.PackStart(lblFlightType, false, false, 10);
        layout.PackStart(txtFlightType, false, false, 10);

        btnBookFlight = new Button("Book Flight");
        btnBookFlight.Clicked += OnBookFlightClicked;
        layout.PackStart(btnBookFlight, false, false, 10);

        btnBack = new Button("Back to Menu");
        btnBack.Clicked += OnBackToMenuClicked;
        layout.PackStart(btnBack, false, false, 10);

        Add(layout);
        ShowAll();
    }

    private void OnBookFlightClicked(object sender, EventArgs e)
    {
        string selectedFlightID = flightComboBox.ActiveText ?? txtFlightID.Text;
        string timeDepart = txtTimeDepart.Text;
        string timeArrival = txtTimeArrival.Text;
        string flightType = txtFlightType.Text;

        Flight bookedFlight = new Flight(selectedFlightID, timeDepart, timeArrival, flightType);
        bookedFlights.Add(bookedFlight);

        MessageDialog bookingDialog = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok,
            $"Flight booked successfully!\nFlight ID: {selectedFlightID}\nDepart: {timeDepart}\nArrival: {timeArrival}\nAirline: {flightType}");
        bookingDialog.Run();
        bookingDialog.Destroy();
    }

    private void OnBackToMenuClicked(object sender, EventArgs e)
    {
        MenuForm menuForm = new MenuForm(new LoginForm(), currentUser, bookedFlights); 
        this.Hide();
        menuForm.Show();
    }
}

