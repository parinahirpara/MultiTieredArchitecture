﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.Data.Models
{
    public class MyDataTableRequest
    {
        public string Draw { get; set; }
        public string Start { get; set; }
        public string Length { get; set; }
        public string? SearchValue{ get; set; }
    }
}