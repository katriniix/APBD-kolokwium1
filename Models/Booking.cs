namespace KolokwiumAPBD.Models;

public class Booking
{
    public int bookingId { get; set; }
    public int guestId { get; set; }
    public int employeeId { get; set; }
    public DateTime date { get; set; }
}