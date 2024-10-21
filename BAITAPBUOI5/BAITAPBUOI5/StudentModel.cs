using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BAITAPBUOI5
{
    public partial class StudentModel : DbContext
    {
        public StudentModel()
            : base("name=StudentModel")
        {
        }

        public virtual DbSet<SinhVien> SinhVien { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SinhVien>()
                .Property(e => e.MSSV)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
