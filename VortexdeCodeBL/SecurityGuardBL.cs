using VortexdeCodeDL.Data;
using VortexdeCodeDL.Entitys;
using VortexdeCodeDL.Models;
using VortexdeCodeDL.UnitOfWork;

namespace VortexdeCodeBL
{
    public class SecurityGuardBL: ISecurityGuardBL
    {
        internal VortexDBContext context;
        private UnitOfWork unitOfWork ;
        

        public SecurityGuardBL(VortexDBContext context)
        {
            this.context = context;
            unitOfWork = new UnitOfWork(context);
        }

        IQueryable<Object> ISecurityGuardBL.testMethod()
        {
            IQueryable<Answer> answerList;
            try
            {

                Issue issue = new Issue()
                {
                    Title = "test",
                    Priority = Priority.High

                };


               //var courses = unitOfWork.FloorRepository.Get(includeProperties: "Title");
                //var course = unitOfWork.IssueRepository.GetByID(3);
                var floorList = unitOfWork.FloorRepository.Get();
                var questionList = unitOfWork.QuestionRepository.Get();
                answerList = unitOfWork.AnswerRepository.Get().Where(i => i.Question.FloorID == 1).ToList().AsQueryable();
                // Adding a new Entity, for example "Person"
               // var list = answerList;

            }
            catch (Exception)
            {

                throw;
            }
            return answerList;
        }
        IEnumerable<Floor> ISecurityGuardBL.getFloors()
        {
        
            try
            {


                IEnumerable<Floor> floorList = unitOfWork.FloorRepository.Get();

                return floorList;
                  
            }
            catch (Exception)
            {

                throw;
            }
        }

        QuestionAnswerModel ISecurityGuardBL.getQuestionAnswerById(int FloorID)
        {
            QuestionAnswerModel objModel= new QuestionAnswerModel();
            
            try
            {
                int hour = TimeOnly.FromDateTime(DateTime.Now).Hour;
                TimeSlot obj = unitOfWork.TimeSlotRepository.Get(x=>x.HourValue== hour).First();
                objModel.Hour = obj.Hour;
                objModel.TimeSlotId = obj.Id;

                IEnumerable<Question> questionList = unitOfWork.QuestionRepository.Get(x=>x.FloorID== FloorID && x.Is_Actve== true);
                foreach (Question item in questionList)
                {
                    List<AnswerModel> anslst = new List<AnswerModel>();
                    objModel.QuestionList.Add(new QuestionModel
                    {
                        Id = item.Id,
                        QuestionWord = item.QuestionWord,
                        AnswerList= (from ans in unitOfWork.AnswerRepository.Get(x => x.QuestionID == item.Id && x.Is_Actve == true)
                                            select new AnswerModel { Id = ans.Id, AnswerWord = ans.AnswerWord }).ToList()

                    });



                }



            }
            catch (Exception)
            {

                throw;
            }
            return objModel;
        }
       


    }
}