using Common.EntityClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        Task<Common.UserModel.UserDetails> AuthenticateAsync(Common.UserModel.UserDetails login);
        string GenerateJwtToken(Common.EntityClass.UserDetails user);
    }
}
