using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using capaEntidades;
using System.Data;

namespace capaDatos
{
    public class accesoDatoCuenta
    {
        SqlConnection cnx;
        Cuenta c = new Cuenta();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Cuenta> listaCuentas = null;

        public int insertarCuentas(Cuenta C)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Cuenta", cnx); //'Cuenta' debe estar escrito tal cual esta en el procedimiento almacenado'
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@idCuenta", "");
                cm.Parameters.AddWithValue("@nombreuser", C.nombreuser);
                cm.Parameters.AddWithValue("@clave", C.clave);
                cm.Parameters.AddWithValue("@rol", C.rol);
                cm.Parameters.AddWithValue("@idusuario", C.idusuario);

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
        public List<Cuenta> listarCuentas()
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Cuenta", cnx);
                cm.Parameters.AddWithValue("@b", 3);
                cm.Parameters.AddWithValue("@idCuenta", "");
                cm.Parameters.AddWithValue("@nombreuser","");
                cm.Parameters.AddWithValue("@clave", "");
                cm.Parameters.AddWithValue("@rol", "");
                cm.Parameters.AddWithValue("@idusuario", "");
              
                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaCuentas = new List<Cuenta>();
                while (dr.Read())
                {
                    Cuenta c = new Cuenta();
                    c.idCuenta = Convert.ToInt32(dr["idcomentario"].ToString());
                    c.nombreuser = dr["nombreuser"].ToString();
                    c.clave = dr["clave"].ToString();
                    c.rol = dr["rol"].ToString();
                    c.idusuario = Convert.ToInt32(dr["idusuario"].ToString());
                    listaCuentas.Add(c);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaCuentas = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaCuentas;

        }

        public int eliminarCuentas(int idcuent)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@idCuenta", idcuent);
                cm.Parameters.AddWithValue("@nombreuser", "");
                cm.Parameters.AddWithValue("@clave", "");
                cm.Parameters.AddWithValue("@rol", "");
                cm.Parameters.AddWithValue("@idusuario", "");

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

        public int editarCuentas(Cuenta C)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Cuenta", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@idCuenta", C.idCuenta);
                cm.Parameters.AddWithValue("@nombreuser", "");
                cm.Parameters.AddWithValue("@clave", "");
                cm.Parameters.AddWithValue("@rol", "");
                cm.Parameters.AddWithValue("@idusuario", C.idusuario);

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

        public List<Cuenta> buscarCuentas(string dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("comentar", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("@idCuenta", "");
                cm.Parameters.AddWithValue("@nombreuser", dato);
                cm.Parameters.AddWithValue("@clave", dato);
                cm.Parameters.AddWithValue("@rol", dato);
                cm.Parameters.AddWithValue("@idusuario", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaCuentas = new List<Cuenta>();
                while (dr.Read())
                {
                    Cuenta c = new Cuenta();
                    c.idCuenta = Convert.ToInt32(dr["idCuenta"].ToString());
                    c.nombreuser = dr["nombreuser"].ToString();
                    c.clave = dr["clave"].ToString();
                    c.rol = dr["rol"].ToString();
                    c.idusuario = Convert.ToInt32(dr["idusuario"].ToString());
                    listaCuentas.Add(c);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }

            finally
            { cm.Connection.Close(); }
            return listaCuentas;

        }
    }
}
