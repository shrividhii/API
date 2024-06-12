using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<Common.DBEntityClass.UserDetail> GetUser(string username, string password);

    }
}
