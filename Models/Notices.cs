using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lastadmissionproject.Models
{
    public class Notices
    {

        [Key]  //primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoticeId { get; set; }

        public string NoticeName { get; set; }

        public string NoticeDescription { get; set;}

        public DateTime NoticeCreated { get; set; }
    }
}