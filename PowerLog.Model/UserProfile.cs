using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PowerLog.Model
{
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        private WeightUnit _weightUnits;

        [Required]
        public int WeightUnitsValue
        {
            get { return (int)_weightUnits; }
            set { _weightUnits = (WeightUnit)value; }
        }

        public WeightUnit WeightUnits
        {
            get { return _weightUnits; }
            set { _weightUnits = value; }
        }
    }
}
