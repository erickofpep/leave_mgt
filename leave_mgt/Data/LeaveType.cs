﻿using System.ComponentModel.DataAnnotations;

namespace leave_mgt.Data
{
    public class LeaveType
    {

        [Key]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

    }
}
