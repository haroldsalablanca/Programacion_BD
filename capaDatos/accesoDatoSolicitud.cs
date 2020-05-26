using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using capaEntidades;
using System.Data;

namespace capaDatos
{
    public class accesoDatoSolicitud
    {
        SqlConnection cnx;
        Solicitud s = new Solicitud();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Solicitud> listaSolicitudes = null;

        public int insertarSolicitud(Solicitud S)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Solicitar", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@idsolicitud", "");
                cm.Parameters.AddWithValue("@aula", S.aula);
                cm.Parameters.AddWithValue("@nivel", S.nivel);
                cm.Parameters.AddWithValue("@fechasolicitud", S.fechasolicitud);
                cm.Parameters.AddWithValue("@fechauso", S.fechauso);
                cm.Parameters.AddWithValue("@horainicio", S.horainicio);
                cm.Parameters.AddWithValue("@horafinal", S.horafinal);
                cm.Parameters.AddWithValue("@carrera", S.carrera);
                cm.Parameters.AddWithValue("@asignatura", S.asignatura);
                cm.Parameters.AddWithValue("@idrecursos", "");
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
            {
                cm.Connection.Close();
            }
            return indicador;
        }
        public List<Solicitud> listarSolicitud()
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Solicitar", cnx);
                cm.Parameters.AddWithValue("@b", 3);
                cm.Parameters.AddWithValue("@idsolicitud", "");
                cm.Parameters.AddWithValue("@aula", "");
                cm.Parameters.AddWithValue("@nivel", "");
                cm.Parameters.AddWithValue("@fechasolicitud", "");
                cm.Parameters.AddWithValue("@fechauso", "");
                cm.Parameters.AddWithValue("@horainicio", "");
                cm.Parameters.AddWithValue("@horafinal", "");
                cm.Parameters.AddWithValue("@carrera", "");
                cm.Parameters.AddWithValue("@asignatura", "");
                cm.Parameters.AddWithValue("@idrecursos", "");
                cm.Parameters.AddWithValue("@idusuario", "");

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaSolicitudes = new List<Solicitud>();
                while (dr.Read())
                {
                    Solicitud c = new Solicitud();
                    c.idsolicitud = Convert.ToInt32(dr["idsolicitud"].ToString());
                    c.aula = dr["aula"].ToString();
                    c.nivel = dr["nivel"].ToString();
                    c.fechasolicitud = Convert.ToDateTime(dr["fechasolicitud"].ToString());    //Consultar
                    c.fechauso = Convert.ToDateTime(dr["fechauso"].ToString());                //Consultar
                    c.horainicio = Convert.ToDateTime(dr["horainicio"]);            //Consultar
                    c.horafinal = Convert.ToDateTime(dr["horafinal"]);              //Consultar
                    c.carrera = dr["carrera"].ToString();
                    c.asignatura = dr["asignatura"].ToString();
                    c.idrecursos = Convert.ToInt32(dr["idrecursos"].ToString());
                    c.idusuario = Convert.ToInt32(dr["idrecursos"].ToString());
                    listaSolicitudes.Add(c);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaSolicitudes = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaSolicitudes;

        }

        public int eliminarSolicitud(int idsolicit)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("Solicitar", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@idsolicitud", idsolicit);
                cm.Parameters.AddWithValue("@aula", "");
                cm.Parameters.AddWithValue("@nivel", "");
                cm.Parameters.AddWithValue("@fechasolicitud", "");
                cm.Parameters.AddWithValue("@fechauso", "");
                cm.Parameters.AddWithValue("@horainicio", "");
                cm.Parameters.AddWithValue("@horafinal", "");
                cm.Parameters.AddWithValue("@carrera", "");
                cm.Parameters.AddWithValue("@asignatura", "");
                cm.Parameters.AddWithValue("@idrecursos", "");
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

        public int editarSolicitud(Solicitud S)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Solicitar", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@idsolicitud", S.idsolicitud);
                cm.Parameters.AddWithValue("@aula", S.aula);
                cm.Parameters.AddWithValue("@nivel", S.nivel);
                cm.Parameters.AddWithValue("@fechasolicitud", S.fechasolicitud);
                cm.Parameters.AddWithValue("@fechauso", S.fechauso);
                cm.Parameters.AddWithValue("@horainicio", S.horainicio);
                cm.Parameters.AddWithValue("@horafinal", S.horafinal);
                cm.Parameters.AddWithValue("@carrera", S.carrera);
                cm.Parameters.AddWithValue("@asignatura", S.asignatura);
                cm.Parameters.AddWithValue("@idrecursos", S.idrecursos);
                cm.Parameters.AddWithValue("@idusuario", S.idusuario);

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

        public List<Solicitud> buscarSolicitud(string dato)
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("Solicitar", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("@idsolicitud", "");
                cm.Parameters.AddWithValue("@aula", dato);
                cm.Parameters.AddWithValue("@nivel", dato);
                cm.Parameters.AddWithValue("@fechasolicitud", dato);
                cm.Parameters.AddWithValue("@fechauso", dato);
                cm.Parameters.AddWithValue("@horainicio", dato);
                cm.Parameters.AddWithValue("@horafinal", dato);
                cm.Parameters.AddWithValue("@carrera", dato);
                cm.Parameters.AddWithValue("@asignatura", dato);
                cm.Parameters.AddWithValue("@idrecursos", dato);
                cm.Parameters.AddWithValue("@idusuario", dato);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaSolicitudes = new List<Solicitud>();
                while (dr.Read())
                {
                    Solicitud c = new Solicitud();
                    c.idsolicitud = Convert.ToInt32(dr["idsolicitud"].ToString());
                    c.aula = dr["aula"].ToString();
                    c.nivel = dr["nivel"].ToString();
                    c.fechasolicitud = Convert.ToDateTime(dr["fechasolicitud"]);    //Consultar
                    c.fechauso = Convert.ToDateTime(dr["fechauso"]);                //Consultar
                    c.horainicio = Convert.ToDateTime(dr["horainicio"]);            //Consultar
                    c.horafinal = Convert.ToDateTime(dr["horafinal"]);              //Consultar
                    c.carrera = dr["carrera"].ToString();
                    c.asignatura = dr["asignatura"].ToString();
                    c.idrecursos = Convert.ToInt32(dr["idrecursos"].ToString());
                    c.idusuario = Convert.ToInt32(dr["idrecursos"].ToString());
                    listaSolicitudes.Add(c);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }

            finally
            { cm.Connection.Close(); }
            return listaSolicitudes;

        }
    }
}
