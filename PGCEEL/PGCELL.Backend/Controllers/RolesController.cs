using Microsoft.AspNetCore.Mvc;
using PGCEEL.Shared.Entities;
using PGCELL.Backend.Data;
using PGCELL.Backend.Intertfaces;

namespace PGCELL.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : GenericController<Role>
    {
        public RolesController(IGenericUnitOfWork<Role> unitOfWork, DataContext context) : base(unitOfWork, context)
        {
        }
    }
}