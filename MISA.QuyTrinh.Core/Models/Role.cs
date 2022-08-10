using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Core.Models
{
    /// <summary>
    /// Bảng vai trò
    /// Khuất Quang Hoàng (3/8/2022)
    /// </summary>
    public class Role : BaseEntity
    {
        #region constuctor

        public Role()
        {
            RoleID = Guid.NewGuid();
        }

        #endregion

        #region properties

        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid RoleID { get; set; }

        /// <summary>
        /// Tên vai trò
        /// </summary>
        public string RoleName { get; set; }

        #endregion
    }
}
