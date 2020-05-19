using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_my_projects
{
    public class PupilGroup
    {
        int id;
        String litera;
        int number;
        public int Id{
            get {
                return id;
            }
        }
        public PupilGroup(int id, String litera, int number) {
            this.id = id;
            this.litera = litera;
            this.number = number;
        }

        public override string ToString()
        {
            if (number != -1)
                return number + " " + litera;
            else
                return litera;
        }
    }
}
