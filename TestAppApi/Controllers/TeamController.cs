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
    [Route("api/Team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ApiDbContext db;

        public TeamController(ApiDbContext context)
        {
            db = context;

            if (db.Teams.Count() == 0)
            {
                db.Teams.Add(new Team
                {
                    Id = 1,
                    Name = "Carolina Panthers",
                    Location = "North Carolina"                    
                }); 
                db.SaveChanges();
            }
        }



        // GET: api/Teams
        [HttpGet("GetTeams")]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return await db.Teams.ToListAsync();
        }

        // GET api/Team/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int Id)
        {
            var team = await db.Teams.FindAsync(Id);
            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        //POST : api/Team
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team item)
        {
            db.Teams.Add(item);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeam), new { id = item.Id }, item);
        }

        //PUT : api/Team/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            db.Entry(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE : api/Team/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await db.Teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            db.Teams.Remove(team);
            await db.SaveChangesAsync();

            return NoContent();
        }      
    }
}
