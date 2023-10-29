namespace RentaCar.Business.DTOs.ReservationDtos
{
	public record CreateReservationDto(
		DateTime RentalStartDate,
		DateTime RentalEndDate,
		Guid TakeAwayLoactionId,
		Guid DeliveryLocationId,
        string EmergencyEmail,
		string EmetgencyPhoneNumber,
		Guid CarId,
		decimal TotalAmount
        );

}