using CrudAngularCore.BL.CoreBl;
using CrudAngularCore.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAngularCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly ILogger<User> _logger;


        public UserController(IUnitOfWork unitOfWork,
            ILogger<User> logger)
        {
            UnitOfWork = unitOfWork;
            _logger = logger;
        }


        [HttpGet]
        public List<User> Get()
        {
            return UnitOfWork.UserBl.GetAll();
        }




        [HttpDelete("{id}")]
        public bool delete(int id)
        {
            User user = UnitOfWork.UserBl.GetByID(id);

            if (user != null)
            {
                try
                {
                    UnitOfWork.UserBl.RemoveEntity(user);
                    UnitOfWork.complete();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        [HttpPost]
        public bool post(User user)
        {
            if (user != null)
            {
                try
                {
                    UnitOfWork.UserBl.Add(user);
                    UnitOfWork.complete();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }

            else
            {
                return false;
            }

        }


        [HttpPut]
         public bool put([FromBody] User user)
        {

            if (user != null)
            {
                try
                {
                    var result = UnitOfWork.UserBl.GetByID(user.Id);

                    result.UserName = user.UserName;
                    result.UserPhone = user.UserPhone;
                    result.UserMail = user.UserMail;

                    UnitOfWork.complete();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            else
            {
                return false;
            }

        }
    }
}
