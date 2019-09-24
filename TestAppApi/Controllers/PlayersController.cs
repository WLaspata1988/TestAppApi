using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAppApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAppApi.Controllers
{
    [Route("api/Players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly ApiDbContext db;

        public PlayersController(ApiDbContext context)
        {
            db = context;

            if (db.Players.Count() == 0)
            {
                db.Players.Add(new Players {
                    Id = 1,
                    TeamId = 1,
                    FirstName = "Cam",
                    LastName = "Newton",
                    Number = 1,
                    Position = "QB"                    
                });                
                db.SaveChanges();               
            }
        }
        // GET: api/Players
        [HttpGet("GetPlayers")]
        public async Task<ActionResult<IEnumerable<Players>>> GetPlayers()
        {
            return await db.Players.ToListAsync();
        }

        // GET api/Player/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Players>> GetPlayer(int Id)
        {
            var Player = await db.Players.FindAsync(Id);
            if (Player == null)
            {
                return NotFound();
            }

            return Player;
        }
        
        //POST : api/Player
        [HttpPost]
        public async Task<ActionResult<Players>> PostPlayer(Players item)
        {
            db.Players.Add(item);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayer), new { id = item.Id }, item);
        }

        //PUT : api/Player/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, Players item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return NoContent();
        }

        //DELETE : api/Players/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await db.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            db.Players.Remove(player);
            await db.SaveChangesAsync();

            return NoContent();
        }        
    }
}
