using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Core
{
    public class StudentRepository : IRepository<Student>
    {
        private WebAppDBContext context;

        public StudentRepository()
            : this(new WebAppDBContext())
        {
        }
        
        public StudentRepository(WebAppDBContext _context)
        {
            this.context = _context;
        }

        public Student Get(long id)
        {
            return context.Student.Where(s => s.StudentId == id).FirstOrDefault();
        }
        public void InsertOrUpdate(Student Student)
        {
            if (Student.StudentId == default(long))
            {
                // New entity
                context.Student.Add(Student);
            }
            else
            {
                // Existing entity
                context.Entry(Student).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public Task<int> Save()
        {
            return context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            Student del = await context.Student.FindAsync(id);
            InsertOrUpdate(del);
            await Save();
        }
        //
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
