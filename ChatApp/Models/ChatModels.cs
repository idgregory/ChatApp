using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class Recipient
    {
        public int iid { get; set; }
        public string username { get; set; }
    }

    public class Message
    {
        public int iid { get; set; }
        public int fk_users_from { get; set; }
        public int fk_users_to { get; set; }
        public string SenderUsername { get; set; }
        public string message { get; set; }
    }
}
