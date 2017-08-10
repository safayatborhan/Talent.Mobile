using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Models
{
    public class Onsite
    {
        public int Id { get; set; }
        public Nullable<int> ProfessionalId { get; set; }
        public string OnsiteDetails { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> ContactDetails { get; set; }
        public string Location { get; set; }
        public Nullable<byte> IsDelete { get; set; }
        public Nullable<int> QId { get; set; }
        public Nullable<int> OptionId { get; set; }
    }
}
