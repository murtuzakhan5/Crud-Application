using Microsoft.EntityFrameworkCore;

namespace Crud.Models
{
    public class ApplicationDbcontext:DbContext
    {
        public  ApplicationDbcontext(DbContextOptions options ):base(options){
        }
        
        public DbSet<Student> students { get; set; }
    }
}
