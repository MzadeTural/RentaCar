namespace RentaCar.Business.DTOs.ContactDtos
{
       public record CreateContactDto(string FullName,
                                      string Email,
                                      string Number,
                                      string Subject,
                                      int Type);
    
}

