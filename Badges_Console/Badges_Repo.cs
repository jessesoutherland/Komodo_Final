using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Console
{
    public class Badges_Repo
    {
        private readonly Dictionary<int, Badges> _badgeDirectory = new Dictionary<int, Badges>();

        //create
        public bool AddNewBadge(Badges badges)
        {
            int startingCount = _badgeDirectory.Count;
            
            _badgeDirectory.Add(badges.BadgeID, badges);

            bool wasAdded = (_badgeDirectory.Count > startingCount) ? true : false;

            return wasAdded;
        }
        public bool AddDoors(int badgeID, string newDoor)
        {
            Badges targetBadge = GetBadgeByID(badgeID);
            int startingCount = targetBadge.DoorNames.Count();

            targetBadge.DoorNames.Add(newDoor);

            bool wasAdded = (targetBadge.DoorNames.Count > startingCount) ? true : false;

            return wasAdded;
        }
        
        //show
        public Dictionary<int, Badges> ShowAllBadges()
        {
            return _badgeDirectory;
        }
        public Badges GetBadgeByID(int badgeID)
        {
            return _badgeDirectory[badgeID];
        }
        public string GetDoorsByID(int badgeID)
        {
            Badges targetBadge = GetBadgeByID(badgeID);
            if (targetBadge != null)
            {
                return string.Join(", ", targetBadge.DoorNames);
            }
            return "Badge Not Found";
        }
        
        //delete
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
