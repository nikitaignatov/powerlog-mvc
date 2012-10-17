using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PowerLog.Model
{
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
