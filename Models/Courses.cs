using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Lastadmissionproject.Models
{
    public class Courses
    {
        [Key ]  //primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]

        public int SeatAvailable { get; set; }

        [Required]
        [MaxLength(200)]

        public string Description { get; set; }

        
        public int CutOff { get; set; }

        //one to many relation between courses table and allotment as well as appicants table
        public ICollection<Allotment> Allotment { get; set; }

        public ICollection<ApplicantDetail> ApplicantDetails { get; set; }
    }
}