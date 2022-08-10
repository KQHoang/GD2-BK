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
    public class UserServices:BaseServices<User>,  IUserServices
    {
        IUserRepository _repository;
        IUserRoleRepository _roleRepository;

        public UserServices(IUserRepository repository, IUserRoleRepository roleRepository) : base(repository)
        {
            _repository = repository;
            _roleRepository = roleRepository;
        }

        /// <summary>
        /// Validate thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra dữ liệu</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        protected override bool ValidateInsert(User entity)
        {
            //validate mã
            return true;
        }
        /// <summary>
        /// Validate thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra dữ liệu</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        //public override User BeforeInsert(User entity)
        //{
        //    // thêm / sửa trước khi lưu ở đây
        //    return entity;
        //}


        /// <summary>
        /// Validate thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra dữ liệu</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        protected override int DoInsert(User entity)
        {
            User user = new User(entity.UserCode, entity.FullName, entity.DepartmentID, entity.PositionID, entity.Email, entity.Status);
            var res = _repository.Insert(user);
            var list = new List<int>();
            List<Guid> roleIDs = entity.RoleID;
            foreach (var item in roleIDs)
            {
                User_Role userRole = new User_Role(user.UserID, item);
                var response = _roleRepository.Insert(userRole);
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

        //public override int InsertAllService(IEnumerable<User> entity)
        //{
        //    throw new NotImplementedException();
        //}

        protected override int DoInsertAll(IEnumerable<User> entity)
        {
            List<int> responses = new List<int>();
            foreach (var user in entity)
            {
                var res = this.DoInsert(user);
                responses.Add(res);
            }
            foreach (var item in responses)
            {
                if (item == 0)
                    return 0;
            }
            return 1;
        }
    }
}
