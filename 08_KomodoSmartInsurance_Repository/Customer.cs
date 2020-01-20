using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_KomodoSmartInsurance_Repository
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                string fullName = $"{FirstName} {LastName}";
                return fullName;
            }
        }
        public int FollowSpeedLimitSkill { get; set; }
        public int StayInLaneSkill { get; set; }
        public int FullStopSkill { get; set; }
        public int FollowingDistanceSkill { get; set; }
        public double Premium
        {
            get
            {
                double premium = FollowSpeedLimitSkill + StayInLaneSkill + FullStopSkill + FollowingDistanceSkill;

                if (premium <= 10)
                {
                    return 500;
                }
                else if (premium <= 20)
                {
                    return 400;
                }
                else if (premium <= 30)
                {
                    return 300;
                }
                else
                {
                    return 200;
                }
            }
        }

        public Customer() { }

        public Customer(string firstName, string lastName, int followSpeedLimitSkill, int stayInLaneSkill, int fullStopSkill, int followingDistanceSkill)
        {
            FirstName = firstName;
            LastName = lastName;
            FollowSpeedLimitSkill = followSpeedLimitSkill;
            StayInLaneSkill = stayInLaneSkill;
            FullStopSkill = fullStopSkill;
            FollowingDistanceSkill = followingDistanceSkill;
        }
    }
}
