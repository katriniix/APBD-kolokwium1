using System.Data.SqlClient;
using KolokwiumAPBD.Models;
using KolokwiumAPBD.Models.DTOs;

namespace KolokwiumAPBD.Services;

public class DbService : IDbService
{
    private readonly IConfiguration _configuration;

    public DbService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<ReservationDTO> getInfoAboutReservation(int bookingId)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        var cmd = new SqlCommand(@" 
            SELECT b.date, g.first_name, g.last_name, g.date_of_birth, e.first_name, e.last_name, 
                   e.employee_number, a.name, a.price, ba.amount
            FROM Booking b
            JOIN Guest g ON b.guest_id = g.guest_id 
            JOIN Employee e ON b.employee_id = e.employee_id 
            JOIN Booking_Attraction ba ON b.booking_id = ba.booking_id 
            JOIN Attraction a ON ba.attraction_id = a.attraction_id 
            WHERE b.booking_id = @bookingId");
        cmd.Parameters.AddWithValue("@bookingId", bookingId);
        var reader = await cmd.ExecuteReaderAsync();
        ReservationDTO? result = null;
        Dictionary<int, Guest> guests = new();
        Dictionary<int, Employee> employees = new();
        Dictionary<int, Attraction> attractions = new();
        
        while (await reader.ReadAsync())
        {
            var date = reader.GetDateTime(0);
            var firstNameGuest = reader.GetString(1);
            var lastNameGuest = reader.GetString(2);
            var dateOfBirthGuest = reader.GetDateTime(3);
            var firstNameEmployee = reader.GetString(4);
            var lastNameEmployee = reader.GetString(5);
            var employeeNumber = reader.GetString(6);
            var name = reader.GetString(7);
            var price = reader.GetDecimal(8);
            var amount = reader.GetInt32(9);

            if (result == null)
            {
                result = new ReservationDTO
                {
                    Date = date,
                    Guests = new List<Guest>(),
                    Employees = new List<Employee>(),
                    Attractions = new List<Attraction>()

                };
            }

            if (guests != null)
            {
            }
        }
        return result;
    }
}