using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace Essi.Models
{
    /// <summary>
    /// Student, which inherits from the default application user class.
    /// </summary>
    public class StudentUser : ApplicationUser
    {
        [Display(Name = "Student")]
        public string StudentNumber { get; set; }

        /// <summary>
        /// Course the student is attending.
        /// </summary>
        public virtual Course Course { get; set; }

        public StudentUser()
        {

        }

        public StudentUser(string studentNumber) : base(studentNumber)
        {
            this.StudentNumber = studentNumber;
        }
    }
}