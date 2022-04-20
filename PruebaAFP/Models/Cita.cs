using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PruebaAFP.Models
{
    public class Cita
    {
        public int id { get; set; }
        public DateTime fechacita { get; set; }
        public string horainicio { get; set; }
        public string horafin { get; set; }
        public int idpaciente { get; set; }
        public string iddoctor { get; set; }
        public int crud { get; set; }
        public string motivo { get; set; }
        public string referencia { get; set; }
        public string paciente { get; set; }
        public string doctor { get; set; }
        public string historiamedica { get; set; }
        public string diagnostico { get; set; }
        public string receta { get; set; }


        public int guardarcita()
        {
            DBAFP db = new DBAFP();


            string sql = "SpCitas -1, @FechaCita,@HoraInicio,@HoraFin,@IdPaciente,@IdDoctor,@Motivo,@Crud,@Referencia";

            List<Param> p = new List<Param>();
            p.Add(new Param("@FechaCita", this.fechacita.ToString("yyyy-MM-dd HH:mm:ss")));
            p.Add(new Param("@HoraInicio", this.horainicio));
            p.Add(new Param("@HoraFin", this.horafin));
            p.Add(new Param("@IdPaciente", this.idpaciente));
            p.Add(new Param("@IdDoctor", this.iddoctor));
            p.Add(new Param("@Crud", 0));
            p.Add(new Param("@Motivo", this.motivo));
            p.Add(new Param("@Referencia", this.referencia));


            var r = db.query(sql, p);

            return 0;
        }

        public List<Cita> vercitas()
        {
            DBAFP db = new DBAFP();


            string sql = "SpHistoricoCitas";

            List<Cita> lista = new List<Cita>();
           
            var r = db.query(sql, null);
            if (r.Rows.Count > 0)
            {
                foreach(DataRow item in r.Rows)
                {
                    Cita tmp = new Cita();
                    tmp.id =Convert.ToInt32(item["Id"]);
                    DateTime d;
                    if (DateTime.TryParse(Convert.ToString(item["Fecha"]),out d))
                    {
                        tmp.fechacita = Convert.ToDateTime(item["Fecha"]);

                    }
                   // tmp.fechacita = Convert.ToDateTime(item["Fecha"]);
                    tmp.horainicio = Convert.ToString(item["HoraInicio"]);
                    tmp.horafin = Convert.ToString(item["HoraFin"]);
                    tmp.idpaciente = Convert.ToInt32(item["IdPaciente"]);
                    tmp.iddoctor = Convert.ToString(item["IdDoctor"]);
                    tmp.paciente = Convert.ToString(item["paciente"]);
                    tmp.doctor = Convert.ToString(item["doctor"]);
                    tmp.motivo = Convert.ToString(item["Motivo"]);
                    tmp.referencia = Convert.ToString(item["Referencia"]);

                    lista.Add(tmp);
                }


                 
            }
            return lista;
        }

        public int guardarexpediente(int id_paciente)
        {
            DBAFP db = new DBAFP();


            string sql = "EXEC SpExpediente -1,@IdPaciente,NULL,@IdCita,@HistoriaMedica,@Diagnostico, @FechaCita,@Crud,@Receta";

            List<Param> p = new List<Param>();
            p.Add(new Param("@IdPaciente", id_paciente));
            p.Add(new Param("@IdDoctor", this.iddoctor));
            p.Add(new Param("@IdCita", this.id));
            p.Add(new Param("@HistoriaMedica", this.motivo));
            p.Add(new Param("@Motivo", this.motivo));
            p.Add(new Param("@Diagnostico", this.motivo));
            p.Add(new Param("@FechaCita", this.fechacita.ToString("yyyy-MM-dd HH:mm:ss")));
            p.Add(new Param("@Crud", 0));
            p.Add(new Param("@Receta", this.motivo));



            var r = db.query(sql, p);

            return 0;
        }
    }


}