using KolokwiumAPBD.Models.DTOs;

namespace KolokwiumAPBD.Services;

public interface IDbService
{
    Task<ReservationDTO> getInfoAboutReservation(int bookingId);
}