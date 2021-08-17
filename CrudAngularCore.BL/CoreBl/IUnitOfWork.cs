using CrudAngularCore.BL.CoreBl.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudAngularCore.BL.CoreBl
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserBl { get; }
        int complete();
    }
}
