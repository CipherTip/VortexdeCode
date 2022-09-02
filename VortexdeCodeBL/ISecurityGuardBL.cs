using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VortexdeCodeDL.Entitys;
using VortexdeCodeDL.Models;

namespace VortexdeCodeBL
{
    public interface ISecurityGuardBL
    {
        IQueryable<Object> testMethod();
        IEnumerable<Floor> getFloors();
        QuestionAnswerModel getQuestionAnswerById(int FloorID);
    }
}
