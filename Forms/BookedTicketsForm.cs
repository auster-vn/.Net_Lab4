using Gtk;
using System;
using System.Collections.Generic;

public class BookedTicketsForm : Window
{
    private MenuForm parentForm;
    private List<Flight> bookedFlights;
    private ListBox ticketsListBox;
    private Button btnBack;

    public BookedTicketsForm(MenuForm parentForm, List<Flight> bookedFlights) : base("Booked Tickets")
    {
        this.parentForm = parentForm;
        this.bookedFlights = bookedFlights;

        SetDefaultSize(400, 300);
        SetPosition(WindowPosition.Center);

        Box layout = new Box(Orientation.Vertical, 10);

        Label lblTitle = new Label("Your Booked Tickets:");
        layout.PackStart(lblTitle, false, false, 10);

        ticketsListBox = new ListBox();
        foreach (var ticket in bookedFlights)
        {
            string ticketInfo = $"FlightID: {ticket.FlightID}, Depart: {ticket.TimeDepart}, Arrival: {ticket.TimeArrival}, Airline: {ticket.FlightType}";
            ticketsListBox.Add(new Label(ticketInfo));
        }

        ticketsListBox.ShowAll();
        layout.PackStart(ticketsListBox, true, true, 10);

        btnBack = new Button("Back to Menu");
        btnBack.Clicked += OnBackClicked;
        layout.PackStart(btnBack, false, false, 10);

        Add(layout);
        ShowAll();
    }

    private void OnBackClicked(object sender, EventArgs e)
    {
        this.Hide();
        parentForm.Show();
    }
}

