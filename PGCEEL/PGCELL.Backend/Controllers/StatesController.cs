﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PGCEEL.Shared.Entities;
using PGCELL.Backend.Controllers;
using PGCELL.Backend.Data;
using PGCELL.Backend.Intertfaces;


namespace Sales.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatesController : GenericController<State>
    {
        private readonly DataContext _context;

        public StatesController(IGenericUnitOfWork<State> unitOfWork, DataContext context) : base(unitOfWork)
        {
            _context = context;
        }


        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.States
                .Include(s => s.Cities)
                .ToListAsync());
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var state = await _context.States
                .Include(s => s.Cities)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state);
        }
    }
}

