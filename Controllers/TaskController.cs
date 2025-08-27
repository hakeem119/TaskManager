using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManger.DTOs;
using TaskManger.Models;
using TaskManger.Repositories;
using static TaskManger.Models.@enum;

namespace TaskManger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepo _repo;
        private readonly IMapper _mapper;
        public TaskController(ITaskRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? search, [FromQuery] int? priority, [FromQuery] bool? isCompleted, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            var items = await _repo.GetAllAsync(search, priority, isCompleted, page, pageSize);
            var total = await _repo.CountAsync(search, priority, isCompleted);
            return Ok(new { data = _mapper.Map<ReadTask[]>(items), page, pageSize, total });
        }

        // GET: api/tasks/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(_mapper.Map<ReadTask>(item));
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<IActionResult> Create(CreateTask dto)
        {
            var item = _mapper.Map<Items>(dto);
            item.CreatedAt = DateTime.UtcNow;
            item.UpdatedAt = DateTime.UtcNow;
            await _repo.AddAsync(item);
            var read = _mapper.Map<ReadTask>(item);
            return CreatedAtAction(nameof(GetById), new { id = read.Id }, read);
        }

        // PUT: api/tasks/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateTask dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            // map non-null properties
            _mapper.Map(dto, existing);
            if (dto.Priority.HasValue)
                existing.Priority = (Priority)dto.Priority.Value;

            existing.UpdatedAt = DateTime.UtcNow;
            await _repo.UpdateAsync(existing);
            return NoContent();
        }

        // PATCH: api/tasks/{id}/complete
        [HttpPatch("{id:guid}/complete")]
        public async Task<IActionResult> ToggleComplete(Guid id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();
            existing.IsCompleted = !existing.IsCompleted;
            existing.UpdatedAt = DateTime.UtcNow;
            await _repo.UpdateAsync(existing);
            return Ok(_mapper.Map<ReadTask>(existing));
        }

        // DELETE: api/tasks/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();
            await _repo.DeleteAsync(existing);
            return NoContent();
        }
    }
}
