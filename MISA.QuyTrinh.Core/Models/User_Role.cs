using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Core.Models
{
    /// <summary>
    /// Bảng chi tiết vai trò
    /// </summary>
    public class User_Role: BaseEntity
    {
        #region constructor
        public User_Role()
        {
            UserID = Guid.NewGuid();
            RoleID = Guid.NewGuid();
        }

        public User_Role(Guid userId, Guid roleId)
        {
            UserID = userId;
            RoleID = roleId;
        }
        #endregion


        #region properties

        /// <summary>
        /// Khoá ngoại
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        ///  Khoá ngoại
        /// </summary>
        public Guid RoleID { get; set; }

        /// <summary>
        /// trạng thái để thực hiện cập nhật
        /// 1 - thêm
        /// 2 - xoá
        /// 3 - không làm gì
        /// </summary>
        public int status { get; set; }

        #endregion
    }
}
