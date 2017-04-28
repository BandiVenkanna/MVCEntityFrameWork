using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntittes
{
    public class RegistrationDto
    {
        [Required]
        [Display(Name = "Emplyoyee Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        public int phoneNo { get; set; }
        [Required(ErrorMessage = "Employee Adress is Required")]
        [StringLength(500)]
        public string Adress { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}",ErrorMessage ="Enter correct valid password")]
        public string password { get; set; }
        [Required(ErrorMessage ="Enter Conform password")]
        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage ="Passwor must Equql to Conform password")]
        public string ConformPassword { get; set; }
    }
}
