using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLogic;
using BusinessEntittes;

namespace BussinessLogic
{
    public class EmployeeBal
    {
        public List<EmployeeDto> GetEmployeeSalaries(EmployeeDto empDto)
        {            
            EmployeeDal empDal = new EmployeeDal();
            List<EmployeeDto> lst= empDal.GetSalaries(empDto);           
            return lst;
        }

        public List<EmployeeDto> GetEmployees(string search)
        {
            List<EmployeeDto> empDto = new List<EmployeeDto>();
            EmployeeDal empDal = new EmployeeDal();
            return empDto= empDal.GetEmployees(search);
        }
        
    }
}
