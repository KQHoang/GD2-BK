using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Core.Models
{
    /// <summary>
    /// Bảng vị trí
    /// Khuất Quang Hoàng (3/8/2022)
    /// </summary>
   public class Positions:BaseEntity
    {
        #region constructor

        public Positions()
        {
            PositionID = Guid.NewGuid();
        }

        #endregion

        #region properties

        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid PositionID { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string PositionName { get; set; }

        #endregion
    }


}
