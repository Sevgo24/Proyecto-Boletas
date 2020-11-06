using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Boletas.Models;

namespace P_R.Controllers
{
    public class ListaBoletaController : Controller
    {
        // GET: Inicio
        public ActionResult Lista()
        {
           
            List<SelectListItem> TipoMonto = new List<SelectListItem>();
            TipoMonto.Add(new SelectListItem() { Text = "MENOR A 30", Value = "1" });
            TipoMonto.Add(new SelectListItem() { Text = "MAYOR IGUAL A 30", Value = "2" });
            SelectList tipMonto = new SelectList(TipoMonto, "Value", "Text");
            ViewBag.TipoMonto = tipMonto;
            ViewBag.TipMonto = "";
            return View();
        }
        [HttpPost]
        public ActionResult Lista(Fechas fecha)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> TipoMonto = new List<SelectListItem>();
                TipoMonto.Add(new SelectListItem() { Text = "MENOR A 30", Value = "1" });
                TipoMonto.Add(new SelectListItem() { Text = "MAYOR IGUAL A 30", Value = "2" });
                SelectList tipMonto = new SelectList(TipoMonto, "Value", "Text");
                ViewBag.TipoMonto = tipMonto;
                ViewBag.TipMonto = fecha.tipomonto;
                return View(); }
            else
            {
                List<SelectListItem> TipoMonto = new List<SelectListItem>();
                TipoMonto.Add(new SelectListItem() { Text = "MENOR A 30", Value = "1" });
                TipoMonto.Add(new SelectListItem() { Text = "MAYOR IGUAL A 30", Value = "2" });
                SelectList tipMonto = new SelectList(TipoMonto, "Value", "Text");
                ViewBag.TipoMonto = tipMonto;
                ViewBag.TipMonto = fecha.tipomonto;
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SOLICITA.Properties.Settings.obrasConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[dav_LISTA_REGALIAS_JUD_ADE_SYST_CAB]"; //store
                    cmd.Parameters.AddWithValue("@fecha_ini", fecha.fechainicio); //parametros
                    cmd.Parameters.AddWithValue("@fecha_fin", fecha.fechafin); //parametros
                    cmd.Parameters.AddWithValue("@cod_socio", fecha.codigo);
                    cmd.Connection = conn;
                    conn.Open();//Cerrar Connection AQUI DENNYS

                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    string[] cods;
                    int i = 0;
                    //List<int> codigos = new List<int>();
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        i++;
                    }
                    cods = new string[i];
                    int j = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        cods[j] = Convert.ToString(row["SOCIO INTERNO"]);
                        j++;
                    }
                    ViewBag.Tabla = dt;
                    ViewBag.tamaño = j;
                    ViewBag.FechaInicio = fecha.fechainicio;
                    ViewBag.FechaFin = fecha.fechafin;
                    ViewBag.Fecha = fecha;
                    ViewBag.codigo = cods;

                    return View();
                }

            }
        }
    }
}
