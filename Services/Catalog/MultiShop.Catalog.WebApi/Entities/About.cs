using MultiShop.Core.Entities;

namespace MultiShop.Catalog.WebApi.Entities;

public class About : MongoEntityBase
{
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}