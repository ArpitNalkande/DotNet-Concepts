using DbOperationsEFCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbOperationsEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(AppDbContext appDbContext) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddnewBook([FromBody] Book model)
        {
            appDbContext.Books.Add(model);
            await appDbContext.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPost("AddBooks")]
        public async Task<IActionResult> AddBook([FromBody] List<Book>model)
        {
            appDbContext.Books.AddRange(model);
            await appDbContext.SaveChangesAsync();
            return Ok(model);
        }
    }
}
