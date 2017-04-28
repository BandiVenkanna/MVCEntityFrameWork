using BusinessEntittes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataLogic
{
    public class RegistrationDal
    {
        public void CreteEmpReg(EmployeeRegDto dto)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString);
            SqlCommand cmd = new SqlCommand("spInsertRegistration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Age", dto.Age);
            cmd.Parameters.AddWithValue("@CityId", dto.CityId);
            cmd.Parameters.AddWithValue("@CountryId", dto.CountryId);
            cmd.Parameters.AddWithValue("@DateOfBirth", dto.DateOfBirth);
            cmd.Parameters.AddWithValue("@EMail", dto.EMail);
            cmd.Parameters.AddWithValue("@Gender", dto.Gender);
            cmd.Parameters.AddWithValue("@Mobile", dto.Mobile);
            cmd.Parameters.AddWithValue("@Name", dto.Name);
            cmd.Parameters.AddWithValue("@Password", dto.Password);
            cmd.Parameters.AddWithValue("@StateId", dto.StateId);
            cmd.Parameters.AddWithValue("@KTechnologyId", dto.KnownTechnologies);
            cmd.Parameters.AddWithValue("@KnownLanguages", dto.KnownLanguages);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public List<ListItem> GetCountries()
        {
            List<ListItem> lstCounties = new List<ListItem>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString);
            SqlCommand cmd = new SqlCommand("spGetCountries", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ListItem County;
            while (dr.Read())
            {
                County = new ListItem();
                County.Id = Convert.ToString(dr["CountryId"]);
                County.Value = Convert.ToString(dr["CountryName"]);
                lstCounties.Add(County);
            }

            return lstCounties;
        }

        public List<ListItem> GetStatesByCountryId(int id)
        {
            List<ListItem> lstStates = new List<ListItem>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString);
            SqlCommand cmd = new SqlCommand("spGetStatesByCountryId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CountryId", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ListItem State;
            while (dr.Read())
            {
                State = new ListItem();
                State.Id = Convert.ToString(dr["StateId"]);
                State.Value = Convert.ToString(dr["StateName"]);
                lstStates.Add(State);
            }
            return lstStates;
        }

        public List<ListItem> GetCitiesByStateId(int id)
        {
            List<ListItem> lstCitiess = new List<ListItem>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString);
            SqlCommand cmd = new SqlCommand("spGetCitiesByStateId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateId", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ListItem City;
            while (dr.Read())
            {
                City = new ListItem();
                City.Id = Convert.ToString(dr["CityId"]);
                City.Value = Convert.ToString(dr["CityName"]);
                lstCitiess.Add(City);
            }
            return lstCitiess;
        }

        public List<ListItem>GetTechlogies()
        {
            List<ListItem> lst = new List<ListItem>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString);
            SqlCommand cmd = new SqlCommand("spGetTechnologies", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ListItem techology;
            while (dr.Read())
            {
                techology = new ListItem();
                techology.Id = Convert.ToString(dr["KTechnologyId"]);
                techology.Value = Convert.ToString(dr["Technology"]);
                lst.Add(techology);
            }

            return lst;
        }
    }
}
