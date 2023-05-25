using Flyhigh_Airlines.Models;

namespace Flyhigh_Airlines.Repository
{
    public interface IFlight
    {
        public IEnumerable<Flights> GetFlights();
        public Flights GetFlightById(int id);
        public Flights PostFlight(Flights fl);
        public Flights PutFlight(int id,Flights fl);
        public Flights DeleteFlight(int id);
    }
}
