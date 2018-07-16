﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnversityManagementSystem.Models
{
    public class Teacher
    {
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Name field must not be empty!")]
        [Display(Name = "Name")]
        public string TeacherName { get; set; }

         [DataType(DataType.MultilineText)]
         [Display(Name = "Address")]
        public string Address { get; set; }

        //[Required(ErrorMessage = "Teacher Email Address is required")]
        //[EmailAddress(ErrorMessage = "Please enter a valid email address!")]

         [Column(TypeName = "VARCHAR")]
        // [Index(IsUnique = true)]
         [StringLength(50)]
         [EmailAddress]
         [Remote("IsTeacherEmailAvailable", "Teacher", ErrorMessage = "This email already exist!")]
         [Display(Name = "Email")]
        public string Email { get; set; }


         [Phone(ErrorMessage = "Please provide correct Contact No format")]
         [Display(Name = "Contact No")]
         [DataType(DataType.PhoneNumber)]
         [RegularExpression(@"^\(?[+]([8]{2})([0]{1})([1]{1})([1-9]{1})([0-9]{8})$", ErrorMessage = "Invalid Phone number. Try this format (8801XXXXXXXXX)")]
        public string ContactNo { get; set; }

        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        public virtual Designation Desg { get; set; }

        [Display(Name = "Designation")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department d { get; set; }


        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Credit must be positive number")]
        [Display(Name = "Credit to be taken")]
        public double TakenCredit { get; set; }

        public double RemainingCredit { get; set; }


    }
}