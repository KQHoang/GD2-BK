using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Core.Models
{
    /// <summary>
    /// Bảng phòng ban
    /// Khuất Quang Hoàng (3/8/2022)
    /// </summary>
    public class Department: BaseEntity
    {
        #region constructor

        public Department()
        {
            DepartmentID = Guid.NewGuid();
        }

        #endregion

        #region properties

        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid DepartmentID { get; set; }

        /// <summary>
        ///  Tên phòng ban
        /// </summary>
        public string DepartmentName    { get; set; }

        #endregion
    }
}
