using Microsoft.AspNetCore.Mvc;
using PGCEEL.Shared.Entities;
using PGCELL.Backend.Intertfaces;

namespace PGCELL.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalitiesController : GenericController<Modality>
    {
        public ModalitiesController(IGenericUnitOfWork<Modality> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
