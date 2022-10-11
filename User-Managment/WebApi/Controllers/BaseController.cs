using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TSearch, TInsert, TUpdate> : ControllerBase where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        protected readonly IBaseService<T, TSearch, TInsert, TUpdate> _service;
        public BaseController(IBaseService<T, TSearch, TInsert, TUpdate> service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await _service.DeleteAsync(id));
        }
        [HttpGet]
        public virtual async Task<IEnumerable<T>> GetAsync([FromQuery] TSearch search)
        {
            return await _service.GetAsync(search);
        }
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        [HttpPost]
        public virtual async Task<IActionResult> InsertAsync([FromBody] TInsert request)
        {
            return Ok(await _service.InsertAsync(request));
        }
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateAsync(int id, [FromBody] TUpdate request)
        {
            return Ok(await _service.UpdateAsync(id, request));
        }
    }
}
