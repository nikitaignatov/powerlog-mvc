using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PowerLog.Model
{
    public class Exercise
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string BodyPart { get; set; }

        public string Utility { get; set; }

        public string Mechanics { get; set; }

        public string Force { get; set; }

        [Required]
        public string Url { get; set; }
    }

    public class MyClass : Exercise
    {

    }
}
