﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF2_FileCloud.Models
{
    public class Files
    {
        public int id_file { get; set; }
        public string name { get; set; }
        public string source { get; set; }
        public int owner { get; set; }
        public float size { get; set; }
    }
}
