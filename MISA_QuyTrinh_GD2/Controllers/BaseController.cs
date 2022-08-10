using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.QuyTrinh.Core.Exceptions;
using MISA.QuyTrinh.Core.Interfaces.Repository;
using MISA.QuyTrinh.Core.Interfaces.Services;

namespace MISA.QuyTrinh.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<MisaEntity> : ControllerBase
    {
        IBaseRepository<MisaEntity> _repository;
        IBaseServices<MisaEntity> _service;

        #region constructor
        public BaseController(IBaseRepository<MisaEntity> repository, IBaseServices<MisaEntity> service)
        {
            _repository = repository;
            _service = service;
        }
        #endregion

        #region method

        /// <summary>
        /// Lấy tất cả bản ghi
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (29/06/2022)
        /// </summary>
        /// <returns>danh sách bản ghi</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _repository.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }


        /// <summary>
        /// Lấy bản ghi theo id
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (29/06/2022)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Đối tượng có mã tương ứng</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var data = _repository.GetById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (29/06/2022)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Mã code và 1 - thành công, 0 - thất bại</returns>
        [HttpPost]
        public IActionResult Post(MisaEntity entity)
        {
            try
            {
                // trả kết quả về client
                var res = _service.InsertService(entity);
                return StatusCode(201, res);
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
        /// <param name="entity"></param>
        /// <returns>Mã code và 1 - thành công, 0 - thất bại</returns>
        [HttpPut]
        public IActionResult Put(MisaEntity entity)
        {
            try
            {
                // trả kết quả về cho client
                var res = _service.UpdateService(entity);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }

        /// <summary>
        /// Xoá dữ liệu
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (29/06/2022)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Mã code và 1 - thành công, 0 - thất bại</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var res = _repository.Delete(id);
                return StatusCode(200, res);
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }

        /// <summary>
        /// xử lý exception
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (29/06/2022)
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>
        /// input: exception
        ///output: Mã lỗi tương ứng và nội dung chi tiết</returns>
        protected IActionResult HandleException(Exception ex)
        {
            var res = new
            {
                devMsg = ex.Message,
                data = ex.Data,
                userMsg = "Có lỗi xảy ra vui lòng liên hệ Misa để được trợ giúp"
            };

            if (ex is MisaValidateException)
            {
                return StatusCode(400, res);
            }
            else
            {
                return StatusCode(500, res);
            }
        }


        #endregion
    }
}
