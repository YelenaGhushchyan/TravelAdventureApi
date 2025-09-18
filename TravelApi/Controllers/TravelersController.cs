using Microsoft.AspNetCore.Mvc;
using TravelBusiness.Services;
using TravelData.Models;

namespace TravelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelersController : ControllerBase
    {
        private readonly ITravelerService _service;
        public TravelersController(ITravelerService service) => _service = service;

        [HttpGet] public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
        [HttpGet("{id}")] public async Task<IActionResult> Get(int id)
        {
            var traveler = await _service.GetAsync(id);
            return traveler == null ? NotFound() : Ok(traveler);
        }
        [HttpPost] public async Task<IActionResult> Create(Traveler t)
        {
            var created = await _service.CreateAsync(t);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }
        [HttpPut("{id}")] public async Task<IActionResult> Update(int id, Traveler t)
        {
            var ok = await _service.UpdateAsync(id, t);
            return ok ? NoContent() : NotFound();
        }
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }
    }
}