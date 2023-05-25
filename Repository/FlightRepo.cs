using Flyhigh_Airlines.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Flyhigh_Airlines.Repository
{
    public class FlightRepo:IFlight
    {
        private readonly FlyhighContext context;
        public FlightRepo(FlyhighContext context)
        {
            this.context = context;
        }

        public Flights DeleteFlight(int id)
        {
            Flights fli = context.Flights.FirstOrDefault(x => x.Fid == id);
            context.Remove(fli);
            context.SaveChanges();
            return fli;
        }

        public Flights GetFlightById(int id)
        {
            return context.Flights.FirstOrDefault(x => x.Fid == id);
        }

        public IEnumerable<Flights> GetFlights()
        {
            return context.Flights.ToList();
        }

        public Flights PostFlight(Flights fl)
        {
            context.Add(fl);
            context.SaveChanges();
            return fl;
        }

        public Flights PutFlight(int id, Flights fl)
        {
            context.Entry(fl).State = EntityState.Modified;
            context.SaveChanges();
            return fl;
        }
    }
}
