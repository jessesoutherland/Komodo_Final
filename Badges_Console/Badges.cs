using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Console
{
    public class Badges
    {
        public Badges() { }
        public Badges(int badgeID, List<string> doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
        }
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
    }
}
