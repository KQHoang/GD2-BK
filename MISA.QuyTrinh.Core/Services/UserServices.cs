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
        string langCode = Common.LanguageCode;
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
                ErrorValidateMsg.Add(index + ": " + Resources.Resource.ResourceManager.GetString($"UserCode_{langCode}"));
                IsValid = false;
            }

            if (string.IsNullOrEmpty(entity.FullName))
            {
                ErrorValidateMsg.Add(index + ": " + Resources.Resource.ResourceManager.GetString($"FullName_{langCode}"));
                IsValid = false;
            }

            if (string.IsNullOrEmpty(entity.Email))
            {
                ErrorValidateMsg.Add(index + ": " + Resources.Resource.ResourceManager.GetString($"Email_{langCode}"));
                IsValid = false;
            }

            if(entity.RoleID.Count == 0)
            {
                ErrorValidateMsg.Add(index + ": " + Resources.Resource.ResourceManager.GetString($"Role_{langCode}"));
                IsValid = false;
            }

            if (entity.Status == null)
            {
                ErrorValidateMsg.Add(index + ": " + Resources.Resource.ResourceManager.GetString($"Status_{langCode}"));
                IsValid = false;
            }

            if (!string.IsNullOrEmpty(entity.Email))
            {
                if (!Regex.IsMatch(entity.Email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
                {
                    ErrorValidateMsg.Add(index + ": " + Resources.Resource.ResourceManager.GetString($"EmailValid_{langCode}"));
                    IsValid = false;
                }
            }
            //validate mã
            if (_repository.CheckUserCode(entity.UserCode) == true)
            {
                ErrorValidateMsg.Add(index+ ": " + Resources.Resource.ResourceManager.GetString($"UserCodeExist_{langCode}"));
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
            var rowAffectedChangeUser = await _repository.Insert(user);
            //var list = new List<int>();
            //List<Guid> roleIDs = entity.RoleID;
            var roleIDs = entity.RoleID;

            foreach (var roleID in roleIDs)
            {
                User_Role userRole = new User_Role(user.UserID, roleID);
                var rowAffectedChangeUserRole = await _roleRepository.Insert(userRole);
                if (rowAffectedChangeUserRole != 1)
                    return 0;
            }
            //foreach (var item in list)
            //{
            //    if(item == 0)
            //    {
            //        res = 0;
            //        break;
            //    }
                    
            //}
            return rowAffectedChangeUser;

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
