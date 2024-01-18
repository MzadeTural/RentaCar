using Microsoft.AspNetCore.Http;

namespace RentaCar.Business.DTOs.CarDtos
{
    public record CreateCarDto(Guid ModelId,
                                  string OwnerId,
                                  IFormFile MainPhotoUrl,
                                  List<IFormFile> Photos,
                                  string Description,
                                  Guid GearBoxId,
                                  string YearOfManufacture,
                                  DateTime RentalStartDate,
                                  DateTime RentalEndDate,
                                  Guid FuelTypeId,
                                  int SeatCount,
                                  double EngineVolume,
                                  decimal Price  );

}
