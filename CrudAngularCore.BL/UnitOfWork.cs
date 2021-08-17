using CrudAngularCore.BL.CoreBl;
using CrudAngularCore.BL.CoreBl.IRepository;
using CrudAngularCore.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudAngularCore.BL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly angular_testContext _context;

        public IUserRepository UserBl { get; }

        public UnitOfWork(angular_testContext context,
            IUserRepository userRepository)
        {
            _context = context;
            UserBl = userRepository;
        }


        public int complete()
        {
            try
            {
               return _context.SaveChanges();
                 
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
