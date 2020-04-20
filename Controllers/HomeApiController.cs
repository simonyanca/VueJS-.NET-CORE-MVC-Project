using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vue_Core.Models;
using System.Web;
using Nancy.Json;
using System.Text.Json;

namespace Vue_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        IMarket1Repository repo;
        public HomeApiController(IMarket1Repository market1TB)
        {
            repo = market1TB;
        }
        // GET: api/HomeApi/market1
        [HttpGet("market1", Name = "Get")]
        public string Get(int id)
        {
            var result = repo.GetItems();
            var json = JsonSerializer.Serialize(result);
            return json;
        }
    }
}
