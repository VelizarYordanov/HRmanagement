using HRmanagement.BLL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HRmanagement.DAO
{
    public abstract class UniversalDAO<TEntity> : DaoBase, IDao<TEntity>
        where TEntity : Models.Universal, new()
    {
        public int Delete(TEntity entity)
        {
            Type t = typeof(TEntity);
            MySqlCommand com = new MySqlCommand("delete * from " +t.Name + "s where id = @id");
            com.Parameters.Add(new MySqlParameter("id", entity.ID));
            try
            {
                com.Connection.Open();
                return com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Delete(int id)
        {
            Type t = typeof(TEntity);
            MySqlCommand com = new MySqlCommand("delete from " + t.Name +"s where id = @id", ConnectionString.GetConnection());
            com.Parameters.Add(new MySqlParameter("id", id));
            try
            {
                com.Connection.Open();
                return com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public TEntity Get(int id)
        {
            Type t = typeof(TEntity);
            MySqlCommand com = new MySqlCommand("select * from " + t.Name + "s where id = @id", ConnectionString.GetConnection());
            com.Parameters.Add(new MySqlParameter("id", id));
            try
            {
                com.Connection.Open();
                MySqlDataReader dr = com.ExecuteReader();
                TEntity newEntity;

                if (dr.Read())
                {
                    newEntity = new TEntity();
                    // Fill the properties from the database
                    foreach (PropertyInfo p in typeof(TEntity).GetProperties(
                        BindingFlags.FlattenHierarchy |
                        BindingFlags.Public |
                        BindingFlags.Instance)
                        .Where(p => !p.PropertyType.IsGenericType))
                    {
                        newEntity.GetType().GetProperty(p.Name).SetValue(newEntity,
                           Convert.ChangeType(dr[p.Name], p.PropertyType));
                    }
                    return newEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<TEntity> GetAll()
        {
            Type t = typeof(TEntity);
            MySqlCommand com = new MySqlCommand("Select * from " + t.Name + "s", ConnectionString.GetConnection());
            try
            {
                com.Connection.Open();
                MySqlDataReader dr = com.ExecuteReader();

                List<TEntity> entities = new List<TEntity>();

                while (dr.Read())
                {
                    TEntity newEntity = new TEntity();
                    foreach (PropertyInfo p in typeof(TEntity).GetProperties(
                        BindingFlags.FlattenHierarchy | 
                        BindingFlags.Public | 
                        BindingFlags.Instance)
                        .Where(p => !p.PropertyType.IsGenericType))
                    {
                        Console.WriteLine(string.Join(" ", p.PropertyType.GetInterfaces().Select(i => i.Name + " " + i.IsGenericType)));
                        newEntity.GetType().GetProperty(p.Name).SetValue(newEntity,
                           Convert.ChangeType(dr[p.Name], p.PropertyType));
                        
                    }
                    entities.Add(newEntity);
                }
                return entities;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public int Insert(TEntity entity)
        {
            List<string> attributes = typeof(TEntity).GetProperties(BindingFlags.DeclaredOnly |
                        BindingFlags.Public |
                        BindingFlags.Instance).Where(p => !p.PropertyType.IsGenericType).Select(p => p.Name).ToList();

            string sql = InsertSqlBuilder(typeof(TEntity).Name, attributes);
            MySqlCommand com = new MySqlCommand(sql, ConnectionString.GetConnection());
            try
            {
                foreach (string att in attributes)
                {
                    // if it is a datetime convert it
                    if (entity.GetType().GetProperty(att).PropertyType == typeof(DateTime))
                    {
                        string dateValue = FormatConverter
                            .ConvertToMySqlDateString(
                            (DateTime)entity.GetType().GetProperty(att).GetValue(entity));
                        com.Parameters.Add(new MySqlParameter(
                        att,
                        dateValue));

                        continue;
                    }

                    // for ordinary data values
                    com.Parameters.Add(new MySqlParameter(
                        att,
                        entity.GetType().GetProperty(att).GetValue(entity).ToString()));
                }
                com.Connection.Open();

                return com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public int Update(TEntity entity)
        {
            try
            {
                //List<string> attributes = new List<string>() { "name", "address" };
                List<string> attributes = typeof(TEntity)
                    .GetProperties(BindingFlags.FlattenHierarchy |
                        BindingFlags.Public |
                        BindingFlags.Instance)
                    .Where(p => !p.PropertyType.IsGenericType)
                    .Select(p => p.Name)
                    .ToList();
                string sql = UpdateSqlBuilder(typeof(TEntity).Name, attributes);

                MySqlCommand com = new MySqlCommand(sql, ConnectionString.GetConnection());

                foreach (string att in attributes)
                {
                    // if it is a datetime convert it
                    if (entity.GetType().GetProperty(att).PropertyType == typeof(DateTime))
                    {
                        string dateValue = FormatConverter
                            .ConvertToMySqlDateString(
                            (DateTime)entity.GetType().GetProperty(att).GetValue(entity));
                        com.Parameters.Add(new MySqlParameter(
                        att,
                        dateValue));

                        continue;
                    }

                    com.Parameters.Add(new MySqlParameter(
                        att,                                                                // Parameter Name
                        entity.GetType().GetProperty(att).GetValue(entity).ToString()));    // Parameter Value
                }

                com.Connection.Open();

                return com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
