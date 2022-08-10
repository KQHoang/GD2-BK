using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.QuyTrinh.Core.Interfaces.Repository;
using MISA.QuyTrinh.Core.Interfaces.Services;
using MISA.QuyTrinh.Core.Models;

namespace MISA.QuyTrinh.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : BaseController<User>
    {
        IUserServices _service;
        IUserRepository _repository;
        public UsersController(IUserRepository repository, IUserServices services) : base(repository, services)
        {
            _service = services;
            _repository = repository;
        }

            /// <summary>
            /// Thêm mới dữ liệu
            /// Người tạo: Khuất Quang Hoàng
            /// Ngày tạo: (29/06/2022)
            /// </summary>
            /// <param name="entity"></param>
            /// <returns>Mã code và 1 - thành công, 0 - thất bại</returns>
            [HttpPost("postAll")]
            public IActionResult Post(List<User> entity)
            {
                try
                {
                    // trả kết quả về client
                    var res = _service.InsertAllService(entity);
                    return StatusCode(201, res);
                }
                catch (Exception ex)
                {

                    return HandleException(ex);
                }
            }

        /// <summary>
        /// Phân trang 
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (6/7/2022)
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns>input: recordStart (trang bắt đầu), recordEnd (trang cuối), totalRecord (tổng trang)
        ///output: Data (các bản ghi)
        /// </returns>
        [HttpGet("filter")]
        public ActionResult GetPaging(int pageIndex, int pageSize, string? filter)
        {
            try
            {
                var res = _repository.GetPageing(pageIndex, pageSize, filter);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return (ActionResult)HandleException(ex);
            }
        }

    }
}
