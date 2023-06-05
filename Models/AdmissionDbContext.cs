using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lastadmissionproject.Models
{
    public class AdmissionDbContext : DbContext
    {
        
        public AdmissionDbContext() : base("DBConnectionStr")
        {

        }
        public DbSet<ApplicantDetail> ApplicantDetails { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<MeritList> MeritLists { get; set; }
        public virtual DbSet<Allotment> Allotments { get; set; }
        public virtual DbSet<AdmissionFee> Fees { get; set; }
        public virtual DbSet<Login> UserLogin { get; set; }
        
    }
}
