using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PGCEEL.Shared.DTOs;
using PGCEEL.Shared.Entities;
using PGCELL.Backend.Data;
using PGCELL.Backend.Helpers;
using PGCELL.Backend.Intertfaces;

namespace PGCELL.Backend.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private readonly IGenericUnitOfWork<T> _unitOfWork;
        private IGenericUnitOfWork<City> unitOfWork;

        public GenericController(IGenericUnitOfWork<T> unitOfWork, DataContext context)
        {
            _unitOfWork = unitOfWork;
        }

        public GenericController(IGenericUnitOfWork<City> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("totalPages")]
        public virtual async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetTotalPagesAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }


        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetAsync(int id)
        {
            var action = await _unitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpPost]
        public virtual async Task<IActionResult> PostAsync(T model)
        {
            var action = await _unitOfWork.AddAsync(model);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpPut]
        public virtual async Task<IActionResult> PutAsync(T model)
        {
            var action = await _unitOfWork.UpdateAsync(model);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            var action = await _unitOfWork.GetAsync(id);
            if (!action.WasSuccess)
            {
                return NotFound();
            }
            action = await _unitOfWork.DeleteAsync(id);
            if (!action.WasSuccess)
            {
                return BadRequest(action.Message);
            }
            return NoContent();
        }
    }
}