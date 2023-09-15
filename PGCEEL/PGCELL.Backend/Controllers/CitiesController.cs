﻿using Microsoft.AspNetCore.Mvc;
using PGCEEL.Shared.Entities;
using PGCELL.Backend.Intertfaces;

namespace PGCELL.Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : GenericController<City>
    {
        public CitiesController(IGenericUnitOfWork<City> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
