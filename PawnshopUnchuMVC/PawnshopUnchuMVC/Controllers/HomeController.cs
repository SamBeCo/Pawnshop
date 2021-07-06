using PawnshopUnchuMVC.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Configuration;
namespace PawnshopUnchuMVC.Controllers
{
    public class HomeController : Controller
    {
        //Página principal
        public ActionResult Index()
        {
            return View();
        }
        //Página de acerca de la empresa
        public ActionResult About()
        {       
            return View();
        }
        //Página de servicios de la empresa
        public ActionResult Service()
        {
            return View();
        }
        //Página de Login
        public ActionResult Login()
        {
            return RedirectToAction("Index", "Home");
        }
        //Validación del login
        [HttpPost]
        public ActionResult Login(tblUser collection)
        {
            try
            {
                //Validación de formulario
                var db = new DBPawnshopEntitiesConection();
                SqlParameter param1 = new SqlParameter("@email", collection.userEmail);
                SqlParameter param2 = new SqlParameter("@key", collection.userKey);
                var data = db.Database.SqlQuery<tblUser>("sp_GetUserLogin @email, @key", param1, param2).SingleOrDefault();
                if (data == null)
                {
                    TempData["Prueba"] = "SI";
                    @ViewData["ID"] = TempData["Prueba"];
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //Validación de datos
                    SqlParameter param3 = new SqlParameter("@email", collection.userEmail);
                    SqlParameter param4 = new SqlParameter("@key", collection.userKey);
                    var dataList = db.Database.SqlQuery<tblUser>("sp_GetUserLogin @email, @key", param3, param4).ToList();
                    var tipos = dataList.Select(x => x.userType);
                    String tipo = tipos.First().ToString();
                    var ID = dataList.Select(x => x.ID);
                    String idUser = ID.First().ToString();
                    //Pagína de ADMIN
                    if (tipo == "Admin")
                    {
                        System.Web.HttpContext.Current.Session["id"] = idUser;
                        return RedirectToAction("AdminIndex", "Admin");
                    }
                    else
                    {
                        //Pagína de USER
                        if (tipo == "User")
                        {
                            System.Web.HttpContext.Current.Session["id"] = idUser;
                            return RedirectToAction("UserIndex", "User");
                        }
                        //Pagína de ERROR
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }                        
                    }
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }        
        }
        //Página de creación de usuario
        public ActionResult Create()
        {
            return View();
        }
        //Página de creación de usuario
        [HttpPost]
        public ActionResult Create(tblUser collection)
        {
            
                //Creación de usuario
                var db = new DBPawnshopEntitiesConection();
                SqlParameter param1 = new SqlParameter("@email", collection.userEmail);
                SqlParameter param2 = new SqlParameter("@key", collection.userKey);
                SqlParameter param3 = new SqlParameter("@type", collection.userType);                
                var data = db.Database.ExecuteSqlCommand("setUserData @email, @key, @type", param1, param2, param3);
                return RedirectToAction("Index");                    
        }
    }
}