﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Models
{
    class Degree
    {
        public int Id { get; set; }
        public Nullable<int> QualificationId { get; set; }
        public string DegreeName { get; set; }
    }
}
