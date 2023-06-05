using DomainLayer.Models;
using DomainLayer.Models.Request;
using DomainLayer.Models.Response;
using Microsoft.Data.SqlClient;

using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Repository
{
    public class CountryRepo : ICountryInfoRepo
    {
        private SqlConnection connection =
                new SqlConnection("Server=DESKTOP-MV6UQ21\\SQLEXPRESS;Database=onionarcDb;Trusted_Connection=True;MultipleActiveResultSets=True;");

        //Get All
        public List<CreateCountry> GetAll()
        {
            var allCountry = new List<CreateCountry>();

            try
            {
                var command = new SqlCommand("Exec GeTAllCountry  ", connection);
            //command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue( "get","@partName");

            connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var country = new CreateCountry();
                     country.Id = Convert.ToInt32(reader["Id"]);
                     country.Name = reader["name"].ToString();
                     country.dteCreatedAt = Convert.ToDateTime(reader["dteCreatedAt"]);
                     country.CreatedBy = reader["CreatedBy"].ToString();
                     country.strUpdatedBy = reader["strUpdatedBy"] == null ? "" : reader["strUpdatedBy"].ToString();
                     country.dteUpdatedAt = reader["dteUpdatedAt"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["dteUpdatedAt"]);
                     country.isActive = (bool)reader["isActive"];
                     allCountry.Add(country);
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return allCountry;
        }

        //GetById
        public CreateCountry GetById(int id)
        {
            var country = new CreateCountry();

            try
            {
                var command = new SqlCommand("Exec GetCountry @Id='" + id + "'", connection);

                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //country.Id = Convert.ToInt32(reader["id"]);
                    country.Name = reader["name"].ToString();
                    country.dteCreatedAt = Convert.ToDateTime(reader["dteCreatedAt"]);
                    country.CreatedBy = reader["CreatedBy"].ToString();
                    country.strUpdatedBy = reader["strUpdatedBy"] == null ? "" : reader["strUpdatedBy"].ToString();
                    country.dteUpdatedAt = reader["dteUpdatedAt"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["dteUpdatedAt"]);
                    country.isActive = (bool)reader["isActive"];
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return country;
        }

        //Create
        public int Create(CreateCountry crate)
        {
            int rowsAffected = 0;
            try
            {
                var command = new SqlCommand("exec onionarcDb.dbo.spInsertCountry @strName='" + crate.Name +"', @strCreatedBy='" + crate.CreatedBy + "', @strCreatedAt='" + crate.dteCreatedAt + "', @dteUpdatedAt='" + crate.dteUpdatedAt + "', @isActive='" + crate.isActive + " ', @strUpdatedBy='" + crate.strUpdatedBy + "'", connection);
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return rowsAffected;
        }
        public int Update(int id, UpadteCountry upadteCountry)
        {
            int rowsAffected = 0;
            try
            {
               var command = new SqlCommand("exec onionarcDb.dbo.spUpdateCountryInfo @Id='"+id+"', @strName='" + upadteCountry.Name + "', @strCreatedBy='" + upadteCountry.CreatedBy + "', @strCreatedAt='" + upadteCountry.dteCreatedAt + "', @dteUpdatedAt='" + upadteCountry.dteUpdatedAt + "', @isActive='" + upadteCountry.isActive + " ', @strUpdatedBy='" + upadteCountry.strUpdatedBy + "'", connection); connection.Open();
               rowsAffected = command.ExecuteNonQuery();
               connection.Close();
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            finally
            {
               if (connection.State == ConnectionState.Open)
               {
                  connection.Close();
               }
            }
            return rowsAffected;
      }
    }
}