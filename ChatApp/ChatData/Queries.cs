using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Models;
using Dapper;

namespace ChatApp.ChatData
{
    class Queries
    {
        public static async Task<List<Recipient>> GetListOfUsers(int? UserID)
        {
            using (IDbConnection db = new SqlConnection(Globals.ConnString))
            {
                string qry = $"select iid, username from users where iid != {UserID}";
                return (await db.QueryAsync<Recipient>(qry, commandType: CommandType.Text)).ToList();
            }
        }
    }
}
