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
                                  Guid FuelTypeId,
                                  int SeatCount,
                                  decimal Price  );

}
