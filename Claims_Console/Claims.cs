using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Console
{
    public class Claims
    {
        public Claims() { }

        public Claims(int claimID, string claimType, string description, decimal amount, DateTime dateOfAccident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            Amount = amount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
        }
        public int ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                double days = (DateOfClaim - DateOfAccident).TotalDays;
                if (days > 0 && days <= 30)
                { 
                    return true;
                }
                else
                {
                    return false;
                }
            }
                
        }
    }
}
