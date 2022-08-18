using MISA.QuyTrinh.Core.Exceptions;
using MISA.QuyTrinh.Core.Interfaces.Repository;
using MISA.QuyTrinh.Core.Interfaces.Services;
using MySqlConnector;
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
            // Thêm mới
            this.BeforeInsert(entity);
            var res = this.DoInsert(entity);
            this.AfterInsert(entity);
            return res;

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
        ///  index: vị trí người dùng thêm mới
        /// <returns>true - validate hợp lệ, false - lỗi validate</returns>
        protected virtual bool ValidateInsert(MisaEntity entity, int index)
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
            List<bool> validates = new List<bool>();
            var index = 1;
            // Validate nhiều
            foreach (var item in entity)
            {
                var res = ValidateInsert(item, index);
                index++;
            }

            foreach (var item in validates)
            {
                if (!item)
                    throw new MisaValidateException(ErrorValidateMsg);
            }

            MySqlTransaction transaction = null;
            var connection = _repository.GetConnection();
            using (connection)
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                try
                {
                    foreach (var item in entity)
                    {
                        var res = this.InsertService(item);
                        if (res != 1)
                            throw new MisaValidateException(ErrorValidateMsg);
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new MisaValidateException(ErrorValidateMsg); ;
                }
                finally
                {
                    transaction.Dispose();
                }
            }
            // nếu lỗi roll back
            return 1;

        }

        /// <summary>
        /// Thực hiện cập nhật vai trò 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="MisaValidateException"></exception>
        public int UpdateService(IEnumerable<MisaEntity> entity)
        {
            MySqlTransaction transaction = null;
            var connection = _repository.GetConnection();
            using (connection)
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                try
                {
                    foreach (var item in entity)
                    {
                        var res = this.UpdateService(item);
                        if (res == 0)
                            throw new MisaValidateException(ErrorValidateMsg);
                    }
                }
                catch (Exception)
                {
                    // nếu lỗi roll back
                    transaction.Rollback();
                    throw new MisaValidateException(ErrorValidateMsg);
                }
                finally
                {
                    transaction.Dispose();
                }
            }

            return 1;
        }
        #endregion
    }
}
