using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAppApi.Models;

namespace TestAppApi.Helpers
{
    public class TeamHelper
    {
        private readonly ApiDbContext db;

        public bool IsUserOnTeam(int userId, int teamId)
        {
            var team = db.Players.Find(teamId);
            var flag = team.Team.Players.Any(u => u.Id == userId);
            return (flag);
        }

        public void AddUserToTeam(int userId, int teamId)
        {
            if(!IsUserOnTeam(userId, teamId))
            {
                Team team = db.Teams.Find(teamId);
                var newUser = db.Players.Find(userId);

                team.Players.Add(newUser);
                db.SaveChanges();
            }
        }

        public void RemoveUserFromTeam(int userId, int teamId)
        {
            if(IsUserOnTeam(userId, teamId))
            {
                Team team = db.Teams.Find(teamId);
                var delUser = db.Players.Find(userId);

                team.Players.Remove(delUser);
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();                    
            }
        }
    }
}
