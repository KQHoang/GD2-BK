using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Core.Interfaces.Services
{
    public interface IBaseServices<MisaEntity>
    {
        #region methods

        /// <summary>
        /// dịch vụ thêm mới (Validate)
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/06/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần thêm</param>
        /// <returns>1 - thành công, 0 - thất bại</returns>
        Task<int> InsertService(MisaEntity entity);

        /// <summary>
        /// dịch vụ cập nhật thông tin (Validate)
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/06/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần cập nhật</param>
        /// <returns>1 - thành công, 0 - thất bại</returns>
        Task<int> UpdateService(MisaEntity entity);

        /// <summary>
        /// dịch vụ thêm mới (Validate)
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/06/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần thêm</param>
        /// <returns>1 - thành công, 0 - thất bại</returns>
        int InsertAllService(IEnumerable<MisaEntity> entitys);

        /// <summary>
        /// dịch vụ cập nhật thông tin (Validate)
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/06/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần cập nhật</param>
        /// <returns>1 - thành công, 0 - thất bại</returns>
        int UpdateService(IEnumerable<MisaEntity> entitys);


        #endregion
    }
}
