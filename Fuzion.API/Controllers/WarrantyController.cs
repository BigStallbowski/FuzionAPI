using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Fuzion.API.DAL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Fuzion.API.Controllers
{
    [Route("api/warranty")]
    [ApiController]
    public class WarrantyController : Controller
    {
        [HttpGet("{id}")]
        public async Task<ActionResult> GetWarrantyInfoByServiceTag(string id)
        {
            var warrantyList = new List<Warranty>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.dell.com/support/assetinfo/v4/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response =
                    await client.GetAsync($"getassetwarranty/{id}?apikey=5676eb02-68dc-4e8d-9cb8-ed406038581d");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = JObject.Parse(await response.Content.ReadAsStringAsync());
                    foreach (var value in jsonResponse["AssetWarrantyResponse"][0]["AssetEntitlementData"])
                    {
                        warrantyList.Add(new Warranty
                        {
                            Type = (string)value["ServiceLevelDescription"],
                            EndDate = (string)value["EndDate"]
                        });
                    }

                    return Ok(warrantyList);
                }
            }
            warrantyList.Add(new Warranty { Type = "Warranty information could not be retrieved", EndDate = "" });
            return BadRequest(warrantyList);
        }
    }
}