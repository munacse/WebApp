using System;

namespace WebApp.Core
{
    public class UnitOfWork : IDisposable
    {
        private WebAppDBContext context;

        public UnitOfWork()
        {
            context = new WebAppDBContext();
        }

        public UnitOfWork(WebAppDBContext _context)
        {
            this.context = _context;
        }
        //
        private StudentRepository _studentRepository;

        public StudentRepository StudentRepository
        {
            get
            {
                if (this._studentRepository == null)
                {
                    this._studentRepository = new StudentRepository(context);
                }
                return _studentRepository;
            }
        }
        //

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
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
