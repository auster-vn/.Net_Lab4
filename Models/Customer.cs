using System;
using System.Drawing;

public class Customer
{
    public string CustomerID { get; set; }
    public string CustomerName { get; set; }
    public DateTime Birthday { get; set; }
    public string PassPortNbr { get; set; }
    public string Nationality { get; set; }
    public Image Avatar { get; set; }

    public Customer(string customerID, string customerName, DateTime birthday, string passportNbr, string nationality, Image avatar)
    {
        CustomerID = customerID;
        CustomerName = customerName;
        Birthday = birthday;
        PassPortNbr = passportNbr;
        Nationality = nationality;
        Avatar = avatar;
    }
}

