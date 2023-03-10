namespace AirlineAPI.Models
{
    public class Airline
    {


        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? FlightNo { get; set; }
        public String? From { get; set; }
        public String? To { get; set; }
        public String? Seat { get; set; }

    }
}
