using CleanDapper.CORE.Entity.Abstract;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CleanDapper.CORE.Repository.Abstract.Base
{
    public interface IDapperBaseRepository<T> where T : IBaseEntity
    {
        public List<T> Query<T>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection("Your Connection String"))
                {
                    return conn.Query<T>(query, parameters).ToList();
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return new List<T>();
            }
        }

        public List<T> QueryGetALL<T>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection("Your Connection String"))
                {
                    return conn.Query<T>(query, parameters).ToList();
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return new List<T>();
            }
        }

        public T QueryGetByID<T>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection("Your Connection String"))
                {
                    return conn.QueryFirstOrDefault<T>(query, parameters);
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return default; //Or however you want to handle the return
            }
        }

        public List<T> SearchByFirstName<T>(string query, object parameters = null)
        {

            try
            {
                using (SqlConnection conn
                       = new SqlConnection("Your Connection String"))
                {
                    return conn.Query<T>(query, parameters).ToList();
                }
            }
            catch (Exception ex)
            {
                //Handle the exception
                return default; //Or however you want to handle the return
            }
        }


        public bool Create<T>(string query, object parameters = null)
        {

            try
            {
                using (SqlConnection conn
                       = new SqlConnection("Your Connection String"))
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

        public bool Update<T>(string query, object parameters = null)
        {

            try
            {
                using (SqlConnection conn
                       = new SqlConnection("Your Connection String"))
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

        public bool Delete<T>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection("Your Connection String"))
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
