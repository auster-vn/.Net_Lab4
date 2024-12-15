public class Flight
{
    public string FlightID { get; set; }
    public string TimeDepart { get; set; }
    public string TimeArrival { get; set; }
    public string FlightType { get; set; }

    public Flight(string flightID, string timeDepart, string timeArrival, string flightType)
    {
        FlightID = flightID;
        TimeDepart = timeDepart;
        TimeArrival = timeArrival;
        FlightType = flightType;
    }
}

