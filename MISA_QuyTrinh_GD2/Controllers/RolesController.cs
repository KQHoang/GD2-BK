using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.QuyTrinh.Core.Interfaces.Repository;
using MISA.QuyTrinh.Core.Interfaces.Services;
using MISA.QuyTrinh.Core.Models;

namespace MISA.QuyTrinh.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RolesController : BaseController<Role>
    {
        public RolesController(IBaseRepository<Role> repository, IBaseServices<Role> service) : base(repository, service)
        {
        }
    }
}
