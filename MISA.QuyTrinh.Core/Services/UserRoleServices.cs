using MISA.QuyTrinh.Core.Interfaces.Repository;
using MISA.QuyTrinh.Core.Interfaces.Services;
using MISA.QuyTrinh.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Core.Services
{
    public class UserRoleServices:BaseServices<User_Role>, IUserRoleServices
    {
        IUserRoleRepository _repository;
        #region Constructor
        public UserRoleServices(IUserRoleRepository repository):base(repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Validate thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra dữ liệu</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
         async protected override Task<int> DoUpdate(User_Role entity)
        {
            //var res = _repository.Update(entity);
            //return res;
            if (entity.status == 1)
            {
                var res =await  _repository.Insert(entity);
                return res;
            }

            if (entity.status == 2)
            {
                var res = _repository.Delete(entity.UserID, entity.RoleID);
                return res;
            }
            return 1;
        }

        #endregion
    }
}
