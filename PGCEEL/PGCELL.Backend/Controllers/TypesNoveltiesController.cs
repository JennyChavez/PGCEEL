using Microsoft.AspNetCore.Mvc;
using PGCEEL.Shared.Entities;
using PGCELL.Backend.Data;
using PGCELL.Backend.Intertfaces;

namespace PGCELL.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypesNoveltiesController : GenericController<TypeNovelty>
    {
        private readonly DataContext _context;

        public TypesNoveltiesController(IGenericUnitOfWork<TypeNovelty> unitOfWork, DataContext context) : base(unitOfWork, context)
        {
            _context = context;
        }
    }
}