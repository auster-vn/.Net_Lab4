using System.Collections.Generic;

public class Booking
{
    public string CustomerID { get; set; }
    public List<Flight> Flights { get; set; }

    public Booking(string customerID)
    {
        CustomerID = customerID;
        Flights = new List<Flight>();
    }

    public void AddFlight(Flight flight)
    {
        Flights.Add(flight);
    }
}

