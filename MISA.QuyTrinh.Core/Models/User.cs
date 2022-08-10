using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Core.Models
{
    /// <summary>
    /// Bảng người dùng
    /// Khuất Quang Hoàng (3/8/2022)
    /// </summary>
    public class User: BaseEntity
    {
        #region contructor

        public User()
        {
            UserID = Guid.NewGuid();
            DepartmentID = Guid.NewGuid();
            PositionID = Guid.NewGuid();
        }

        public User(string userCode, string fullName, Guid departmentID, Guid positionID, string email, int status) {
            UserID = Guid.NewGuid();
            UserCode = userCode;
            FullName = fullName;
            DepartmentID = departmentID;
            PositionID = positionID;
            Email = email;
            Status = status;
        }
        #endregion

        #region properties

        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// Mã người dùng
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public Guid DepartmentID { get; set; }

        /// <summary>
        /// Mã vị trí
        /// </summary>
        public Guid PositionID { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int Status { get; set; }

        public string? DepartmentName { get; set; }

        public string? PositionName { get; set; }

        public string? RoleName { get; set; }

        public List<Guid> RoleID { get; set;}

        #endregion

    }
}
