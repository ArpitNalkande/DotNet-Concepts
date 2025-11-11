using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DbOperationsEFCore.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DbOperationsEFCore.Controllers
{
    [Route("api/Currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbcontext;

        public CurrencyController(AppDbContext appDbContext)
        {
            _appDbcontext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetCurrencies()
        {
            var res = await _appDbcontext.Currencies.ToListAsync();
            //var res = await (from c in _appDbcontext.Currencies select c).ToListAsync();
            return Ok(res);

        }

        //[HttpGet("{name}/{description}")]
        //public async Task<IActionResult> GetCurrenciess([FromRoute] string name, [FromRoute] string description)
        //{
        //    var res = await _appDbcontext.Currencies.FirstOrDefaultAsync(x=>x.title == name && x.Description==description);
        //    //var res = await (from c in _appDbcontext.Currencies select c).ToListAsync();
        //    return Ok(res);

        //}

        //[HttpPost("all")]
        //public async Task<IActionResult> GetCurrenciesByIdsAsync([FromQuery] List<int> ids)
        //{
        //    var res = await _appDbcontext.Currencies.Where(c => ids.Contains(c.Id)).ToListAsync();
        //    return Ok(res);
        //}
    }
}
