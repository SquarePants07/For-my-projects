using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_my_projects
{
    class User
    {
        int id;
        String name;
        bool isTeacher;
        int classId;
        int statusId;

        public bool IsTeacher
        {
            get {
                return isTeacher;
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
        }
    }
}
