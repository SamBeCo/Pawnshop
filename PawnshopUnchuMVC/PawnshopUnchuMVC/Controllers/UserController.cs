using PawnshopUnchuMVC.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

namespace PawnshopUnchuMVC.Controllers
{
    public class UserController : Controller
    {
                
        // GET: User
        public ActionResult Index()
        {
            var idUser = System.Web.HttpContext.Current.Session["id"];
            if(idUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }            
        }
        //Dashboard de administrador
        public ActionResult UserIndex()
        {
            //String prueba = TempData["id"] as String;
            var idUser = System.Web.HttpContext.Current.Session["id"];

            if (idUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                @ViewData["ID"] = idUser;
            }
            return View();
        }
        //Cerrar sesión
        public ActionResult Logout()
        {
            //Sessión en null
            System.Web.HttpContext.Current.Session["id"] = null;
            return RedirectToAction("Index", "Home");
        }
        //Página de registro de producto
        public ActionResult AdminRegProduct()
        {
            return View();
        }
        //Página de registro de producto
        [HttpPost]
        public ActionResult AdminRegProduct(tblGarment collection)
        {
            try
            {
                //Registro de imagen
                HttpPostedFileBase FileBase = Request.Files[0];
                WebImage image = new WebImage(FileBase.InputStream);     
                string idUser = System.Web.HttpContext.Current.Session["id"].ToString();
                SqlParameter param1 = new SqlParameter("@name", collection.gmtName);
                SqlParameter param2 = new SqlParameter("@tipo", collection.gmtType);
                SqlParameter param3 = new SqlParameter("@condicion", collection.gmtCondition);
                SqlParameter param4 = new SqlParameter("@precio", collection.gmtPrice);
                SqlParameter param5 = new SqlParameter("@user", idUser);
                SqlParameter param6 = new SqlParameter("@img", collection.gmtImage = image.GetBytes());
                //Registro de producto
                var db = new DBPawnshopEntitiesConection();
                db.Database.ExecuteSqlCommand("setGarmet @name, @tipo, @condicion, @precio,@user,@img", param1, param2, param3, param4, param5,param6);
                TempData["Prueba"] = "SI";
                @ViewData["ID"] = TempData["Prueba"];
                return View();
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
        //Página de edición de producto
        public ActionResult AdminEditProduct()
        {
            string idUser = System.Web.HttpContext.Current.Session["id"].ToString();
            SqlParameter param1 = new SqlParameter("@id", idUser);
            DBPawnshopEntitiesConection db = new DBPawnshopEntitiesConection();
            //Lista de productos por usuario
            var getProducts = db.Database.SqlQuery<tblGarment>("getProducXUser @id", param1).ToList();
            SelectList list = new SelectList(getProducts, "gmtID", "gmtName");
            ViewBag.Services = list;
            return View();
        }
        //Página de edición de producto
        [HttpPost]
        public ActionResult AdminEditProduct(tblGarment collection)
        {
            //Creación de sesión del producto
            var optionValue = Request.Form["Producto"];
            System.Web.HttpContext.Current.Session["idGar"] = optionValue;
            return RedirectToAction("AdminEditProduct2");
        }
        //Pagina de edición del producto - formulario del producto
        public ActionResult AdminEditProduct2()
        {
            string idProd = System.Web.HttpContext.Current.Session["idGar"].ToString();
            //Cargado de la data del producto creado
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", idProd);
            var data = db.Database.SqlQuery<tblGarment>("getDataGar @id", param1).FirstOrDefault();
            return View(data);            
        }
        //Pagina de edición del producto - formulario del producto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminEditProduct2(tblGarment collection)
        {
            //Obtención de datos del formulario
            var db = new DBPawnshopEntitiesConection();
            tblGarment _dbp = new tblGarment();
            HttpPostedFileBase FileBase = Request.Files[0];
            string idProd = System.Web.HttpContext.Current.Session["idGar"].ToString();
            string idUser = System.Web.HttpContext.Current.Session["id"].ToString();
            //Validación de edición de imagen
            if (FileBase.ContentLength == 0)
            {
                //Edición de producto con misma imagen
                _dbp = db.tblGarment.Find(idProd);  
                SqlParameter param1 = new SqlParameter("@id", idProd);
                SqlParameter param2 = new SqlParameter("@name", collection.gmtName);
                SqlParameter param3 = new SqlParameter("@tipo", collection.gmtType);
                SqlParameter param4 = new SqlParameter("@condicion", collection.gmtCondition);
                SqlParameter param5 = new SqlParameter("@precio", collection.gmtPrice);
                SqlParameter param6 = new SqlParameter("@user", idUser);
                SqlParameter param7 = new SqlParameter("@img", collection.gmtImage = _dbp.gmtImage);
                var data = db.Database.ExecuteSqlCommand("updateGarmetData @id, @name,@tipo,@condicion,@precio,@user,@img", param1, param2, param3, param4, param5, param6,param7);
                TempData["Prueba"] = "SI";
                @ViewData["ID"] = TempData["Prueba"];
                return View();

            }
            else
            {
                //Edición de producto con nueva imagen
                WebImage image = new WebImage(FileBase.InputStream);                
                SqlParameter param1 = new SqlParameter("@id", idProd);
                SqlParameter param2 = new SqlParameter("@name", collection.gmtName);
                SqlParameter param3 = new SqlParameter("@tipo", collection.gmtType);
                SqlParameter param4 = new SqlParameter("@condicion", collection.gmtCondition);
                SqlParameter param5 = new SqlParameter("@precio", collection.gmtPrice);
                SqlParameter param6 = new SqlParameter("@user", idUser);
                SqlParameter param7 = new SqlParameter("@img", collection.gmtImage = image.GetBytes());
                var data = db.Database.ExecuteSqlCommand("updateGarmetData @id, @name,@tipo,@condicion,@precio,@user,@img", param1, param2, param3, param4, param5, param6, param7);
                TempData["Prueba"] = "SI";
                @ViewData["ID"] = TempData["Prueba"];
                return View();
            }
        }
        //Clase de obtención de imagen
        public ActionResult getImage()
        {
            //Obtención de imagen
            string idProd = System.Web.HttpContext.Current.Session["idGar"].ToString();
            var db = new DBPawnshopEntitiesConection();
            tblGarment img = db.tblGarment.Find(idProd);
            byte[] byteImage = img.gmtImage;
            //Asignación a memoria
            MemoryStream memoryStream = new MemoryStream(byteImage);
            System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;            
            return File(memoryStream,"image/jpg");
        }
        //Pagina de eliminación de producto
        public ActionResult AdminDeleteProduct()
        {
            //Carga lista de productos
            string idUser = System.Web.HttpContext.Current.Session["id"].ToString();
            SqlParameter param1 = new SqlParameter("@id", idUser);
            DBPawnshopEntitiesConection db = new DBPawnshopEntitiesConection();
            var getProducts = db.Database.SqlQuery<tblGarment>("getProducXUser @id", param1).ToList();
            SelectList list = new SelectList(getProducts, "gmtID", "gmtName");
            ViewBag.Services = list;
            return View();
        }
        //Pagina de elimincación de producto
        [HttpPost]
        public ActionResult AdminDeleteProduct(tblGarment collection)
        {
            //Selección del producto
            var optionValue = Request.Form["Producto"];
            System.Web.HttpContext.Current.Session["idGar"] = optionValue;
            return RedirectToAction("AdminDeleteProduct2");
        }
        //Pagína de eliminación de producto - formulario del producto
        public ActionResult AdminDeleteProduct2()
        {
            //Cargado de los datos del producto
            string idProd = System.Web.HttpContext.Current.Session["idGar"].ToString();
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", idProd);
            var data = db.Database.SqlQuery<tblGarment>("getDataGar @id", param1).FirstOrDefault();
            return View(data);
        }
        //Pagína de eliminación de producto - formulario del producto
        [HttpPost]
        public ActionResult AdminDeleteProduct2(FormCollection collection)
        {
            //Eliminación del producto
            string idProd = System.Web.HttpContext.Current.Session["idGar"].ToString();
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", idProd);
            db.Database.ExecuteSqlCommand("deleteGarment @id", param1);
            return RedirectToAction("AdminDeleteProduct");
        }
        //Obtención de imagen de producto
        public ActionResult getImageGar(string id)
        {            
            var db = new DBPawnshopEntitiesConection();
            tblGarment img = db.tblGarment.Find(id);
            byte[] byteImage = img.gmtImage;
            MemoryStream memoryStream = new MemoryStream(byteImage);
            System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;
            return File(memoryStream, "image/jpg");
        }
        //Página de lista de productos
        public ActionResult AdminListProduct()
        {
            //Lista de productos por usuario
            DBPawnshopEntitiesConection db = new DBPawnshopEntitiesConection();
            string idUser = System.Web.HttpContext.Current.Session["id"].ToString();
            SqlParameter param1 = new SqlParameter("@id", idUser);
            var data = db.Database.SqlQuery<tblGarment>("getProductData @id", param1);
            return View(data.ToList());
        }


        //BRECHA


        //Página de registrar información de usuario
        public ActionResult UserRegInfo()
        {
            //Validar edición
            var db = new DBPawnshopEntitiesConection();
            string idUser = System.Web.HttpContext.Current.Session["id"].ToString();
            SqlParameter param1 = new SqlParameter("@id", idUser);
            var data = db.Database.SqlQuery<tblInfoUser>("exec sp_validarInfo @id", param1).ToList();
            var tipos = data.Select(x => x.usID);
            //Validar si existe información o no
            if(tipos.FirstOrDefault() != null)
            {
                TempData["Pruebas"] = "SI";
                @ViewData["IDs"] = TempData["Prueba"];
                return View();
            }
            else
            {
                return View();
            }            
        }
        //Pagina de registrar información de usuario
        [HttpPost]
        public ActionResult UserRegInfo(tblInfoUser collection)
        {
            //Registrar información de usuario
            try
            {
                string idUser = System.Web.HttpContext.Current.Session["id"].ToString();
                SqlParameter param1 = new SqlParameter("@dni", collection.DNI);
                SqlParameter param2 = new SqlParameter("@name", collection.usInfFirstName);
                SqlParameter param3 = new SqlParameter("@lstfname", collection.usInfLastNameF);
                SqlParameter param4 = new SqlParameter("@lstmname", collection.usInfLastNameM);
                SqlParameter param5 = new SqlParameter("@phone", collection.usInfPhone);
                SqlParameter param6 = new SqlParameter("@id", idUser);
                var db = new DBPawnshopEntitiesConection();
                db.Database.ExecuteSqlCommand("setInfoUser @dni, @name, @lstfname, @lstmname,@phone,@id", param1, param2, param3, param4, param5, param6);
                TempData["Prueba"] = "SI";
                @ViewData["ID"] = TempData["Prueba"];
                return View();
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
        //Página de editar información
        public ActionResult UserEditInfo()
        {
            //Cargado de datos del usuario
            var idUser = System.Web.HttpContext.Current.Session["id"];
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", idUser);
            var data = db.Database.SqlQuery<tblInfoUser>("sp_validarInfo @id", param1).FirstOrDefault();
            return View(data);            
        }
        //Página de editar información
        [HttpPost]
        public ActionResult UserEditInfo(tblInfoUser collection)
        {
            //Edición de la información
            try
            {
                string idUser = System.Web.HttpContext.Current.Session["id"].ToString();
                SqlParameter param1 = new SqlParameter("@dni", collection.DNI);
                SqlParameter param2 = new SqlParameter("@name", collection.usInfFirstName);
                SqlParameter param3 = new SqlParameter("@lstfname", collection.usInfLastNameF);
                SqlParameter param4 = new SqlParameter("@lstmname", collection.usInfLastNameM);
                SqlParameter param5 = new SqlParameter("@phone", collection.usInfPhone);
                SqlParameter param6 = new SqlParameter("@id", idUser);
                var db = new DBPawnshopEntitiesConection();
                db.Database.ExecuteSqlCommand("updateInfoDataUser @dni, @name, @lstfname, @lstmname,@phone,@id", param1, param2, param3, param4, param5, param6);
                TempData["Prueba"] = "SI";
                @ViewData["ID"] = TempData["Prueba"];
                return View();
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
        //Página de editar solicitud
        public ActionResult UserRegSolicitud()
        {
            string idUser = System.Web.HttpContext.Current.Session["id"].ToString();
            SqlParameter param1 = new SqlParameter("@id", idUser);
            DBPawnshopEntitiesConection db = new DBPawnshopEntitiesConection();
            //Lista de productos por usuario
            var getProducts = db.Database.SqlQuery<tblGarment>("getProducXUser @id", param1).ToList();
            SelectList list = new SelectList(getProducts, "gmtID", "gmtName");
            ViewBag.Services = list;
            return View();
        }
        //Página de edición de producto
        [HttpPost]
        public ActionResult UserRegSolicitud(tblGarment collection)
        {
            //Creación de sesión del producto
            var optionValue = Request.Form["Producto"];
            System.Web.HttpContext.Current.Session["idGar"] = optionValue;
            return RedirectToAction("UserRegSolicitud2");            
        }
        //Página de registrar solicitud
        public ActionResult UserRegSolicitud2()
        {
            return View();
        }
        //Página de registrar solicitud
        [HttpPost]
        public ActionResult UserRegSolicitud2(tblSolicitude collection)
        {
            //Sesiones de usuario y producto
            string idUser = System.Web.HttpContext.Current.Session["id"].ToString();
            string idGar = System.Web.HttpContext.Current.Session["idGar"].ToString();
            //Registrar solicitud respecto al producto
            SqlParameter param1 = new SqlParameter("@id", idUser);
            SqlParameter param2 = new SqlParameter("@idProd", idGar);
            SqlParameter param3 = new SqlParameter("@fecha", collection.solFecha);
            SqlParameter param4 = new SqlParameter("@hora", collection.solHora);            
            var db = new DBPawnshopEntitiesConection();
            db.Database.ExecuteSqlCommand("setSolicitude @id,@idProd, @fecha, @hora", param1,param2, param3, param4);
            TempData["Prueba"] = "SI";
            @ViewData["ID"] = TempData["Prueba"];                        
            return View();
        }
        //Página de editar solicitud
        public ActionResult UserEditSolicitud()
        {
            string idUser = System.Web.HttpContext.Current.Session["id"].ToString();
            SqlParameter param1 = new SqlParameter("@id", idUser);
            DBPawnshopEntitiesConection db = new DBPawnshopEntitiesConection();
            //Lista de solicitudes por usuario
            var getSolicitude = db.Database.SqlQuery<tblSolicitude>("getSolicitudexUser @id", param1).ToList();
            SelectList list = new SelectList(getSolicitude, "solID", "solProdName");
            ViewBag.Services = list;
            return View();
        }
        //Página de editar solicitud
        [HttpPost]
        public ActionResult UserEditSolicitud(tblSolicitude collection)
        {
            //Lista de solicitudes
            var optionValue = Request.Form["Solicitud"];
            System.Web.HttpContext.Current.Session["idSol"] = optionValue;
            return RedirectToAction("UserEditSolicitud2");             
        }
        //Página de editar solicitud
        public ActionResult UserEditSolicitud2()
        {
            string idSol = System.Web.HttpContext.Current.Session["idSol"].ToString();
            //Cargado de la data de la solicitud creado
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", idSol);
            var data = db.Database.SqlQuery<tblSolicitude>("getDataSolicitude @id", param1).FirstOrDefault();
            return View(data);
        }
        //Página de editar solicitud
        [HttpPost]
        public ActionResult UserEditSolicitud2(tblSolicitude collection)
        {
            string idSol = System.Web.HttpContext.Current.Session["idSol"].ToString();            
            //Editar solicitud
            SqlParameter param1 = new SqlParameter("@id", idSol);
            SqlParameter param2 = new SqlParameter("@fecha", collection.solFecha);
            SqlParameter param3 = new SqlParameter("@hora", collection.solHora);
            var db = new DBPawnshopEntitiesConection();
            db.Database.ExecuteSqlCommand("updateSoliData @id, @fecha, @hora", param1, param2, param3);
            TempData["Prueba"] = "SI";
            @ViewData["ID"] = TempData["Prueba"];
            return View();
        }
        //Página de eliminar solicitud
        public ActionResult UserDelSolicitud()
        {
            string idUser = System.Web.HttpContext.Current.Session["id"].ToString();
            SqlParameter param1 = new SqlParameter("@id", idUser);
            DBPawnshopEntitiesConection db = new DBPawnshopEntitiesConection();
            //Lista de solicitudes por usuario
            var getSolicitude = db.Database.SqlQuery<tblSolicitude>("getSolicitudexUser @id", param1).ToList();
            SelectList list = new SelectList(getSolicitude, "solID", "solProdName");
            ViewBag.Services = list;
            return View();
        }
        //Página de eliminar solicitud
        [HttpPost]
        public ActionResult UserDelSolicitud(tblSolicitude collection)
        {
            var optionValue = Request.Form["Solicitud"];
            System.Web.HttpContext.Current.Session["idSol"] = optionValue;
            return RedirectToAction("UserDelSolicitud2");
        }
        //Página de eliminar solicitud - formulario de eliminación
        public ActionResult UserDelSolicitud2()
        {
            string idSol = System.Web.HttpContext.Current.Session["idSol"].ToString();
            //Cargado de la data del producto creado
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", idSol);
            var data = db.Database.SqlQuery<tblSolicitude>("getDataSolicitude @id", param1).FirstOrDefault();
            return View(data);
        }
        //Página de eliminar solicitud - formulario de eliminación
        [HttpPost]
        public ActionResult UserDelSolicitud2(tblSolicitude collection)
        {
            //Eliminación de la solicitud
            string idSol = System.Web.HttpContext.Current.Session["idSol"].ToString();
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", idSol);
            db.Database.ExecuteSqlCommand("deleteSolicitude @id", param1);
            return RedirectToAction("UserDelSolicitud");
        }
        //Página de lista de solicitudes
        public ActionResult UserListSolicitud()
        {
            DBPawnshopEntitiesConection db = new DBPawnshopEntitiesConection();
            string idUser = System.Web.HttpContext.Current.Session["id"].ToString();
            SqlParameter param1 = new SqlParameter("@id", idUser);
            var data = db.Database.SqlQuery<tblSolicitude>("getSolicitudeData @id", param1);
            return View(data.ToList());
        }
        //Pagina de últimos mensajes
        public ActionResult UserLastMessages()
        {
            DBPawnshopEntitiesConection db = new DBPawnshopEntitiesConection();
            string idUser = System.Web.HttpContext.Current.Session["id"].ToString();
            SqlParameter param1 = new SqlParameter("@id", idUser);
            var data = db.Database.SqlQuery<tblSolicitude>("UserLastMessages @id", param1);
            return View(data.ToList());
        }
        public ActionResult DetailSoli(string id)
        {
            DBPawnshopEntitiesConection db = new DBPawnshopEntitiesConection();            
            SqlParameter param1 = new SqlParameter("@id", id);
            //Datos del producto
            var dataList = db.Database.SqlQuery<tblSolicitude>("getDatasSoli @id", param1).ToList();            
            var tipos = dataList.Select(x => x.solProdName);
            var tipos2 = dataList.Select(x => x.solEstado);
            String solProdName = tipos.First().ToString();
            String solEstado = tipos2.First().ToString();
            //Datos de usuario
            string idUser = System.Web.HttpContext.Current.Session["id"].ToString();
            SqlParameter param2 = new SqlParameter("@id", idUser);
            var data = db.Database.SqlQuery<tblInfoUser>("sp_validarInfo @id", param2).ToList();
            var tipo1 = data.Select(x => x.usInfFirstName);
            var tipo2 = data.Select(x => x.usInfLastNameF);
            var tipo3 = data.Select(x => x.usInfLastNameM);
            String userName = tipo1.First().ToString();
            String lstNameF = tipo2.First().ToString();
            String lstNameM = tipo3.First().ToString();
            //Datos de mensaje
            @ViewData["Prodname"] = solProdName;
            @ViewData["Soliestado"] = solEstado;
            @ViewData["Username"] = userName;
            @ViewData["LstnameF"] = lstNameF;
            @ViewData["LstnameM"] = lstNameM;
            return View();
        }
    }
}