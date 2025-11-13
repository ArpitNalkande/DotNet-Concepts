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
        [HttpGet("GetBooks")]
        public async Task<IActionResult> GetBooksAsync()
        {
               var books = await appDbContext.Books.Select(x => new       // Anonymous class No name is define
                                                                          // or class may be ask in interview question 
                                                                          // concept name is Navigational Properties. 
            {
                x.Id,
                Title = x.Title,
                description = x.description,
                noofPages = x.noofPages

            }).ToListAsync();
            return Ok(books);
        }


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

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int bookId)
        {
            var book = await appDbContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);
            if (book == null)
            {
                return NotFound();
            }
            appDbContext.Books.Remove(book);
            await appDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("bulk")]
        public async Task<IActionResult> DeleteBulk()
        {
            var books = await appDbContext.Books.Where(x => x.Id > 6).ExecuteDeleteAsync();     // For better performance

            //appDbContext.Books.RemoveRange(books);                                            // it will hit the Db multiple time 
            //await appDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
