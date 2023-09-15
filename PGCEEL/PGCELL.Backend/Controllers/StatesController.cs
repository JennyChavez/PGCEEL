using Microsoft.AspNetCore.Mvc;
using PGCEEL.Shared.Entities;
using PGCELL.Backend.Intertfaces;

namespace PGCELL.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : GenericController<State>
    {
        public StatesController(IGenericUnitOfWork<State> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
