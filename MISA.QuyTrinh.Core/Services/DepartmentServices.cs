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
    public class DepartmentServices: BaseServices<Department>, IDepartmentServices
    {
        IDepartmentRepository _repository;
        public DepartmentServices(IDepartmentRepository repository):base(repository)
        {
            _repository = repository;
        }
    }
}
