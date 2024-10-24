using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core.Entities.Concrete;

public class OperationClaim : IEntity
{
    public int ID { get; set; }
    public string Name { get; set; }
}