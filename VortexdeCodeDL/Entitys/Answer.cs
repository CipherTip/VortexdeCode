using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexdeCodeDL.Entitys
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerWord { get; set; }
        public Boolean Is_Actve { get; set; }
        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        public Question Question { get; set; }



    }
}
