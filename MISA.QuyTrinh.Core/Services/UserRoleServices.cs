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
        public UserRoleServices(IUserRoleRepository repository):base(repository)
        {
            _repository = repository;
        }

        protected override int DoUpdateAll(IEnumerable<User_Role> entity)
        {
            List<int> list = new List<int>();
            foreach (var userRole in entity)
            {
                if(userRole.status == 1)
                {
                    var res = _repository.Insert(userRole);
                    list.Add(res);
                }
                
                if(userRole.status == 2)
                {
                    var res = _repository.Delete(userRole.UserID, userRole.RoleID);
                    list.Add(res);
                }
            }
            foreach (var item in list)
            {
                if (item == 0)
                    return 0;
            }
            return 1;
        }
    }
}
