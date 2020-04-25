using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vue_Core.Models;
using Newtonsoft.Json;

namespace Vue_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        IMarket1Repository repo1;
        IMarket2Repository repo2;
        ICartItemRepo repo3;
        public HomeApiController(IMarket1Repository market1TB,IMarket2Repository market2TB, ICartItemRepo userCartRepo)
        {
            repo1 = market1TB;
            repo2 = market2TB;
            repo3 = userCartRepo;
        }
        [HttpPost("ToUserCart")]
        public void Post1(string json)
        {
            var userId = User.Identity.Name;
            var item = JsonConvert.DeserializeObject<CartItem>(json);
            repo3.Create(item);
        }
        // GET: api/HomeApi/getUser
        [HttpGet("getUser")]
        public string Get3(int id)
        {
            var userId = User.Identity.Name;
            return userId;
        }
        // GET: api/HomeApi/market1
        [HttpGet("market1")]
        public string Get1(int id)
        {
            var referList = repo1.GetItems();
            var resultList = new List<Object>();
            referList.ForEach(el => { resultList.Add
                (new { Id = el.Id, Name = el.Name, Description = el.Description, ImgData = Convert.ToBase64String(el.ImgData) }); 
            });
            var json = System.Text.Json.JsonSerializer.Serialize(resultList);
            return json;
        }
        // GET: api/HomeApi/market2
        [HttpGet("market2")]
        public string Get2(int id)
        {
            var referList = repo2.GetItems();
            var resultList = new List<Object>();
            referList.ForEach(el => {
                resultList.Add
                    (new { Id = el.Id, Name = el.Name, Description = el.Description, Discount = el.Discount , ImgData = Convert.ToBase64String(el.ImgData) });
            });
            var json = System.Text.Json.JsonSerializer.Serialize(resultList);
            return json;
        }
    }
}
