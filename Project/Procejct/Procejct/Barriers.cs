using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Procejct
{
    public class Barriers
    {
        public List<LoadBarrier> data { get; set; }
    }

    public class LoadBarrier
    {
        public int x { get; set; }

        public int y { get; set; }

        public int angle { get; set; }

        public string texture { get; set; }

        public int density { get; set; }

        public LoadBarrier()
        {
        
        }
    }
}
