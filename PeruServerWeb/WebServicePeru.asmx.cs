using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PeruServerWeb
{
    /// <summary>
    /// Descripción breve de WebServicePeru
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServicePeru : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Object[]> departamentos()
        {
            List<Object[]> list = new List<object[]>();

            using (var db = new ModelPeru())
            {
                var query = from depa in db.departamentos
                            select new
                            {
                                iddepartamento = depa.iddepartamento,
                                departamento = depa.departamento
                            };

                foreach(var fil in query)
                {
                    list.Add(new object[] { fil.iddepartamento, fil.departamento });
                }
            }

            return list;
        }

        [WebMethod]
        public List<object[]> provincias(int iddepartamento)
        {
            List<object[]> list = new List<object[]>();

            using (var db = new ModelPeru())
            {
                var query = (from pro in db.provincias
                             where pro.iddepartamento == iddepartamento
                             select new
                             {
                                 idprovincia = pro.idprovincia,
                                 provincia = pro.provincia
                             });

                foreach (var fil in query)
                {
                    list.Add(new object[] { fil.idprovincia, fil.provincia });
                }
            }

            return list;
        }

        [WebMethod]
        public List<object[]> distritos(int idprovincia)
        {
            List<object[]> list = new List<object[]>();

            using (var db = new ModelPeru())
            {
                var query = (from dis in db.distritos
                             where dis.idprovincia == idprovincia
                             select new
                             {
                                 iddistrito = dis.iddistrito,
                                 distrito = dis.distrito
                             });

                foreach (var fil in query)
                {
                    list.Add(new object[] { fil.iddistrito, fil.distrito });
                }
            }

            return list;
        }
    }
}
