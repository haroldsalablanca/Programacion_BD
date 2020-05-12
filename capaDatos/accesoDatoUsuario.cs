using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using capaEntidades;
using System.Data;

namespace capaDatos
{
    public class accesoDatoUsuario
    {
        SqlConnection cnx;
        Usuario u = new Usuario();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Usuario> listaUsuarios = null;

        public int insertarUsuarios(Usuario U)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Usuario", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@idusuario", "");
                cm.Parameters.AddWithValue("@cedula", U.cedula);
                cm.Parameters.AddWithValue("@nombre", U.nombre);
                cm.Parameters.AddWithValue("@apellidos", U.apellidos);
                cm.Parameters.AddWithValue("@email", U.email);
                cm.Parameters.AddWithValue("@telefono", U.telefono);
               
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

        //public List<Usuario> listarUsuarios()
        //{
        //    try
        //    {
        //        SqlConnection cnx = cn.conectar();
        //        cm = new SqlCommand("Usuario", cnx);
        //        cm.Parameters.AddWithValue("@b", 3);
        //        cm.Parameters.AddWithValue("@idusuario", "");
        //        cm.Parameters.AddWithValue("@cedula", "");
        //        cm.Parameters.AddWithValue("@nombre", "");
        //        cm.Parameters.AddWithValue("@apellidos", "");
        //        cm.Parameters.AddWithValue("@email", "");
        //        cm.Parameters.AddWithValue("@telefono", "");

        //        cm.CommandType = CommandType.StoredProcedure;
        //        cnx.Open();
        //        dr = cm.ExecuteReader();
        //        listaUsuarios = new List<Usuario>();
        //        while (dr.Read())
        //        {
        //            Usuario c = new Usuario();
        //            c.idusuario = Convert.ToInt32(dr["idsolicitud"].ToString());
        //            c.cedula = dr["cedula"].ToString();
        //            c.nombre = dr["nombre"].ToString();
        //            c.apellidos = dr["apellidos"].ToString();    
        //            c.email = dr["apellidos"].ToString();                
        //            c.telefono = dr["telefono"].ToString();            
        //            listaUsuarios.Add(c);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        e.Message.ToString();
        //        listaUsuarios = null;
        //    }
        //    finally
        //    {
        //        cm.Connection.Close();
        //    }
        //    return listaUsuarios;

        //}

        public int eliminarUsuario(int iduser)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Usuario", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@idusuario", iduser);
                cm.Parameters.AddWithValue("@cedula", "");
                cm.Parameters.AddWithValue("@nombre", "");
                cm.Parameters.AddWithValue("@apellidos", "");
                cm.Parameters.AddWithValue("@email", "");
                cm.Parameters.AddWithValue("@telefono", "");
                
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

        public int editarUsuario(Usuario U)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("usuario", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@idusuario", U.idusuario);
                cm.Parameters.AddWithValue("@cedula", U.cedula);
                cm.Parameters.AddWithValue("@nombre", U.nombre);
                cm.Parameters.AddWithValue("@apellidos", U.apellidos);
                cm.Parameters.AddWithValue("@email", U.email);
                cm.Parameters.AddWithValue("@telefono", U.telefono);
                
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

        public List<Usuario> buscarUsuarios(string dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Usuario", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("@idusuario", "");
                cm.Parameters.AddWithValue("@cedula", dato);
                cm.Parameters.AddWithValue("@nombre", dato);
                cm.Parameters.AddWithValue("@apellidos", dato);
                cm.Parameters.AddWithValue("@email", dato);
                cm.Parameters.AddWithValue("@telefono", dato);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaUsuarios = new List<Usuario>();
                while (dr.Read())
                {
                    Usuario c = new Usuario();
                    c.idusuario = Convert.ToInt32(dr["idusuario"].ToString());
                    c.cedula = dr["cedula"].ToString();
                    c.nombre = dr["nombre"].ToString();
                    c.apellidos = dr["apellidos"].ToString();
                    c.email = dr["email"].ToString();
                    c.telefono = dr["telefono"].ToString();
                    listaUsuarios.Add(c);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }

            finally
            { cm.Connection.Close(); }
            return listaUsuarios;
        }
    }
}
