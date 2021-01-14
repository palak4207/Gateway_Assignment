using HMS.BAL.Interface;
using HMS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace HMS.WebApi.Controllers
{
    public class HotelController : ApiController
    {
        private readonly IHotelManager _hotelManager;
        public HotelController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        // GET: api/Hotel
        public HttpResponseMessage Get()
        {
            var hotels= _hotelManager.GetAllHotel();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(hotels),Encoding.UTF8,"application/json")
            };
        }

        // GET: api/Hotel/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Hotel
        public HttpResponseMessage Post([FromBody] Hotel model)
        {
            var hotel = _hotelManager.CreateHotel(model);
            return new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent("Created Sucessfully", Encoding.UTF8, "application/JSON")
            };
        }

        // PUT: api/Hotel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Hotel/5
        public void Delete(int id)
        {
        }
    }
}
