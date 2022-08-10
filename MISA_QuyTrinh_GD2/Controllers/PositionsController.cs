using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.QuyTrinh.Core.Interfaces.Repository;
using MISA.QuyTrinh.Core.Interfaces.Services;
using MISA.QuyTrinh.Core.Models;

namespace MISA.QuyTrinh.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PositionsController : BaseController<Positions>
    {
        public PositionsController(IBaseRepository<Positions> repository, IBaseServices<Positions> service) : base(repository, service)
        {
        }
    }
}
