//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;

//namespace Essi.Models
//{
//    //public class Exercise
//    //{
//    //    public int ID { get; set; }

//    //    [Display(Name = "Exercise Name")]
//    //    public string Name { get; set; }

//    //    public int MinPoints { get; set; }

//    //    public int MaxPoints { get; set; }

//    //    public bool IsRequired { get; set; }

//    //    public bool IsBonus { get; set; }
//    //}

//    public class ExerciseRound
//    {
//        public int ID { get; set; }

//        public int CourseID { get; set; }

//        public string Name { get; set; }

//        public virtual Course Course { get; set; }
//    }
//}