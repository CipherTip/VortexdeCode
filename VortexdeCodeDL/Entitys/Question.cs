using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexdeCodeDL.Entitys
{
    public  class Question
    {
        public int Id { get; set; }
        public string QuestionWord { get; set; }

        [ForeignKey("Floor")]
        public int FloorID { get; set; }
        public Floor Floor { get; set; }
        public Boolean Is_Actve { get; set; }
    }
}
