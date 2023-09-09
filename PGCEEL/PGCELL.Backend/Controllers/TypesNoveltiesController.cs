using Microsoft.AspNetCore.Mvc;
using PGCEEL.Shared.Entities;
using PGCELL.Backend.Intertfaces;

namespace PGCELL.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypesNoveltiesController : GenericController<TypeNovelty>
    {
        public TypesNoveltiesController(IGenericUnitOfWork<TypeNovelty> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
