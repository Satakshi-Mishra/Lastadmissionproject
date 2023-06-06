using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lastadmissionproject.Models
{
    public class Allotment
    {
        [Key]  //primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AllocationId { get; set; }

       // [ForeignKey("ApplicantDetail")]
        public int CandidateId { get; set; }
       public virtual ApplicantDetail ApplicantDetail { get; set; }


        [ForeignKey("Courses")]
        public int CourseId { get; set; }
        public virtual Courses Courses { get; set; }
    }
}