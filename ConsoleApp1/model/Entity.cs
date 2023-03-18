using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    [Serializable]
    public class Entity<Id>
    {
        public Id id { get; set; }

        public override string ToString()
        {
            return "Entity: {id = " + id + "}";
        }
    }
}