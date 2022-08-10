using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Core.Models
{
    /// <summary>
    /// base entity
    /// Người tạo: Khuất Quang Hoàng
    /// Ngày tạo: (3/8/2022)
    /// </summary>
    public class BaseEntity
    {
        #region prop
        // ngày tạo
        public DateTime? CreatedDate { get; set; }

        // người tạo
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        public string? ModifiedBy { get; set; }
        #endregion
    }
}
