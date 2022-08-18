using Dapper;
using MISA.QuyTrinh.Core.Interfaces.Repository;
using MISA.QuyTrinh.Core.Models;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Infrastructure.Repository
{
    public class UserRepository:BaseRepository<User>, IUserRepository
    {
        #region Methods

        /// <summary>
        /// Kiểm tra trùng mã người dùng
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (15/08/2022)
        /// </summary>
        /// <param name="id">input: mã cần kiểm tra</param>
        /// <returns>true: trùng mã, false: không trùng mã </returns>
        public bool CheckUserCode(string id)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = "SELECT UserCode from User WHERE UserCode = @UserCode";
                var paramestes = new DynamicParameters();
                paramestes.Add("@UserCode", id);
                var res = SqlConnection.QueryFirstOrDefault(sql: sql, param: paramestes);
                if (res == null)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Lấy tất cả dữ liệu
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo (28/06/2022)
        /// </summary>
        /// <returns>list đối tượng</returns>
        public override IEnumerable<User> Get()
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
               
                   var sqlQuery = "Proc_GetUser";
                   var res = SqlConnection.Query<User>(sql: sqlQuery, commandType: System.Data.CommandType.StoredProcedure);
                   return res;
            }
        }

        // <summary>
        /// Lấy mã người dùng mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (15/08/2022)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>mã người dùng</returns>
        public string GetNewUserCode()
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {

                var sqlQuery = "Proc_NewUserCode";
                var res = SqlConnection.QueryFirst<string>(sql: sqlQuery, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }
        }

        /// <summary>
        /// Phân trang
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (10/8/2022)
        /// </summary>
        /// <param name="pageIndex">trang hiện tại</param>
        /// <param name="pageSize">số lượng bản ghi trên 1 trang</param>
        /// <param name="filter">key tìm kiếm</param>
        /// <returns>danh sách nhân viên </returns>
        public object GetPageing(int pageIndex, int pageSize, string? filter = "")
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var sqlQuery = $"Proc_GetUserPaging";
                var parameters = new DynamicParameters();
                parameters.Add("@m_Filter", filter);
                parameters.Add("@m_PageIndex", pageIndex);
                parameters.Add("@m_PageSize", pageSize);
                parameters.Add("@m_TotalRecord", direction: System.Data.ParameterDirection.Output);
                parameters.Add("@m_RecordStart", direction: System.Data.ParameterDirection.Output);
                parameters.Add("@m_RecordEnd", direction: System.Data.ParameterDirection.Output);
                var res = SqlConnection.Query<User>(sql: sqlQuery, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                int totalRecord = parameters.Get<int>("@m_TotalRecord");
                int recordStart = parameters.Get<int>("@m_RecordStart");
                int recordEnd = parameters.Get<int>("@m_RecordEnd");
                return new
                {
                    TotalRecord = totalRecord,
                    RecordStart = recordStart,
                    RecordEnd = recordEnd,
                    Data = res
                };
            }
        }

        #endregion
    }
}
