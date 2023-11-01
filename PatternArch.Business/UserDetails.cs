using PatternArch.Persistence.IRepository;
using PatternArch.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternArch.Business
{
    public class UserInfo
    {
        private readonly IRepository<UserDetail> _context;
        public UserInfo(IRepository<UserDetail> context)
        {
            _context = context;
        }

        public IEnumerable<UserDetail> GetUserDetail()
        {
            return _context.GetAll();
        }
        public UserDetail GetUserDetailId(int id)
        {

            return _context.GetById(id);
        }
        public void CreateUser(UserDetail userData)
        {
            _context.Add(userData);
        }
        public void UpdateUser(UserDetail userData)
        {
            _context.Update(userData);
        }
        public void DeleteUser(UserDetail userData)
        {
            _context.Delete(userData);
        }

    }
}
