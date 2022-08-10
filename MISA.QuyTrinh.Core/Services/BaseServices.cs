using MISA.QuyTrinh.Core.Exceptions;
using MISA.QuyTrinh.Core.Interfaces.Repository;
using MISA.QuyTrinh.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QuyTrinh.Core.Services
{
    public class BaseServices<MisaEntity> : IBaseServices<MisaEntity>
    {
        #region properties
        IBaseRepository<MisaEntity> _repository;
        protected List<string> ErrorValidateMsg;
        protected bool IsValid = true;
        #endregion

        #region constructor

        public BaseServices(IBaseRepository<MisaEntity> repository)
        {
            _repository = repository;
            ErrorValidateMsg = new List<string>();
        }

        #endregion

        #region methods

        /// <summary>
        /// Thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần thêm</param>
        /// <returns>1 - ok</returns>
        /// <exception cref="MisaValidateException"></exception>
        public int InsertService(MisaEntity entity)
        {
            // Validate dữ liệu
            var isValid = ValidateInsert(entity);
            if (isValid == true)
            {
                // Thêm mới
                this.BeforeInsert(entity);
                var res = this.DoInsert(entity);
                this.AfterInsert(entity);
                return res;
            }
            else
            {
                throw new MisaValidateException(ErrorValidateMsg);
            }

        }



        /// <summary>
        /// Cập nhật dữ liệu
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần cập nhật</param>
        /// <returns>1 - thành công, 0 - thất bại</returns>
        /// <exception cref="MisaValidateException"></exception>
        public int UpdateService(MisaEntity entity)
        {
            // Validate dữ liệu
            var isValid = ValidateUpdate(entity);
            if (isValid == true)
            {
                // Cập nhật
                this.BeforeUpdate(entity);
                var res = this.DoUpdate(entity);
                this.AfterInsert(entity);
                return res;
            }
            else
            {
                throw new MisaValidateException(ErrorValidateMsg);
            }


        }

        /// <summary>
        /// Validate thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra dữ liệu</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        protected virtual bool ValidateInsert(MisaEntity entity)
        {
            return true;
        }

        /// <summary>
        /// Validate thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra dữ liệu</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        protected virtual MisaEntity BeforeInsert(MisaEntity entity)
        {
            return entity;
        }

        /// <summary>
        /// Validate thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra dữ liệu</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        protected virtual void BeforeUpdate(MisaEntity entity)
        {
            
        }

        /// <summary>
        /// Validate thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra dữ liệu</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        protected virtual int DoUpdate(MisaEntity entity)
        {
            var res = _repository.Update(entity);
            return res;
        }

        /// <summary>
        /// Validate thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra dữ liệu</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        protected virtual void AfterUpdate(MisaEntity entity)
        {

        }

        /// <summary>
        /// Validate thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra dữ liệu</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        protected virtual int DoInsert(MisaEntity entity)
        {
            var res = _repository.Insert(entity);
            return res;

        }


        /// <summary>
        /// Validate thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra dữ liệu</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        protected virtual MisaEntity AfterInsert(MisaEntity entity)
        {
            return entity;
        }

        /// <summary>
        /// Validate cập nhật 
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        protected virtual bool ValidateUpdate(MisaEntity entity)
        {
            return true;
        }

        /// <summary>
        /// Thêm hàng loạt 
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        public virtual int InsertAllService(IEnumerable<MisaEntity> entity)
        {
            // Validate dữ liệu
            var isValid = true;
            if (isValid == true)
            {
                // Thêm mới
                //this.BeforeInsert(entity);
                var res = this.DoInsertAll(entity);
                //this.AfterInsert(entity);
                return res;
            }
            else
            {
                throw new MisaValidateException(ErrorValidateMsg);
            }
        }

        /// <summary>
        /// Validate thêm mới
        /// Người tạo: Khuất Quang Hoàng
        /// Ngày tạo: (28/6/2022)
        /// </summary>
        /// <param name="entity">đối tượng cần kiểm tra dữ liệu</param>
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        protected virtual int DoInsertAll(IEnumerable<MisaEntity> entity)
        {
            return 0;
        }

        public int UpdateService(IEnumerable<MisaEntity> entity)
        {
            var isValid = true;
            if (isValid == true)
            {
                // Cập nhật
                //this.BeforeUpdate(entity);
                var res = this.DoUpdateAll(entity);
                //this.AfterInsert(entity);
                return res;
            }
            else
            {
                throw new MisaValidateException(ErrorValidateMsg);
            }
        }

        protected virtual int DoUpdateAll(IEnumerable<MisaEntity> entity)
        {
            return 0;
        }


        #endregion
    }
}
