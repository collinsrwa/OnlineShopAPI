using SharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BETOnlineShopAPI.Models
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly ApplicationDbContext _db;
        public RegisterRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<Register> AddRegisteredUser(Register register)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRegister(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Register>> GetAllRegisteredUsers()
        {
            throw new NotImplementedException();
        }

        public Task<Register> GetRegisteredUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Register> GetRegisteredUserById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Register> UpDateRegisteredUser(Register register)
        {
            throw new NotImplementedException();
        }
    }
}
