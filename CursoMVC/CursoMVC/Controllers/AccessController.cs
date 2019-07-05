using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;

namespace CursoMVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string pass)
        {
            try
            {
                using (db_cursomvcEntities db = new db_cursomvcEntities())
                {
                    var list = from d in db.tbl_usuarios
                               where d.email == user && d.password == pass && d.idCatalogo == 1
                               select d;
                    if (list.Count()>0)
                    {
                        tbl_usuarios oUser = list.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario invalido....");
                    }
                }

                
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error..."+ex.Message);
            }
        }
    }
}