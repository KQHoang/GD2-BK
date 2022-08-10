using Dapper;
using MISA.QuyTrinh.Core.Interfaces.Repository;
using MISA.QuyTrinh.Core.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Infrastructure.Repository
{
    public class UserRoleRepository: BaseRepository<User_Role>, IUserRoleRepository
    {
        /// <summary>
        /// Xoá dữ liệu có 2 id
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (3/8/2022)
        /// </summary>
        /// <returns></returns>
        public override int Delete(Guid id1, Guid id2)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {

                var sql = $"DELETE from {TableName} WHERE UserID = @UserId and RoleID = @RoleID";
                var paramestes = new DynamicParameters();
                paramestes.Add($"@UserId", id1);
                paramestes.Add($"@RoleId", id2);
                var res = SqlConnection.Execute(sql: sql, param: paramestes);
                return res;
            }
        }
    }
}
