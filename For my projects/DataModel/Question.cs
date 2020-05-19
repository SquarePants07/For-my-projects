using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_my_projects.DataModel
{
    public class Question
    {
        int id;
        String text;
        bool isGood;
        public int Id
        {
            get
            {
                return id;
            }
        }

        public bool IsGood
        {
            get
            {
                return isGood;
            }
        }

        public Question(int id, String text, int isGood)
        {
            this.id = id;
            this.text = text;
            if (isGood == 0)
                this.isGood = false;
            else
                this.isGood = true;
        }

        public override string ToString()
        {
            return text;
        }
    }
}
