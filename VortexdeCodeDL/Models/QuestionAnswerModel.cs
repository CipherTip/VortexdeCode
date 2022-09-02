using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexdeCodeDL.Models
{
    public class QuestionAnswerModel
    {
        public int TimeSlotId { get; set; }
        public string Hour { get; set; }
        public QuestionAnswerModel()
        {
            QuestionList = new List<QuestionModel>();
        }


       public   List<QuestionModel> QuestionList { get; set; }


    }


    public class QuestionModel
    {
        public int Id { get; set; }
        public string QuestionWord { get; set; }

        public List<AnswerModel> AnswerList { get; set; }

    }
    public class AnswerModel
    {
        public int Id { get; set; }
        public string AnswerWord { get; set; }
    }

}
