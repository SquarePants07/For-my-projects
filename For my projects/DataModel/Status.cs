using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_my_projects.DataModel
{
    public class Status
    {

        int id;
        String name;

        public int Id {
            get {
                return id;
            }
        }

        public String Name
        {
            get
            {
                return name;
            }
        }

        public Status(int id, String name) {
            this.id = id;
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
