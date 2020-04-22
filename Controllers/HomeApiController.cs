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
using Newtonsoft.Json;

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
        [HttpGet("market1")]
        public string Get(int id)
        {
            var referList = repo.GetItems();
            var resultList = new List<Object>();
            referList.ForEach(el => { resultList.Add
                (new { Id = el.Id, Name = el.Name, Description = el.Description, ImgData = Convert.ToBase64String(el.ImgData) }); 
            });
            var json = System.Text.Json.JsonSerializer.Serialize(resultList);
            return json;
        }
    }
}
