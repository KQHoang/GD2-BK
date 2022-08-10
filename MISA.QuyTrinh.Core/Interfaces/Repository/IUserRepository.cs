using MISA.QuyTrinh.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Core.Interfaces.Repository
{
    public interface IUserRepository:IBaseRepository<User>
    {
        /// <summary>
        /// Phân trang
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (10/8/2022)
        /// </summary>
        /// <param name="pageIndex">trang hiện tại</param>
        /// <param name="pageSize">số lượng bản ghi trên 1 trang</param>
        /// <param name="filter">key tìm kiếm</param>
        /// <returns>danh sách nhân viên </returns>
        object GetPageing(int pageIndex, int pageSize, string? filter = "");
    }
}
