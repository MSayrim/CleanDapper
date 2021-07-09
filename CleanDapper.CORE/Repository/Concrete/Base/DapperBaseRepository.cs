using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using CleanDapper.CORE.Repository.Abstract.Base;
using CleanDapper.CORE.Entity.Abstract;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CleanDapper.CORE.Repository.Concrete.Base
{
    public class DapperBaseRepository<T> : IDapperBaseRepository<T> where T : class, IBaseEntity
    {

        private readonly IConfiguration _config;
        private string _connectionString = "DefaultConnection";

        public DapperBaseRepository(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString(_connectionString);
        }

        public List<T> Query<T>(string query, object parameters = null, CommandType commandType = CommandType.Text)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(_connectionString))
                {
                    return conn.Query<T>(query, parameters,commandType:commandType).ToList();
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return new List<T>();
            }
        }

        public List<T> QueryGetALL<T>(string query, object parameters = null, CommandType commandType = CommandType.Text)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(_connectionString))
                {
                    return conn.Query<T>(query, parameters,commandType:commandType).ToList();
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return new List<T>();
            }
        }

        public T QueryGetByID<T>(string query, object parameters = null, CommandType commandType = CommandType.Text)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(_connectionString))
                {
                    return conn.QueryFirstOrDefault<T>(query, parameters,commandType:commandType);
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return default; //Or however you want to handle the return
            }
        }

        public List<T> SearchByFirstName<T>(string query, object parameters = null, CommandType commandType = CommandType.Text)
        {

            try
            {
                using (SqlConnection conn
                       = new SqlConnection(_connectionString))
                {
                    return conn.Query<T>(query, parameters,commandType:commandType).ToList();
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return default; //Or however you want to handle the return
            }
        }


        public bool Create<T>(string query, object parameters = null, CommandType commandType = CommandType.Text)
        {

            try
            {
                using (SqlConnection conn
                       = new SqlConnection(_connectionString))
                {
                    if (conn.Execute(query, parameters,commandType:commandType) > 0)
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

        public bool Update<T>(string query, object parameters = null, CommandType commandType = CommandType.Text)
        {

            try
            {
                using (SqlConnection conn
                       = new SqlConnection(_connectionString))
                {
                    if (conn.Execute(query, parameters,commandType:commandType) > 0)
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

        public bool Delete<T>(string query, object parameters = null, CommandType commandType = CommandType.Text)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection(_connectionString))
                {
                    if (conn.Execute(query, parameters,commandType:commandType) > 0)
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
