using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lastadmissionproject.Models
{
    public class AdmissionFee
    {
        [Key]  //primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }



        [ForeignKey("Allotment")]
        public int AllocationId { get; set; }
        public virtual Allotment Allotment { get; set; }

        



        [ForeignKey("ApplicantDetail")]
        public int CandidateId { get; set; }
        public virtual ApplicantDetail ApplicantDetail { get; set; }

        public int FeesAmount { get; set; }



        public string Fees_Status { get; set; }
    }
}