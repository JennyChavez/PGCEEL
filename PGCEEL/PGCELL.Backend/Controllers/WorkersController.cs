﻿using Microsoft.AspNetCore.Mvc;
using PGCEEL.Shared.Entities;
using PGCELL.Backend.Data;
using PGCELL.Backend.Intertfaces;

namespace PGCELL.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : GenericController<Worker>
    {
        private readonly DataContext _context;
        public WorkersController(IGenericUnitOfWork<Worker> unitOfWork, DataContext context) : base(unitOfWork, context)
        {
            _context = context;
        }
    }
}
