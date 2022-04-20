using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class LoginModel
    {
        public int? iid { get; set; } = null;
        public string username { get; set; }
        public string password { get; set; }
    }
}
