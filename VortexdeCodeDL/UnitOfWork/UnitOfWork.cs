using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VortexdeCodeDL.Data;
using VortexdeCodeDL.Models;
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
        //private GenericRepository<Course> courseRepository;



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

        //public GenericRepository<Course> CourseRepository
        //{
        //    get
        //    {

        //        if (this.courseRepository == null)
        //        {
        //            this.courseRepository = new GenericRepository<Course>(context);
        //        }
        //        return courseRepository;
        //    }
        //}

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
