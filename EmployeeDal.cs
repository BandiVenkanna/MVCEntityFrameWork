using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntittes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataLogic
{

    public class EmployeeDal
    {
        string str = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
        public List<EmployeeDto> GetSalaries(EmployeeDto dto)
        {
            List<EmployeeDto> lstempdto = new List<EmployeeDto>();
            SqlConnection con = new SqlConnection("Data Source=VENKAT; Initial Catalog=JNET;User Id=sa;Password=welcome");
            SqlCommand cmd = new SqlCommand("uspGetEmployeeSalariesByOpetator", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            try
            {
                cmd.Parameters.AddWithValue("Operator", dto.Operator);
                cmd.Parameters.AddWithValue("Salary", dto.Salary);
                SqlDataReader dr = cmd.ExecuteReader();
                EmployeeDto empDto;
                while (dr.Read())
                {
                    empDto = new EmployeeDto();
                    empDto.AccountNo = Convert.ToInt32(dr["ACNO"]);
                    empDto.EmpName = Convert.ToString(dr["EMPNAME"]);
                    empDto.Salary = Convert.ToDecimal(dr["SALARY"]);
                    lstempdto.Add(empDto);
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                con.Close();
            }
            return lstempdto;
        }

        public List<EmployeeDto> GetEmployees(string search)
        {
            List<EmployeeDto> lstempdto = new List<EmployeeDto>();
            SqlConnection con = new SqlConnection("Data Source=VENKAT; Initial Catalog=JNET;User Id=sa;Password=welcome");
            SqlCommand cmd = new SqlCommand("spGetEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            try
            {
                //cmd.Parameters.AddWithValue("Operator", dto.Operator);
                cmd.Parameters.AddWithValue("@search", search);
                SqlDataReader dr = cmd.ExecuteReader();
                EmployeeDto empDto;
                while (dr.Read())
                {
                    empDto = new EmployeeDto();
                    empDto.AccountNo = Convert.ToInt32(dr["ACNO"]);
                    empDto.EmpName = Convert.ToString(dr["EMPNAME"]);
                    empDto.Salary = Convert.ToDecimal(dr["SALARY"]);
                    lstempdto.Add(empDto);
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                con.Close();
            }
            return lstempdto;
        }
    }
}
