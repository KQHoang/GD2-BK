using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.QuyTrinh.Core.Interfaces.Repository;
using MISA.QuyTrinh.Core.Interfaces.Services;
using MISA.QuyTrinh.Core.Models;
using MISA.QuyTrinh.Infrastructure.Repository;

namespace MISA.QuyTrinh.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserRolesController : BaseController<User_Role>
    {
        #region Declare
        IUserRoleRepository _repository;
        IUserRoleServices _services;

        #endregion

        #region Constructor
        public UserRolesController(IUserRoleRepository repository, IUserRoleServices services) : base(repository, services)
        {
            _repository = repository;    
            _services = services;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Xoá dữ liệu
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (29/06/2022)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Mã code và 1 - thành công, 0 - thất bại</returns>
        [HttpDelete("{id1}/{id2}")]
        public IActionResult Delete(Guid id1, Guid id2)
        {
            try
            {
                var res = _repository.Delete(id1, id2);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }

        /// <summary>
        /// Cập nhật dữ liệu 
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (29/06/2022)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Mã code và 1 - thành công, 0 - thất bại</returns>
        [HttpPut("putAll")]
        public IActionResult Put(IEnumerable<User_Role> entity)
        {
            try
            {
                var res = _services.UpdateService(entity);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }

        #endregion
    }
}
