using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreDataInDB.Models
{
    public class StudentContext : DbContext
    {
        
        /*public StudentContext(DbContextOptions<StudentContext> options):base(options)
{

}*/

        public StudentContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<StudentModel> StudentData  { get; set; }
    
    }
}
