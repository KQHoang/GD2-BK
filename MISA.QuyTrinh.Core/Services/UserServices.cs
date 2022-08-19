using MISA.QuyTrinh.Core.Interfaces.Repository;
using MISA.QuyTrinh.Core.Interfaces.Services;
using MISA.QuyTrinh.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Core.Services
{
    public class UserServices:BaseServices<User>,  IUserServices
    {
        IUserRepository _repository;
        IUserRoleRepository _roleRepository;
        #region Constructor
        public UserServices(IUserRepository repository, IUserRoleRepository roleRepository) : base(repository)
        {
            _repository = repository;
            _roleRepository = roleRepository;
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
        protected override bool ValidateInsert(User entity, int index)
        {
            if (string.IsNullOrEmpty(entity.UserCode))
            {
                ErrorValidateMsg.Add(index + ": Mã người dùng không được để trống");
                IsValid = false;
            }

            if (string.IsNullOrEmpty(entity.FullName))
            {
                ErrorValidateMsg.Add(index + ": Tên người dùng không được để trống");
                IsValid = false;
            }

            if (string.IsNullOrEmpty(entity.Email))
            {
                ErrorValidateMsg.Add(index + ": Email không được để trống");
                IsValid = false;
            }

            if(entity.RoleID.Count == 0)
            {
                ErrorValidateMsg.Add(index + ": Vai trò không được để trống");
                IsValid = false;
            }

            if (entity.Status == null)
            {
                ErrorValidateMsg.Add(index + ": Trạng thái người dùng không được để trống");
                IsValid = false;
            }

            if (!string.IsNullOrEmpty(entity.Email))
            {
                if (!Regex.IsMatch(entity.Email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
                {
                    ErrorValidateMsg.Add(index + ": Email không đúng định dang");
                    IsValid = false;
                }
            }
            //validate mã
            if (_repository.CheckUserCode(entity.UserCode) == true)
            {
                ErrorValidateMsg.Add(index+ ": Mã người dùng đã tồn tại");
                IsValid = false;
            }
            return IsValid;
        }

        /// <summary>
        /// Validate thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra dữ liệu</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        async protected override Task<int> DoInsert(User entity)
        {
            User user = new User(entity.UserCode, entity.FullName, entity.DepartmentID, entity.PositionID, entity.Email, entity.Status);
            var res = await _repository.Insert(user);
            var list = new List<int>();
            List<Guid> roleIDs = entity.RoleID;
            foreach (var item in roleIDs)
            {
                User_Role userRole = new User_Role(user.UserID, item);
                var response = await _roleRepository.Insert(userRole);
                list.Add(response);
            }
            foreach (var item in list)
            {
                if(item == 0)
                {
                    res = 0;
                    break;
                }
                    
            }
            return res;

        }

        /// <summary>
        /// Validate cập nhật 
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        protected override bool ValidateUpdate(User entity)
        {
            return true;
        }


        #endregion
    }
}
