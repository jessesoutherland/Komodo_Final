using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Console
{
    class Badges_Repo
    {
        private readonly Dictionary<int, Badges> _badgeDirectory = new Dictionary<int, Badges>();

        //create new badge
        public bool AddNewBadge(int badgeID, List<string> doors)
        {
            Badges newBadge = new Badges(badgeID, doors); //Why do I need this
            
            int startingCount = _badgeDirectory.Count;

            _badgeDirectory.Add(badgeID, newBadge); //Why doesn't doors work instead of newBadge

            bool wasAdded = (_badgeDirectory.Count > startingCount) ? true : false;

            return wasAdded;
        }

        //show all badges
        public Dictionary<int, Badges> ShowAllBadges()
        {
            return _badgeDirectory;
        }

        public Badges GetBadgeByID(int badgeID)
        {
            return _badgeDirectory[badgeID];
        }

        //add doors
        public bool AddDoors(int badgeID, List<string> newDoors)
        {
            Badges targetBadge = GetBadgeByID(badgeID);
            int startingCount = targetBadge.DoorNames.Count();

            targetBadge.DoorNames.AddRange(newDoors);

            bool wasAdded = (targetBadge.DoorNames.Count > startingCount) ? true : false;

            return wasAdded;
        }

        //delete doors
        public bool RemoveDoors(int badgeID, string door)
        {
            Badges targetBadge = GetBadgeByID(badgeID);
            int startingCount = targetBadge.DoorNames.Count();

            targetBadge.DoorNames.Remove(door);

            bool wasRemoved = (targetBadge.DoorNames.Count < startingCount) ? true : false;

            return wasRemoved;
        }
    }
}
