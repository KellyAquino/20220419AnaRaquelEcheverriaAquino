using PruebaAFP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaAFP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Buscar()
        {
            String nombre = Request["nombre_paciente"].ToString().Trim();
            Paciente p = new Paciente();
            bool existe = p.buscar(nombre);

            if (existe)
            {
                int id_paciente = p.id_paciente;
                return Redirect("/Home/paciente/"+id_paciente+"?id_paciente="+ id_paciente);
            }
            else
            {
                return Redirect("/?error=1");
            }
           
        }
        [Route("home/paciente/{id_paciente}")]
        public ActionResult Paciente(string id_paciente)
        {
            int id = Convert.ToInt32(id_paciente);

            Paciente p = new Paciente();
            bool existe = p.buscarId(id);

            ViewBag.paciente = p;
            return View("Paciente");
        }
        [HttpPost]
        [Route("home/guardar_cita/{id_paciente}")]
        public ActionResult guardar_cita(string id_paciente)
        {
            int id = Convert.ToInt32(id_paciente);
            string _fecha = Request["fecha"].ToString().Trim();
            string _horainicio = Request["horainicio"].ToString().Trim();
            string _horafin = Request["horafin"].ToString().Trim();
            string _fecha_completa = _fecha + " " + _horainicio;
            DateTime fecha_completa = Convert.ToDateTime(_fecha_completa);
            string motivo = Request["motivo"].ToString().Trim();
            string referencia = Request["referencia"].ToString().Trim();

            Cita cita = new Cita();
            cita.fechacita = fecha_completa;
            cita.horainicio= Request["horainicio"].ToString().Trim();
            cita.horafin= Request["horafin"].ToString().Trim();
            cita.idpaciente = id;
            cita.iddoctor= Request["iddoctor"].ToString().Trim();
           
            cita.motivo= Request["motivo"].ToString().Trim();
            cita.referencia= Request["referencia"].ToString().Trim();
            int id_cita = cita.guardarcita();

            return Redirect("/?ok=1");




        }

        [Route("home/nuevo_paciente")]
        public ActionResult nuevo_paciente()
        {
            return View("NuevoPaciente");
        }
        [HttpPost]
        [Route("home/guardar_paciente/")]
        public ActionResult guardar_paciente()
        {
            Paciente p = new Paciente();
            p.nombre = Request["nombre"].ToString().Trim();
            p.apellido = Request["apellido"].ToString().Trim();
            p.correo = Request["correo"].ToString().Trim();
            p.dui = Request["dui"].ToString().Trim();

            int id_paciente = p.guardar();

            return Redirect("/?ok=1");

          

        }

        [Route("home/citas")]
        public ActionResult Citas()
        {
             

            Cita p = new Cita();
            ViewBag.citas = p.vercitas();

             
            return View("Citas");
        }
         
        [Route("home/expediente/{id_paciente}")]
        public ActionResult expediente(string id_paciente)
        {
            int id = Convert.ToInt32(id_paciente);
            Paciente pcte = new Paciente();
            pcte.buscarId(id);

            ViewBag.paciente = pcte;
            return View("Expediente");



        }

   
        [HttpPost]
        [Route("home/guardar_expediente/{id_paciente}")]
        public ActionResult guardar_expediente(string id_paciente)
        {
            int id = Convert.ToInt32(id_paciente);
            Cita cita = new Cita();
            cita.historiamedica = Request["historiamedica"].ToString().Trim();
            cita.diagnostico = Request["diagnostico"].ToString().Trim();
            cita.receta = Request["receta"].ToString().Trim();
            cita.idpaciente = id;
            

            int id_cita = cita.guardarcita();

            return Redirect("/?ok=1");



        }
    }
}