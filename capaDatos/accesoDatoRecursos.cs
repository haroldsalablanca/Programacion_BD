using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using capaEntidades;
using System.Data;

namespace capaDatos
{
    public class accesoDatoRecursos
    {
        SqlConnection cnx;
        Recursos r = new Recursos();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Recursos> listaRecursos = null;

        public int insertarRecursos(Recursos re)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Recurso", cnx); //'Recurso' debe estar escrito tal cual esta en la table de Sql'
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@idrecursos", "");
                cm.Parameters.AddWithValue("@nombrer", re.nombrer);
                cm.Parameters.AddWithValue("@codigo", re.codigo);
                cm.Parameters.AddWithValue("@descripcion", re.descripcion);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            {
                cm.Connection.Close();
            }
            return indicador;
        }
        public List<Recursos> listarRecursos()
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Recurso", cnx);
                cm.Parameters.AddWithValue("@b", 3);
                cm.Parameters.AddWithValue("@idrecursos", "");
                cm.Parameters.AddWithValue("@nombrer", "");
                cm.Parameters.AddWithValue("@codigo", "");
                cm.Parameters.AddWithValue("@descripcion", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaRecursos = new List<Recursos>();
                while (dr.Read())
                {
                    Recursos c = new Recursos();
                    c.idrecursos = Convert.ToInt32(dr["idrecursos"].ToString());
                    c.nombrer = dr["nombrer"].ToString();
                    c.codigo = dr["codigo"].ToString();
                    c.descripcion = dr["descripcion"].ToString();
                    listaRecursos.Add(c);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaRecursos = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaRecursos;

        }

        public int eliminarRecursos(int idcoment)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Recurso", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@idrecursos", idcoment);
                cm.Parameters.AddWithValue("@nombrer", "");
                cm.Parameters.AddWithValue("@codigo", "");
                cm.Parameters.AddWithValue("@descripcion", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            { cm.Connection.Close(); }
            return indicador;
        }

        public int editarRecursos(Recursos re)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Recurso", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@idrecursos", re.idrecursos);
                cm.Parameters.AddWithValue("@nombrer", re.nombrer);
                cm.Parameters.AddWithValue("@codigo", re.codigo);
                cm.Parameters.AddWithValue("@descripcion", re.descripcion);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }

            finally
            {
                cm.Connection.Close();
            }
            return indicador;
        }

        public List<Recursos> buscarRecursos(string dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Recurso", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("@idrecursos", "");
                cm.Parameters.AddWithValue("@nombrer", dato);
                cm.Parameters.AddWithValue("@codigo", dato);
                cm.Parameters.AddWithValue("@descripcion", dato);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaRecursos = new List<Recursos>();
                while (dr.Read())
                {
                    Recursos c = new Recursos();
                    c.idrecursos = Convert.ToInt32(dr["idrecursos"].ToString());
                    c.nombrer = dr["nombrer"].ToString();
                    c.codigo = dr["codigo"].ToString();
                    c.descripcion = dr["descripcion"].ToString();
                    listaRecursos.Add(c);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador  = 0;
            }

            finally
            { cm.Connection.Close(); }
            return listaRecursos;
        }
    }
}
