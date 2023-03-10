using AirlineAPI.Data;
using AirlineAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirlinesController : Controller
    {
        public AirlinesController(AirlineAPIDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public AirlineAPIDbContext DbContext { get; }

        [HttpGet]
        public async Task<IActionResult> GetAirlines()
        {
            return Ok(await DbContext.Airlines.ToListAsync());
            
        }

        [HttpGet]
        [Route("{Id:Guid}")]

        public async Task<IActionResult> GetAirline([FromRoute] Guid Id)
        {
            var airline = await DbContext.Airlines.FindAsync(Id);

            if(airline == null)
            {
                return NotFound();
            }

            return Ok(airline);
        }

        [HttpPost]
        public async Task<IActionResult> AddAirline(AddAirline addAirline)
        {
            var airline = new Airline()
            {
                Id = Guid.NewGuid(),
                Name = addAirline.Name,
                FlightNo = addAirline.FlightNo,
                From = addAirline.From,
                To = addAirline.To,
                Seat = addAirline.Seat,
            };

            await DbContext.Airlines.AddAsync(airline);
            await DbContext.SaveChangesAsync();

            return Ok(airline);
        }

        [HttpPut]
        [Route("{Id:Guid}")]

        public async Task<IActionResult> UpdateAirline([FromRoute] Guid Id, UpdateAirline updateAirline)
        {
            var airline = DbContext.Airlines.Find(Id);
            if (airline != null) 
            {
                airline.Name = updateAirline.Name;
                airline.FlightNo = updateAirline.FlightNo;
                airline.From = updateAirline.From;
                airline.To = updateAirline.To;
                airline.Seat = updateAirline.Seat;

                await DbContext.SaveChangesAsync();

                return Ok(airline);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> DeleteAirline([FromRoute] Guid Id)
        {
            var airline = await DbContext.Airlines.FindAsync(Id);
            if(airline != null)
            {
                DbContext.Remove(airline);
                await DbContext.SaveChangesAsync();
                return Ok(airline);
            }

            return NotFound();

        }
    }
}
