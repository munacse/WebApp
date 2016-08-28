using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Core
{
    public class WebAppDBContext : IdentityDbContext<ApplicationUser>
    {
        public WebAppDBContext()
            : base("SchoolContext")
        {
        }

        public static WebAppDBContext Create()
        {
            return new WebAppDBContext();
        }

        public DbSet<Student> Student { get; set; }
    }
}
