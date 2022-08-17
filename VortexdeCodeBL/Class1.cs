using VortexdeCodeDL.Data;
using VortexdeCodeDL.Models;
using VortexdeCodeDL.UnitOfWork;

namespace VortexdeCodeBL
{
    public class Class1: Interface1
    {
        internal VortexDBContext context;
        private UnitOfWork unitOfWork ;
        

        public Class1(VortexDBContext context)
        {
            this.context = context;
            unitOfWork = new UnitOfWork(context);
        }

        void Interface1.testMethod()
        {
            try
            {

                Issue issue = new Issue()
                {
                    Title = "test",
                    Priority = Priority.High

                };


               var courses = unitOfWork.IssueRepository.Get(includeProperties: "Title");
                var course = unitOfWork.IssueRepository.GetByID(3);

                // Adding a new Entity, for example "Person"


            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}