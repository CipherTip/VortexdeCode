using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VortexdeCodeDL.Data;
using VortexdeCodeDL.Entitys;
using VortexdeCodeDL.Repository;

namespace VortexdeCodeDL.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private VortexDBContext context ;
        public UnitOfWork(VortexDBContext context)
        {
            this.context = context;
        }
        private GenericRepository<Issue> issueRepository;
        private GenericRepository<Floor> floorRepository;
        private GenericRepository<Question> questionRepository;
        private GenericRepository<Answer> answerRepository;
        private GenericRepository<TimeSlot> timeSlotRepository;


        public GenericRepository<Issue> IssueRepository
        {
            get
            {

                if (this.issueRepository == null)
                {
                    this.issueRepository = new GenericRepository<Issue>(context);
                }
                return issueRepository;
            }
        }

        public GenericRepository<Floor> FloorRepository
        {
            get
            {

                if (this.floorRepository == null)
                {
                    this.floorRepository = new GenericRepository<Floor>(context);
                }
                return floorRepository;
            }
        }
        public GenericRepository<Question> QuestionRepository
        {
            get
            {

                if (this.questionRepository == null)
                {
                    this.questionRepository = new GenericRepository<Question>(context);
                }
                return questionRepository;
            }
        }
        public GenericRepository<Answer> AnswerRepository
        {
            get
            {

                if (this.answerRepository == null)
                {
                    this.answerRepository = new GenericRepository<Answer>(context);
                }
                return answerRepository;
            }
        }

        public GenericRepository<TimeSlot> TimeSlotRepository
        {
            get
            {

                if (this.timeSlotRepository == null)
                {
                    this.timeSlotRepository = new GenericRepository<TimeSlot>(context);
                }
                return timeSlotRepository;
            }
        }



        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
