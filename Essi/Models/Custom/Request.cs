using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Essi.Models
{
    /// <summary>
    /// Help request made by a student for the course assistant.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Status flag indicating whether the student has received aid.
        /// </summary>
        public enum RequestStatus
        {
            Waiting,
            Processing,
            Ready
        }

        public int ID { get; set; }
        public string StudentUserID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Creation Time")]
        public DateTime RequestCreatedTime { get; set; }

        public RequestStatus Status { get; set; }

        /// <summary>
        /// Exercise round where help is needed.
        /// </summary>
        [Display(Name = "Exercise Round")]
        public Course.ExerciseRoundEnum ExerciseRound { get; set; }

        public virtual StudentUser StudentUser { get; set; }
    }
}