using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PGCEEL.Shared.Entities;
using PGCELL.Backend.Data;
using PGCELL.Backend.Intertfaces;

namespace PGCELL.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalitiesController : GenericController<Modality>
    {

        private readonly DataContext _context;

        public ModalitiesController(IGenericUnitOfWork<Modality> unitOfWork, DataContext context) : base(unitOfWork, context)
        {
            _context = context;
        }
    }
}
