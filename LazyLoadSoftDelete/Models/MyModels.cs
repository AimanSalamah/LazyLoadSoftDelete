using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LazyLoadSoftDelete.Models
{
    public class Main
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Sub> Sub { get; set; }
        public bool Deleted { get; set; }
    }
    public class Sub
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public int MainID { get; set; }
        public virtual Main Main { get; set; }
    }
}