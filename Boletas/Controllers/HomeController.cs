using Rotativa;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Boletas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(DateTime fechainicioa, DateTime fechafina, int codigoa=0)
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SOLICITA.Properties.Settings.obrasConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dav_LISTA_REGALIAS_JUD_ADE_SYST]"; //store
                cmd.Parameters.AddWithValue("@fecha_ini", fechainicioa); //parametros
                cmd.Parameters.AddWithValue("@fecha_fin", fechafina); //parametros
                cmd.Parameters.AddWithValue("@cod_socio", 0);
                cmd.Connection = conn;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string lectura = Convert.ToString(reader[6]);
                    string cod = Convert.ToString(codigoa);

                    if (lectura==cod)
                    {
                        ViewBag.cod = cod;
                        ViewBag.SOCIO = reader["SOCIO"].ToString();
                        ViewBag.PERIODO = reader["PERIODO"].ToString();
                        ViewBag.REPARTO = reader["REPARTO"].ToString();
                        ViewBag.DESCRIPCION = reader["DESCRIPCION"].ToString();
                        ViewBag.MEMO = reader["MEMO"].ToString();
                        ViewBag.FECHALIQ = reader["FECHA LIQ"].ToString();
                        ViewBag.RENTA = reader["RENTA"].ToString();
                        ViewBag.SOCIO_INTERNO = reader["SOCIO INTERNO"].ToString();
                        ViewBag.IMPORTE = reader["IMPORTE"].ToString();
                        ViewBag.SUNAT = reader["SUNAT"].ToString();
                        ViewBag.JUDICIAL = reader["JUDICIAL"].ToString();
                        ViewBag.ONI = reader["ONI"].ToString();
                        ViewBag.EXC = reader["EXC"].ToString();
                        ViewBag.PEGA = reader["PEGA"].ToString();
                        ViewBag.PORDIAR = reader["PORDIAR"].ToString();
                        ViewBag.ADELANTO = reader["ADELANTO"].ToString();
                        ViewBag.TOTAL = reader["TOTAL"].ToString();
                    }
                }

            }
                return View();
        }

        public ActionResult Print(string fechainicio, string fechafin, string codigo)
        {
            DateTime FechaInicio = DateTime.Parse(fechainicio);
            DateTime FechaFin = DateTime.Parse(fechafin);
            int Codigo = Convert.ToInt32(codigo);

            //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SOLICITA.Properties.Settings.obrasConnectionString"].ConnectionString))
            //{
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.CommandText = "[dav_LISTA_REGALIAS_JUD_ADE_SYST]"; //store
            //    cmd.Parameters.AddWithValue("@fecha_ini", FechaInicio); //parametros
            //    cmd.Parameters.AddWithValue("@fecha_fin", FechaFin); //parametros
            //    cmd.Parameters.AddWithValue("@cod_socio", Codigo);
            //    cmd.Connection = conn;
            //    conn.Open();

            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        string lectura = Convert.ToString(reader[6]);
            //        string cod = Convert.ToString(codigo);

            //        if (lectura == cod)
            //        {
            //            ViewBag.cod = cod;
            //            ViewBag.SOCIO = reader["SOCIO"].ToString();
            //            ViewBag.PERIODO = reader["PERIODO"].ToString();
            //            ViewBag.REPARTO = reader["REPARTO"].ToString();
            //            ViewBag.DESCRIPCION = reader["DESCRIPCION"].ToString();
            //            ViewBag.MEMO = reader["MEMO"].ToString();
            //            ViewBag.FECHALIQ = reader["FECHA LIQ"].ToString();
            //            ViewBag.RENTA = reader["RENTA"].ToString();
            //            ViewBag.SOCIO_INTERNO = reader["SOCIO INTERNO"].ToString();
            //            ViewBag.IMPORTE = reader["IMPORTE"].ToString();
            //            ViewBag.SUNAT = reader["SUNAT"].ToString();
            //            ViewBag.JUDICIAL = reader["JUDICIAL"].ToString();
            //            ViewBag.ONI = reader["ONI"].ToString();
            //            ViewBag.EXC = reader["EXC"].ToString();
            //            ViewBag.PEGA = reader["PEGA"].ToString();
            //            ViewBag.PORDIAR = reader["PORDIAR"].ToString();
            //            ViewBag.ADELANTO = reader["ADELANTO"].ToString();
            //            ViewBag.TOTAL = reader["TOTAL"].ToString();
            //        }
            //    }
            //    //string cdg = ViewBag.SOCIO_INTERNO;
            //    //string co = cdg.Remove(0, 1);
            //    //ViewBag.COD = co;

            //}

            return new ActionAsPdf("Index", new { fechainicioa = FechaInicio, fechafina = FechaFin, codigoa= Codigo })
            { FileName = "BOLETA.pdf" };

        }

        public ActionResult CargaMasiva(DateTime fechainicio, DateTime fechafin, int codigo=0)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SOLICITA.Properties.Settings.obrasConnectionString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dav_LISTA_REGALIAS_JUD_ADE_SYST]"; //store
                cmd.Parameters.AddWithValue("@fecha_ini", fechainicio); //parametros
                cmd.Parameters.AddWithValue("@fecha_fin", fechafin); //parametros
                cmd.Parameters.AddWithValue("@cod_socio", codigo);
                cmd.Connection = conn;
                conn.Open();
                //cmd.CommandTimeout = 3000;//
                SqlDataReader reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                    //string lectura = Convert.ToString(reader[0]);
                    //int codig = Convert.ToInt32(lectura);
                    
                //}
                
            }

            return RedirectToAction("Lista", "ListaBoleta");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}