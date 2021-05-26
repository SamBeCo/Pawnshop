using PawnshopUnchuMVC.Models;
using System;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PawnshopUnchuMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        //Página de inicio
        public ActionResult AdminIndex()
        {
            //String prueba = TempData["id"] as String;
            var idUser = System.Web.HttpContext.Current.Session["id"];

            if (idUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else{
                @ViewData["ID"] = idUser;
            }            
            return View();
        }
        //Clase de cerrar sesión
        public ActionResult Logout()
        {
            //Inicializar el session en null
            System.Web.HttpContext.Current.Session["id"] = null;
            return RedirectToAction("Index", "Home");
        }
        //Página de registrar servicios
        public ActionResult AdminRegServices()
        {
            return View();
        }
        //Página de registrar servicios
        [HttpPost]
        public ActionResult AdminRegServices(tblServices collection)
        {
            try
            {
                //Registrar datos
                SqlParameter param1 = new SqlParameter("@name", collection.servName);
                var db = new DBPawnshopEntitiesConection();
                var data = db.Database.ExecuteSqlCommand("setServName @name", param1);
                TempData["Prueba"] = "SI";
                @ViewData["ID"] = TempData["Prueba"];                   
                return View();
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
        //Página de editar servicios
        public ActionResult AdminEditServices()
        {
            //Cargar lista de servicios
            DBPawnshopEntitiesConection db = new DBPawnshopEntitiesConection();
            var getServices = db.tblServices.ToList();
            SelectList list = new SelectList(getServices, "servID", "servName");
            ViewBag.Services = list;
            return View();
        }
        //Página de editar servicios
        [HttpPost]
        public ActionResult AdminEditServices(SelectListItem item)
        {            
            //Crear sesión de idServicio
            var optionValue = Request.Form["Servicios"];
            System.Web.HttpContext.Current.Session["idServ"] = optionValue;
            return RedirectToAction("AdminEditServices2");
        }
        //Paágina de editar servivios - Formulario de servicios
        public ActionResult AdminEditServices2()
        {
            //Cargado de datos
            string idServicio = System.Web.HttpContext.Current.Session["idServ"].ToString();
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", idServicio);
            var data = db.Database.SqlQuery<tblServices>("getDataServ @id", param1).FirstOrDefault();
            return View(data);
        }
        //Paágina de editar servivios - Formulario de servicios
        [HttpPost]
        public ActionResult AdminEditServices2(tblServices collection)
        {
            try
            {
                //Edición del servicio
                string idServicios = System.Web.HttpContext.Current.Session["idServ"].ToString();
                var db = new DBPawnshopEntitiesConection();
                SqlParameter param1 = new SqlParameter("@id", idServicios);
                SqlParameter param2 = new SqlParameter("@name", collection.servName);                
                var data = db.Database.ExecuteSqlCommand("updateServData @id, @name", param1, param2);
                TempData["Prueba"] = "SI";
                @ViewData["ID"] = TempData["Prueba"];
                return View();
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
        //Página de eliminar servicios
        public ActionResult AdminDeleteServices()
        {
            //Cargar lista de servivios
            DBPawnshopEntitiesConection db = new DBPawnshopEntitiesConection();
            var getServices = db.tblServices.ToList();
            SelectList list = new SelectList(getServices, "servID", "servName");
            ViewBag.Services = list;
            return View();            
        }
        //Página de eliminar servicios
        [HttpPost]
        public ActionResult AdminDeleteServices(SelectListItem item)
        {
            //Creación de sessión de IdServ
            var optionValue = Request.Form["Servicios"];
            System.Web.HttpContext.Current.Session["idServ"] = optionValue;
            return RedirectToAction("AdminDeleteServices2");
        }
        //Página de eliminar servicios - Formulario de servicios
        public ActionResult AdminDeleteServices2()
        {
            //Cargado de datos del servicio
            string idServicio = System.Web.HttpContext.Current.Session["idServ"].ToString();
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", idServicio);
            var data = db.Database.SqlQuery<tblServices>("getDataServ @id", param1).SingleOrDefault();
            return View(data);            
        }
        //Página de eliminar servicios - Formulario de servicios
        [HttpPost]
        public ActionResult AdminDeleteServices2(FormCollection collection)
        {
            //Eliminación del servicio
            string idServicio = System.Web.HttpContext.Current.Session["idServ"].ToString();
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", idServicio);
            db.Database.ExecuteSqlCommand("deleteServ @id", param1);
            return RedirectToAction("AdminDeleteServices");
        }
        //Página de registro de información
        public ActionResult AdminRegInfo()
        {
            return View();
        }
        //Página de registro de información
        [HttpPost]
        public ActionResult AdminRegInfo(tblBusiness collection)
        {
            try
            {
                //Registrar información del formulario
                SqlParameter param1 = new SqlParameter("@name", collection.bsName);
                SqlParameter param2 = new SqlParameter("@ubicacion", collection.bsLocation);
                SqlParameter param3 = new SqlParameter("@email", collection.bsEmail);
                SqlParameter param4 = new SqlParameter("@rama", collection.bsBranch);
                SqlParameter param5 = new SqlParameter("@telefono", collection.bsPhone);
                var db = new DBPawnshopEntitiesConection();
                var data = db.Database.ExecuteSqlCommand("setInfoBs @name, @ubicacion, @email, @rama,@telefono", param1,param2, param3, param4, param5);
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
        public ActionResult AdminEditInfo()
        {
            //Lista de información
            DBPawnshopEntitiesConection db = new DBPawnshopEntitiesConection();
            var getInfo = db.tblBusiness.ToList();
            SelectList list = new SelectList(getInfo, "bsID", "bsName");
            ViewBag.Business = list;
            return View();            
        }
        //Página de editar información
        [HttpPost]
        public ActionResult AdminEditInfo(SelectListItem item)
        {
            //Creación del sessión IdBus
            var optionValue = Request.Form["Información"];
            System.Web.HttpContext.Current.Session["idBus"] = optionValue;
            return RedirectToAction("AdminEditInfo2");
        }
        //Página de editar información - formulario de información
        public ActionResult AdminEditInfo2()
        {
            //Cargado de datos de la información
            string idBuss = System.Web.HttpContext.Current.Session["idBus"].ToString();
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", idBuss);
            var data = db.Database.SqlQuery<tblBusiness>("getDataBus @id", param1).FirstOrDefault();
            return View(data);            
        }
        //Página de editar información - formulario de información
        [HttpPost]
        public ActionResult AdminEditInfo2(tblBusiness collection)
        {
            try
            {
                //Edición de datos de la información
                string idBuss = System.Web.HttpContext.Current.Session["idBus"].ToString();
                var db = new DBPawnshopEntitiesConection();
                SqlParameter param1 = new SqlParameter("@id", idBuss);
                SqlParameter param2 = new SqlParameter("@name", collection.bsName);
                SqlParameter param3 = new SqlParameter("@ubicacion", collection.bsLocation);
                SqlParameter param4 = new SqlParameter("@email", collection.bsEmail);
                SqlParameter param5 = new SqlParameter("@rama", collection.bsBranch);
                SqlParameter param6 = new SqlParameter("@telefono", collection.bsPhone);
                var data = db.Database.ExecuteSqlCommand("updateInfoData @id, @name,@ubicacion,@email,@rama,@telefono", param1, param2,param3, param4, param5, param6);
                TempData["Prueba"] = "SI";
                @ViewData["ID"] = TempData["Prueba"];
                return View();
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
        //Página de eliminación de información
        public ActionResult AdminDeleteInfo()
        {
            //Lista de información
            DBPawnshopEntitiesConection db = new DBPawnshopEntitiesConection();
            var getInfo = db.tblBusiness.ToList();
            SelectList list = new SelectList(getInfo, "bsID", "bsName");
            ViewBag.Business = list;
            return View();
        }
        //Página de eliminación de información
        [HttpPost]
        public ActionResult AdminDeleteInfo(SelectListItem item)
        {
            //Creación de la sessión IdBus
            var optionValue = Request.Form["Información"];
            System.Web.HttpContext.Current.Session["idBus"] = optionValue;
            return RedirectToAction("AdminDeleteInfo2");
        }
        //Página de eliminación de información - formulario de información
        public ActionResult AdminDeleteInfo2()
        {
            //Cargado de datos de la información
            string idBus = System.Web.HttpContext.Current.Session["idBus"].ToString();
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", idBus);
            var data = db.Database.SqlQuery<tblBusiness>("getDataBus @id", param1).SingleOrDefault();
            return View(data);
        }
        //Página de eliminación de información - formulario de información
        [HttpPost]
        public ActionResult AdminDeleteInfo2(FormCollection collection)
        {
            //Eliminación de la información
            string idBus = System.Web.HttpContext.Current.Session["idBus"].ToString();
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", idBus);
            db.Database.ExecuteSqlCommand("deleteBus @id", param1);
            return RedirectToAction("AdminDeleteInfo");
        }
        public ActionResult AdminNewSolicitud()
        {
            DBPawnshopEntitiesConection db = new DBPawnshopEntitiesConection();                    
            var data = db.Database.SqlQuery<tblSolicitude>("getNewSolicitudes");
            return View(data.ToList());
        }
        public ActionResult DetailsUser(string id)
        {
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", id);
            var dataList = db.Database.SqlQuery<tblSolicitude>("getIDUserxSolic @id", param1).ToList();
            var tipos = dataList.Select(x => x.solUserID);
            String tipo = tipos.First().ToString();

            SqlParameter parame1 = new SqlParameter("@ids", tipo);
            var data = db.Database.SqlQuery<tblInfoUser>("getDatosUserxSoli @ids", parame1).FirstOrDefault();
            return View(data);          
        }

        public ActionResult DetailsProduct(string id)
        {
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", id);
            //Datos de la solicitud
            var dataList = db.Database.SqlQuery<tblSolicitude>("getIDUserxSolic @id", param1).ToList();
            var tipos = dataList.Select(x => x.solUserID);
            String tipo = tipos.First().ToString();
            var nombProd = dataList.Select(x => x.solProdName);
            String nombProds = nombProd.First().ToString();
            SqlParameter parama1 = new SqlParameter("@usID", tipo);
            SqlParameter parama2 = new SqlParameter("@gmtName", nombProds);
            //ID del producto
            var data = db.Database.SqlQuery<tblGarment>("getIdProdxSoli @usID,@gmtName", parama1,parama2).ToList();
            var idPro = data.Select(x => x.gmtID);
            String idProd = idPro.First().ToString();
            System.Web.HttpContext.Current.Session["idProduct"] = idProd;
            //Datos del procuto
            SqlParameter parametro = new SqlParameter("@id", idProd);
            var d = db.Database.SqlQuery<tblGarment>("getDataGar @id", parametro).FirstOrDefault();
            return View(d);
        }
        public ActionResult getImage()
        {
            //Obtención de imagen
            string idProd = System.Web.HttpContext.Current.Session["idProduct"].ToString();
            var db = new DBPawnshopEntitiesConection();
            tblGarment img = db.tblGarment.Find(idProd);
            byte[] byteImage = img.gmtImage;
            //Asignación a memoria
            MemoryStream memoryStream = new MemoryStream(byteImage);
            System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;
            return File(memoryStream, "image/jpg");
        }
        public ActionResult AdminListSolicitud()
        {
            DBPawnshopEntitiesConection db = new DBPawnshopEntitiesConection();
            var data = db.Database.SqlQuery<tblSolicitude>("getListSolicitudes");
            return View(data.ToList());
        }
        public ActionResult CancelSolicitude(string id)
        {
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand("cancelSolicitud @id", param1);
            TempData["Prueba"] = "SI";
            @ViewData["ID"] = TempData["Prueba"];
            return RedirectToAction("AdminNewSolicitud");            
        }
        public ActionResult ConfirmSolicitude(string id)
        {
            var db = new DBPawnshopEntitiesConection();
            SqlParameter param1 = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand("confirmSolicitud @id", param1);
            TempData["Pruebas"] = "SI";
            @ViewData["ID"] = TempData["Pruebas"];
            return RedirectToAction("AdminNewSolicitud");
        }
    }
}