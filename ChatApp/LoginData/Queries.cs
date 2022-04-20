using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Models;
using Dapper;

namespace ChatApp.LoginData
{
    public static class Queries
    {
        public static async Task<List<LoginModel>> GetUserFromDB(LoginModel lgm, bool NotCreate)
        {
            List<LoginModel> result = null;
            string AddString = NotCreate ? $" and password = '{lgm.password}'" : "";
            using (IDbConnection db = new SqlConnection(Globals.ConnString))
            {
                string qry = $"select top 1 * from users where username = '{lgm.username}'" + AddString;
                return (await db.QueryAsync<LoginModel>(qry, commandType: CommandType.Text)).ToList();
            }
        }
        public static async Task InsertUser(LoginModel lgm)
        {
            using (IDbConnection db = new SqlConnection(Globals.ConnString))
            {
                var result = (await db.QueryAsync<LoginModel>($"insert into users(username, password) values ('{lgm.username}', '{lgm.password}');", commandType: CommandType.Text)).ToList();
            }
        }
    }
}
