using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace For_my_projects.DataModel
{

    public class Answer
    {
        private int userId;
        private int questionId;
        private List<Int32> answers;

        public int UserId
        {
            get
            {
                return userId;
            }
        }

        public int QuestionId
        {
            get
            {
                return questionId;
            }
        }

        public List<Int32> Answers {
            get
            {
                return answers;
            }
        }

        public Answer(int userId, int questionId, List<Int32> answers) {
            this.userId = userId;
            this.questionId = questionId;
            this.answers = answers;
        }

        public int getAnswerAt(int index) {
            return answers.ElementAt(index);
        }

        public bool contains(int id) {
            return answers.Contains(id);
        }
    }
}
