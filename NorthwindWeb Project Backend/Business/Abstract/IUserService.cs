using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>>  GetClaims(User user);
        IResult Add(User user);
        IDataResult<User> GetByMail(string email);
    }
}