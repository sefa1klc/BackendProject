using System.Security.Claims;
using Core.Entities.Concrete;

namespace Core.Utilities.Security.JWT;

public interface ITokenHelper
{
    AccessToken GenerateToken(User user, List<OperationClaim> claims);
}