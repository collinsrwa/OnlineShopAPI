using SharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETOnlineShopAPI.Models
{
    public interface IRegisterRepository
    {
        Task<IEnumerable<Register>> GetAllRegisteredUsers();
        Task<Register> GetRegisteredUserById(int Id);
        Task<Register> GetRegisteredUserByEmail(string email);
        Task<Register> AddRegisteredUser(Register register);
        Task<Register> UpDateRegisteredUser(Register register);
        Task DeleteRegister(int Id);
    }
}
