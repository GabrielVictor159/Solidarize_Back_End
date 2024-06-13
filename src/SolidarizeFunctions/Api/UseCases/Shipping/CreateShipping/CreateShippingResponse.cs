using Newtonsoft.Json;

namespace Solidarize.Api.UseCases.Shipping.CreateShipping;

public class CreateShippingResponse
{
    public CreateShippingResponse(Application.Bundaries.CreateShipping.CreateShippingResponse? createShippingResponse)
    {
        if(createShippingResponse!=null && createShippingResponse.Shipping !=null)
        {
            this.CreateShippingOutput = new
            (
                createShippingResponse.Shipping.CreationDate,
                createShippingResponse.Shipping.IdUserCreation,
                createShippingResponse.Shipping.IdUserResponse,
                createShippingResponse.Shipping.Description,
                createShippingResponse.Shipping.Name,
                createShippingResponse.Shipping.Id);
            
            this.Sucess =true;
        }
    }
    [JsonProperty("CreateShippingOutput")]
    public CreateShippingOutput? CreateShippingOutput {get; private set;}
    [JsonProperty("Sucess")]
    public bool Sucess {get; private set;} = false;
}

public class CreateShippingOutput
{
    public CreateShippingOutput(DateTime creationDate, Guid idUserCreation, Guid idUserResponse, string? description, string? name, Guid id)
    {
        CreationDate = creationDate;
        IdUserCreation = idUserCreation;
        IdUserResponse = idUserResponse;
        Description = description;
        Name = name;
        Id = id;
    }

    [JsonProperty("CreationDate")]
    public DateTime CreationDate { get; private set; }
    [JsonProperty("IdUserCreation")]
    public Guid IdUserCreation { get; private set; }
    [JsonProperty("IdUserResponse")]
    public Guid IdUserResponse { get; private set; }
    [JsonProperty("Description")]
    public string? Description { get; private set; }
    [JsonProperty("Name")]
    public string? Name { get; private set; }
    [JsonProperty("Id")]
    public Guid Id { get; private set; }
}
