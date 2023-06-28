using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Web.Mvc;

namespace Lastadmissionproject.Models
{
    [Authorize]
    public class ApplicantDetail
    {
        [Key]  //primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateId { get; set; }

        //data annotations

        [Required(ErrorMessage = "Name field is mandatory")]
        [Display(Name = "Candidate's Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Name field is mandatory")]
        [Display(Name = "Father's Name")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "Name field is mandatory")]
        [Display(Name = "Mother's Name")]
        public string MotherName { get; set; }

        
        [Required(ErrorMessage = "Email field is mandatory")]
        [EmailAddress(ErrorMessage = "Email field is invalid")]
        //[Index("IX_Email", IsUnique = true)]// Apply unique index on the email field 
        //unique email only
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "The password must be between 6 and 8 characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Mobile Number field is mandatory")]
        [RegularExpression(@"^([0-9]{10})", ErrorMessage = "Invalid Mobile Number")]

        public string Mobile { get; set; }

        [Display(Name = "Student Age")]
        [Required(ErrorMessage = "Age field is mandatory")]
        [Range(20, 22, ErrorMessage = "Age must be between 20 to 22")]

        public int Age { get; set; }

        [Required(ErrorMessage = "Marks field is mandatory")]
        [Range(0, 100, ErrorMessage = "Invalid Marks ")]
        [Display(Name = "Higher Secondary Aggregate Marks")]
        public int HigherSecondaryAggregateMarks { get; set; }

        //Authentication and authotrization will be done based on roles
        public string Role { get; set; }

        //rank will be given based on the marks
        public int Rank { get; set; }



        [Display(Name = "Course of Preference")]
        
        [ForeignKey("Courses")]  //many to one relation reference navigation
        public int CourseId { get; set; }
        public virtual Courses Courses { get; set; }

        //allotment status of student of their preferred course
        [Display(Name = "Course Allotment Status")]
        public string AllotmentStatus { get; set; }

        public string FeeStatus { get; set; }

    }
}