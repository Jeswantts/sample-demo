using Flyhigh_Airlines.Models;
using Flyhigh_Airlines.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Flyhigh_Airlines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlight flight;
        public FlightController(IFlight flight)
        {
            this.flight = flight;
        }
        [HttpGet]
        public IEnumerable<Flights> Get()
        {
            return flight.GetFlights();
        }
        [HttpGet("{id}")]

        public Flights GetId(int id)
        {
            return flight.GetFlightById(id);
        }

        [HttpPost]
        public Flights Post(Flights fl)
        {
            return flight.PostFlight(fl);
        }
        [HttpPut]
        public Flights Put(int id, Flights fl)
        {
            return flight.PutFlight(id,fl);
        }
        [HttpDelete]
        public Flights Delete(int id)
        {
            return flight.DeleteFlight(id);
        }
    }
}
