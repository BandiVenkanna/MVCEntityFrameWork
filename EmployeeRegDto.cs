using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntittes
{
    public class EmployeeRegDto
    {
        public EmployeeRegDto()
        {
            Languages = new List<CheckBoxListItem>();
        }

        public int RegId { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string KnownTechnologies { get; set; }
        public string KnownLanguages { get; set; }

        public List<CheckBoxListItem> Languages { get; set; }
        public string[] lstlanguages { get; set; }
    }

    public class CheckBoxListItem
    {
        public int ID { get; set; }
        public string Display { get; set; }
        public bool IsChecked { get; set; }

    }
}
