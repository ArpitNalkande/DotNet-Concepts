using DbOperationsEFCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
            appDbContext.Books.AddRange(model); // multiple records is added using AddRange method
            await appDbContext.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateExistingdetails([FromRoute] int bookId, [FromBody] Book model)
        {
            var book = appDbContext.Books.FirstOrDefault(x => x.Id == bookId);
            if (book == null)
            {
                return NotFound();
            }
            book.Title = model.Title;
            book.description = model.description;
            book.noofPages = model.noofPages;

            await appDbContext.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPut("bulk")]
        public async Task<IActionResult> UpdatingBulkRecords()
        {
            await appDbContext.Books
                .Where(x => x.noofPages >200)
                .ExecuteUpdateAsync(s => s
                    //.SetProperty(b => b.isactive, b => false)
                    //.SetProperty(b => b.createdon, b => DateTime.UtcNow)
                    .SetProperty(b => b.description, b => " Updated one")
                );
            return Ok();
        }
    }
}
