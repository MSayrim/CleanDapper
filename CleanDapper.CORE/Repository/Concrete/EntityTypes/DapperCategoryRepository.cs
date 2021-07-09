using CleanDapper.CORE.Entity.Concrete;
using CleanDapper.CORE.Repository.Abstract.EntityTypes;
using CleanDapper.CORE.Repository.Concrete.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CleanDapper.CORE.Repository.Concrete.EntityTypes
{
    public class DapperCategoryRepository : DapperBaseRepository<Category>, IDapperCategoryRepository
    {

        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public DapperCategoryRepository(IConfiguration config) : base(config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString(_connectionString);
        }

        public List<Category> Query<Category>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(_connectionString))
                {
                    return conn.Query<Category>(query, parameters).ToList();
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return new List<Category>();
            }
        }

        public List<Category> QueryGetALL<Category>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(_connectionString))
                {
                    return conn.Query<Category>(query, parameters).ToList();
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return new List<Category>();
            }
        }

        public Category QueryGetByID<Category>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(_connectionString))
                {
                    return conn.QueryFirstOrDefault<Category>(query, parameters);
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return default; //Or however you want to handle the return
            }
        }

        public List<Category> SearchByFirstName<Category>(string query, object parameters = null)
        {

            try
            {
                using (SqlConnection conn
                       = new SqlConnection(_connectionString))
                {
                    return conn.Query<Category>(query, parameters).ToList();
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return default; //Or however you want to handle the return
            }
        }


        public bool Create<Category>(string query, object parameters = null)
        {

            try
            {
                using (SqlConnection conn
                       = new SqlConnection(_connectionString))
                {
                    if (conn.Execute(query, parameters) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update<Category>(string query, object parameters = null)
        {

            try
            {
                using (SqlConnection conn
                       = new SqlConnection(_connectionString))
                {
                    if (conn.Execute(query, parameters) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete<Category>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(_connectionString))
                {
                    if (conn.Execute(query, parameters) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
