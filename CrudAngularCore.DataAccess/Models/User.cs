using System;
using System.Collections.Generic;

#nullable disable

namespace CrudAngularCore.DataAccess.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int? UserPhone { get; set; }
        public string UserMail { get; set; }
    }
}
