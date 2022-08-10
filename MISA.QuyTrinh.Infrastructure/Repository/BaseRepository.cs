using Dapper;
using MISA.QuyTrinh.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Infrastructure.Repository
{
    public class BaseRepository<MisaEntity> : IBaseRepository<MisaEntity>
    {
        #region Declaration

        // chuỗi kết nối
        protected string ConnectionString;
        protected MySqlConnection SqlConnection;
        // tên bảng
        protected string TableName;

        #endregion

        #region constructor

        public BaseRepository()
        {
            ConnectionString = "Host=localhost;" +
                  " Port=3306; " +
                  "Database= misa.quanghoang; " +
                  "User Id = QuangHoang;" +
                  " Password=1234";
            TableName = typeof(MisaEntity).Name;
        }

        #endregion

        #region methods

        /// <summary>
        /// Xoá bản ghi
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo (3/8/2022)
        /// </summary>
        /// <param name="id">id đối tượng cần xoá</param>
        /// <returns>1 - thành công, 0 - thất bại</returns>
        public int Delete(Guid id)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {

                var sql = $"DELETE from {TableName} WHERE {TableName}Id = @{TableName}Id";
                var paramestes = new DynamicParameters();
                paramestes.Add($"@{TableName}Id", id);
                var res = SqlConnection.Execute(sql: sql, param: paramestes);
                return res;
            }
        }

        /// <summary>
        /// Xoá dữ liệu có 2 id
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (3/8/2022)
        /// </summary>
        /// <returns></returns>
        public virtual int Delete(Guid id1, Guid id2)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Lấy tất cả dữ liệu
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo (28/06/2022)
        /// </summary>
        /// <returns>list đối tượng</returns>
        public virtual IEnumerable<MisaEntity> Get()
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {

                var sql = $"SELECT * From {TableName}";
                var res = SqlConnection.Query<MisaEntity>(sql);
                return res;
            }
        }

        /// <summary>
        /// Lấy theo mã
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo (3/8/2022)
        /// </summary>
        /// <param name="id">mã đối tượng</param>
        /// <returns>Lấy đối tượng theo mã </returns>
        public MisaEntity GetById(Guid id)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {

                var sql = $"SELECT * from {TableName} WHERE {TableName}Id = @{TableName}Id";
                var paramestes = new DynamicParameters();
                paramestes.Add($"@{TableName}Id", id);
                var res = SqlConnection.QueryFirstOrDefault<MisaEntity>(sql: sql, param: paramestes);
                return res;
            }
        }

        /// <summary>
        /// Thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo (3/8/2022)
        /// </summary>
        /// <param name="department">đối tượng cần thêm</param>
        /// <returns>1 - thêm thành công, 0 - thêm thất bai</returns>
        public int Insert(MisaEntity entity)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {

                var sqlQuery = $"Proc_Insert{TableName}";
                var res = SqlConnection.Execute(sqlQuery, param: entity, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo (3/8/2022)
        /// </summary>
        /// <param name="department">đối tượng cần cập nhật</param>
        /// <returns>1 - cập nhật thành công, 0 - cập nhật thất bại</returns>
        public int Update(MisaEntity entity)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {

                var sqlQuery = $"Proc_Update{TableName}";
                var res = SqlConnection.Execute(sqlQuery, param: entity, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }
        }


        #endregion
    }
}
