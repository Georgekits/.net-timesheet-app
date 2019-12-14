﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Models
{
    [Table("TimesheetEntries")]
    public class TimesheetEntry
    {
        public int Id { get; set; }
        public MyUser RelatedUser { get; set; }


        [ForeignKey("RelatedProjectId")]
        [DisplayName("Project")]
        public virtual Project RelatedProject { get; set; }
        public int RelatedProjectId { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Date)]
        [DisplayName("Timesheet Date")]
        public DateTime DateCreated { get; set; }
        [Column(TypeName = "int")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Hours of Work")]
        public int HoursWorked { get; set; }
    }
}