using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Core.Interfaces.Repository
{
    public interface IBaseRepository<MisaEntity>
    {
        #region methods

        /// <summary>
        /// Lấy danh sách dữ liệu
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (3/8/2022)
        /// </summary>
        /// <returns></returns>
        IEnumerable<MisaEntity> Get();

        /// <summary>
        /// Lấy theo id
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (3.8/2022)
        /// </summary>
        /// <returns></returns>
        MisaEntity GetById(Guid id);

        /// <summary>
        /// Thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (3/8/2022)
        /// </summary>
        /// <returns></returns>
        int Insert(MisaEntity entity);

        /// <summary>
        /// Cập nhật
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (3/8/2022)
        /// </summary>
        /// <returns></returns>
        int Update(MisaEntity entity);

        /// <summary>
        /// Xoá dữ liệu
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (3/8/2022)
        /// </summary>
        /// <returns></returns>
        int Delete(Guid id);

        /// <summary>
        /// Xoá dữ liệu có 2 id
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (3/8/2022)
        /// </summary>
        /// <returns></returns>
        int Delete(Guid id1, Guid id2);
        #endregion
    }
}
