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

        public static async Task<List<Message>> LoadMessages(int? UserID, int? RecpID)
        {
            using (IDbConnection db = new SqlConnection(Globals.ConnString))
            {
                string qry = $"select iid message from users where iid = {UserID}";
                return (await db.QueryAsync<Message>(qry, commandType: CommandType.Text)).ToList();
            }
        }

        public static async Task InsertMessage(int? UserIDFrom, int? UserIDTo, string message)
        {
            using (IDbConnection db = new SqlConnection(Globals.ConnString))
            {
                string qry = $"insert into messages(fk_users_from, fk_users_to, message) values ({UserIDFrom}, {UserIDTo}, '{message}')";
                await db.QueryAsync(qry, commandType: CommandType.Text);
            }
        }
    }
}
