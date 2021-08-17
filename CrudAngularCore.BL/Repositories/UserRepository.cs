using CrudAngularCore.BL.CoreBl.IRepository;
using CrudAngularCore.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudAngularCore.BL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(angular_testContext context):base(context)
        {

        }
    }
}
