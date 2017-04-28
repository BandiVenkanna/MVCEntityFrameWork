using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntittes
{
    public class EmployeeDto
    {
        [Required]
        public int AccountNo { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public int Operator { get; set; }

    }
}
