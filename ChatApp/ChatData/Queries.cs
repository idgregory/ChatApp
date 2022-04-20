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

        public static async Task<string> GetUserName(int? id)
        {
            using (IDbConnection db = new SqlConnection(Globals.ConnString))
            {
                string qry = $"select username from users where iid = {id}";
                List<string> usernames = (await db.QueryAsync<string>(qry, commandType: CommandType.Text)).ToList();
                return usernames[0];
            }
        }

        public static async Task<List<Message>> LoadMessages(int? UserID, int? RecpID)
        {
            using (IDbConnection db = new SqlConnection(Globals.ConnString))
            {
                string qry = 
                    $@"
                        select 
	                        distinct msg.iid,
	                        msg.fk_users_from, 
	                        msg.fk_users_to, 
	                        --(select username from users where iid = msg.fk_user_from) as SenderUsername,
	                        message
                        from messages msg
                        join
                        users u on u.iid = msg.fk_users_from
                        where (msg.fk_users_from = {UserID} or msg.fk_users_from = {RecpID}) and (msg.fk_users_to = {UserID} or msg.fk_users_to = {RecpID})";
                List<Message> msgs = (await db.QueryAsync<Message>(qry, commandType: CommandType.Text)).ToList();
                return msgs;
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
