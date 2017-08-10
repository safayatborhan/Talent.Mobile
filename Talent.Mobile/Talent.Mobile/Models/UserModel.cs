using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Models.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Countries = new Dictionary<int, string>();
            States = new Dictionary<string, string>();

            Universities = new Dictionary<int, string>();
        }
        //public int Id { get; set; }

        //public string FirstName { get; set; }

        //public string MiddleName { get; set; }

        //public string LastName { get; set; }

        //public byte? Gender { get; set; }

        //public string Mobile { get; set; }

        //public string Email { get; set; }

        //public string Password { get; set; }

        //public string Address1 { get; set; }

        //public string Address2 { get; set; }

        //public string City { get; set; }

        //public int? StateId { get; set; }

        //public int? CountryId { get; set; }

        //public int? Pin { get; set; }

        //public string BioData { get; set; }

        //public string ProfileImage { get; set; }

        //public DateTime? CreatedDate { get; set; }

        //public DateTime? ModifiedDate { get; set; }

        //public int UserType { get; set; }

        //public int EmpId { get; set; } 

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Nullable<byte> Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> Pin { get; set; }
        public string BioData { get; set; }
        public string ProfileImage { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> UserType { get; set; }
        public Nullable<int> EmpId { get; set; }

        public Dictionary<int, string> Countries { get; set; }
        public Dictionary<string, string> States { get; set; }
        public int? UniversityId { get; set; }
        public Dictionary<int, string> Universities { get; set; }
    }

}
