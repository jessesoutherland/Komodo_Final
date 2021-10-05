using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Console
{
    public class Claims_Repo
    {
        public readonly Queue<Claims> _claimsDirectory = new Queue<Claims>();

        //Create 
        public bool AddClaim(Claims claim)
        {
            int startingCount = _claimsDirectory.Count;

            _claimsDirectory.Enqueue(claim);

            bool wasAdded = (_claimsDirectory.Count > startingCount) ? true : false;

            return wasAdded;
        }
        
        //Read
        public Queue<Claims> ShowAllClaims()
        {
            return _claimsDirectory;
        }

        //Read next claim
        public Claims GetNextClaim()
        {
            return _claimsDirectory.Peek();
        } 
    }
}
