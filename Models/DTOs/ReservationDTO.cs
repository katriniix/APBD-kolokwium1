namespace KolokwiumAPBD.Models.DTOs;

public class ReservationDTO
{
    public DateTime Date { get; set; }
    public List<Guest> Guests { get; set; }
    public List<Employee> Employees { get; set; }
    public List<Attraction> Attractions { get; set; }
}