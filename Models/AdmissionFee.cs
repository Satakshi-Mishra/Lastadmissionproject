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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentId { get; set; }



        [ForeignKey("Allotment")]
        public int AllocationId { get; set; }
        public virtual Allotment Allotment { get; set; }


        [ForeignKey("ApplicantDetail")]
        public int CandidateId { get; set; }
        public virtual ApplicantDetail ApplicantDetail { get; set; }

        public string FullName { get; set; }

        public string CourseName { get; set; }

        
        [DisplayFormat(DataFormatString = "₹{0}")]
        public decimal FeesAmount { get; set; }

        public string FeesStatus { get; set; }

        public string PaymentMode { get; set; }

        public string CardType { get; set; }

        [RegularExpression(@"^\d{16}$", ErrorMessage = "Please enter a valid 16-digit Card Number.")]
        public long CardNumber { get; set; }

        [RegularExpression(@"^\d{3}$", ErrorMessage = "Please enter a valid 3-digit CVV.")]

        public int CVV { get; set; }

        public DateTime PaymentDate { get; set; }

    }
}