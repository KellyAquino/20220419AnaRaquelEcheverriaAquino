using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaAFP.Models
{
    public class Paciente
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string dui { get; set; }

        public int id_paciente { get; set; }

        public int guardar()
        {
            DBAFP db = new DBAFP();

            string sql = "SpRegistroPaciente -1,@Nombre,@Apellidos,@Dui,NULL,NULL,@Correo,0,null";

            List<Param> p = new List<Param>();
            p.Add(new Param("@Nombre", this.nombre));
            p.Add(new Param("@Apellidos", this.apellido));
            p.Add(new Param("@Dui", this.dui));
            p.Add(new Param("@Correo", this.correo));


            var r = db.query(sql, p);

            return 0;
        }

        public bool buscar(string nombre)
        {
            DBAFP db = new DBAFP();

            string sql = "SpListPaciente @Buscar";

            List<Param> p = new List<Param>();
            p.Add(new Param("@Buscar", nombre));
            var r = db.query(sql, p);
            if (r.Rows.Count > 0)
            {
                this.id_paciente = Convert.ToInt32(r.Rows[0]["Id"]);
                this.nombre = r.Rows[0]["Nombre"].ToString();
                this.apellido = r.Rows[0]["Apellidos"].ToString();
                this.correo = r.Rows[0]["Correo"].ToString();
                this.dui = r.Rows[0]["Dui"].ToString();

                return true;
            }

            return false;
        }
        public bool buscarId(int id)
        {
            DBAFP db = new DBAFP();

            string sql = "SpListPacienteID @Buscar";

            List<Param> p = new List<Param>();
            p.Add(new Param("@Buscar", id));
            var r = db.query(sql, p);
            if (r.Rows.Count > 0)
            {
                this.id_paciente = Convert.ToInt32(r.Rows[0]["Id"]);
                this.nombre = r.Rows[0]["Nombre"].ToString();
                this.apellido = r.Rows[0]["Apellidos"].ToString();
                this.correo = r.Rows[0]["Correo"].ToString();
                this.dui = r.Rows[0]["Dui"].ToString();

                return true;
            }

            return false;
        }
        

    }
}