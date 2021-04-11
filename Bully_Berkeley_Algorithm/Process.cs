using System;
using System.Collections.Generic;
using System.Text;

namespace Bully_Berkeley_Algorithm
{
    public class Process
    {
        public int Process_id { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public int Counter { get; set; }
        public bool Is_Coordinator { get; set; }

        public bool Is_Frozen { get; set; }
    }
}
