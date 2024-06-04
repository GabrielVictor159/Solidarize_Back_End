using System.ComponentModel.DataAnnotations;

namespace Solidarize.Api.UseCases.Users.GetProfile;

public class GetProfileRequest
{
    [Required]
    public Guid Id {get; set;}
}
