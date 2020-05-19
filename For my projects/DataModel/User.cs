using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_my_projects
{
    public class User
    {
        int id;
        String name;
        bool isTeacher;
        int classId;
        int statusId;
        int p;
        int c;

        public bool IsTeacher
        {
            get {
                return isTeacher;
            }
        }

        public int ClassId {
            get {
                return classId;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public int StatusId
        {
            get
            {
                return statusId;
            }
            set {
                statusId = value;
            }
        }

        public int P
        {
            get
            {
                return p;
            }
        }

        public int C
        {
            get
            {
                return c;
            }
        }

        public User(int id, int isTeacher, String name, int statusId, int classId) {
            this.id = id;
            this.name = name;
            if (isTeacher == 0)
                this.isTeacher = false;
            else
                this.isTeacher = true;
            this.classId = classId;
            this.statusId = statusId;
            this.p = 0;
            this.c = 0;
        }

        public override string ToString()
        {
            return name;
        }

        public void addP()
        {
            p++;
        }

        public void addC()
        {
            c++;
        }
    }
}
