﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel.Configuration.CourtType
{
    public class GetCourtTypeVM
    {
        public int ID { get; set; }
        public string NameE { get; set; }
        public string NameB { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
    }
}
