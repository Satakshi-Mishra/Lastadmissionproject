using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lastadmissionproject.Models
{
    public class MeritList
    {
        [Key]  //primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeritId { get; set; }



        [ForeignKey("ApplicantDetail")]
        public int CandidateId { get; set; }
        public virtual ApplicantDetail ApplicantDetail { get; set; }
        public int HigherSecondaryAggregateMarks { get; set; }


        //rank will be given based on the marks
        public int Rank { get; set; }
    }
}