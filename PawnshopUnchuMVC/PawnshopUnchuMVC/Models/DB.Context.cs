﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PawnshopUnchuMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBPawnshopEntitiesConection : DbContext
    {
        public DBPawnshopEntitiesConection()
            : base("name=DBPawnshopEntitiesConection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblBusiness> tblBusiness { get; set; }
        public virtual DbSet<tblGarment> tblGarment { get; set; }
        public virtual DbSet<tblInfoUser> tblInfoUser { get; set; }
        public virtual DbSet<tblServices> tblServices { get; set; }
        public virtual DbSet<tblUser> tblUser { get; set; }
        public virtual DbSet<tblSolicitude> tblSolicitude { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    
        public virtual ObjectResult<tblUser> getUserData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tblUser>("getUserData");
        }
    
        public virtual ObjectResult<tblUser> getUserData(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tblUser>("getUserData", mergeOption);
        }
    
        public virtual ObjectResult<tblUser> sp_getUserData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tblUser>("sp_getUserData");
        }
    
        public virtual ObjectResult<tblUser> sp_getUserData(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tblUser>("sp_getUserData", mergeOption);
        }
    
        public virtual ObjectResult<tblUser> setUserData(string email, string key, string type)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var keyParameter = key != null ?
                new ObjectParameter("key", key) :
                new ObjectParameter("key", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tblUser>("setUserData", emailParameter, keyParameter, typeParameter);
        }
    
        public virtual ObjectResult<tblUser> setUserData(string email, string key, string type, MergeOption mergeOption)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var keyParameter = key != null ?
                new ObjectParameter("key", key) :
                new ObjectParameter("key", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tblUser>("setUserData", mergeOption, emailParameter, keyParameter, typeParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<tblUser> sp_GetUserLogin(string email, string key)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var keyParameter = key != null ?
                new ObjectParameter("key", key) :
                new ObjectParameter("key", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tblUser>("sp_GetUserLogin", emailParameter, keyParameter);
        }
    
        public virtual ObjectResult<tblUser> sp_GetUserLogin(string email, string key, MergeOption mergeOption)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var keyParameter = key != null ?
                new ObjectParameter("key", key) :
                new ObjectParameter("key", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tblUser>("sp_GetUserLogin", mergeOption, emailParameter, keyParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<tblUser> sp_GetUserLogin1(string email, string key)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var keyParameter = key != null ?
                new ObjectParameter("key", key) :
                new ObjectParameter("key", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tblUser>("sp_GetUserLogin1", emailParameter, keyParameter);
        }
    
        public virtual ObjectResult<tblUser> sp_GetUserLogin1(string email, string key, MergeOption mergeOption)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var keyParameter = key != null ?
                new ObjectParameter("key", key) :
                new ObjectParameter("key", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<tblUser>("sp_GetUserLogin1", mergeOption, emailParameter, keyParameter);
        }
    
        public virtual int deleteBus(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteBus", idParameter);
        }
    
        public virtual int deleteGarment(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteGarment", idParameter);
        }
    
        public virtual int deleteServ(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteServ", idParameter);
        }
    
        public virtual int deleteSolicitude(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteSolicitude", idParameter);
        }
    
        public virtual ObjectResult<getDataBus_Result> getDataBus(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getDataBus_Result>("getDataBus", idParameter);
        }
    
        public virtual ObjectResult<getDataGar_Result> getDataGar(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getDataGar_Result>("getDataGar", idParameter);
        }
    
        public virtual ObjectResult<getDataServ_Result> getDataServ(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getDataServ_Result>("getDataServ", idParameter);
        }
    
        public virtual ObjectResult<getDataSolicitude_Result> getDataSolicitude(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getDataSolicitude_Result>("getDataSolicitude", idParameter);
        }
    
        public virtual ObjectResult<getDatosUserxSoli_Result> getDatosUserxSoli(string ids)
        {
            var idsParameter = ids != null ?
                new ObjectParameter("ids", ids) :
                new ObjectParameter("ids", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getDatosUserxSoli_Result>("getDatosUserxSoli", idsParameter);
        }
    
        public virtual ObjectResult<string> getIDUserxSoli(string ids)
        {
            var idsParameter = ids != null ?
                new ObjectParameter("ids", ids) :
                new ObjectParameter("ids", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("getIDUserxSoli", idsParameter);
        }
    
        public virtual ObjectResult<getNewSolicitudes_Result> getNewSolicitudes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getNewSolicitudes_Result>("getNewSolicitudes");
        }
    
        public virtual ObjectResult<getProductData_Result> getProductData(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getProductData_Result>("getProductData", idParameter);
        }
    
        public virtual ObjectResult<getProducts_Result> getProducts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getProducts_Result>("getProducts");
        }
    
        public virtual ObjectResult<getProducXUser_Result> getProducXUser(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getProducXUser_Result>("getProducXUser", idParameter);
        }
    
        public virtual ObjectResult<getServices_Result> getServices()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getServices_Result>("getServices");
        }
    
        public virtual ObjectResult<getSolicitudeData_Result> getSolicitudeData(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getSolicitudeData_Result>("getSolicitudeData", idParameter);
        }
    
        public virtual ObjectResult<getSolicitudexUser_Result> getSolicitudexUser(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getSolicitudexUser_Result>("getSolicitudexUser", idParameter);
        }
    
        public virtual int setGarmet(string name, string tipo, string condicion, Nullable<decimal> precio, string user, byte[] img)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(string));
    
            var condicionParameter = condicion != null ?
                new ObjectParameter("condicion", condicion) :
                new ObjectParameter("condicion", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            var imgParameter = img != null ?
                new ObjectParameter("img", img) :
                new ObjectParameter("img", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("setGarmet", nameParameter, tipoParameter, condicionParameter, precioParameter, userParameter, imgParameter);
        }
    
        public virtual int setInfoBs(string name, string ubicacion, string email, string rama, string telefono)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var ubicacionParameter = ubicacion != null ?
                new ObjectParameter("ubicacion", ubicacion) :
                new ObjectParameter("ubicacion", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var ramaParameter = rama != null ?
                new ObjectParameter("rama", rama) :
                new ObjectParameter("rama", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("setInfoBs", nameParameter, ubicacionParameter, emailParameter, ramaParameter, telefonoParameter);
        }
    
        public virtual int setInfoUser(string dni, string name, string lstfname, string lstmname, string phone, string id)
        {
            var dniParameter = dni != null ?
                new ObjectParameter("dni", dni) :
                new ObjectParameter("dni", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var lstfnameParameter = lstfname != null ?
                new ObjectParameter("lstfname", lstfname) :
                new ObjectParameter("lstfname", typeof(string));
    
            var lstmnameParameter = lstmname != null ?
                new ObjectParameter("lstmname", lstmname) :
                new ObjectParameter("lstmname", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("setInfoUser", dniParameter, nameParameter, lstfnameParameter, lstmnameParameter, phoneParameter, idParameter);
        }
    
        public virtual int setServName(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("setServName", nameParameter);
        }
    
        public virtual int setSolicitude(string id, string idGar, Nullable<System.DateTime> fecha, Nullable<System.TimeSpan> hora)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var idGarParameter = idGar != null ?
                new ObjectParameter("idGar", idGar) :
                new ObjectParameter("idGar", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            var horaParameter = hora.HasValue ?
                new ObjectParameter("hora", hora) :
                new ObjectParameter("hora", typeof(System.TimeSpan));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("setSolicitude", idParameter, idGarParameter, fechaParameter, horaParameter);
        }
    
        public virtual ObjectResult<sp_validarInfo_Result> sp_validarInfo(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_validarInfo_Result>("sp_validarInfo", idParameter);
        }
    
        public virtual int updateGarmetData(string id, string name, string tipo, string condicion, Nullable<decimal> precio, string user, byte[] img)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(string));
    
            var condicionParameter = condicion != null ?
                new ObjectParameter("condicion", condicion) :
                new ObjectParameter("condicion", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            var imgParameter = img != null ?
                new ObjectParameter("img", img) :
                new ObjectParameter("img", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateGarmetData", idParameter, nameParameter, tipoParameter, condicionParameter, precioParameter, userParameter, imgParameter);
        }
    
        public virtual int updateInfoData(string id, string name, string ubicacion, string email, string rama, string telefono)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var ubicacionParameter = ubicacion != null ?
                new ObjectParameter("ubicacion", ubicacion) :
                new ObjectParameter("ubicacion", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var ramaParameter = rama != null ?
                new ObjectParameter("rama", rama) :
                new ObjectParameter("rama", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateInfoData", idParameter, nameParameter, ubicacionParameter, emailParameter, ramaParameter, telefonoParameter);
        }
    
        public virtual int updateInfoDataUser(string dni, string name, string lstfname, string lstmname, string phone, string id)
        {
            var dniParameter = dni != null ?
                new ObjectParameter("dni", dni) :
                new ObjectParameter("dni", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var lstfnameParameter = lstfname != null ?
                new ObjectParameter("lstfname", lstfname) :
                new ObjectParameter("lstfname", typeof(string));
    
            var lstmnameParameter = lstmname != null ?
                new ObjectParameter("lstmname", lstmname) :
                new ObjectParameter("lstmname", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateInfoDataUser", dniParameter, nameParameter, lstfnameParameter, lstmnameParameter, phoneParameter, idParameter);
        }
    
        public virtual int updateServData(string id, string name)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateServData", idParameter, nameParameter);
        }
    
        public virtual int updateSoliData(string id, Nullable<System.DateTime> fecha, Nullable<System.TimeSpan> hora)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            var horaParameter = hora.HasValue ?
                new ObjectParameter("hora", hora) :
                new ObjectParameter("hora", typeof(System.TimeSpan));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateSoliData", idParameter, fechaParameter, horaParameter);
        }
    
        public virtual int cancelSolicitud(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("cancelSolicitud", idParameter);
        }
    
        public virtual int confirmSolicitud(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("confirmSolicitud", idParameter);
        }
    
        public virtual ObjectResult<getDatasSoli_Result> getDatasSoli(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getDatasSoli_Result>("getDatasSoli", idParameter);
        }
    
        public virtual ObjectResult<getIdProdxSoli_Result> getIdProdxSoli(string usID, string gmtName)
        {
            var usIDParameter = usID != null ?
                new ObjectParameter("usID", usID) :
                new ObjectParameter("usID", typeof(string));
    
            var gmtNameParameter = gmtName != null ?
                new ObjectParameter("gmtName", gmtName) :
                new ObjectParameter("gmtName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getIdProdxSoli_Result>("getIdProdxSoli", usIDParameter, gmtNameParameter);
        }
    
        public virtual ObjectResult<getIDUserxSolic_Result> getIDUserxSolic(string ids)
        {
            var idsParameter = ids != null ?
                new ObjectParameter("ids", ids) :
                new ObjectParameter("ids", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getIDUserxSolic_Result>("getIDUserxSolic", idsParameter);
        }
    
        public virtual ObjectResult<getListSolicitudes_Result> getListSolicitudes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getListSolicitudes_Result>("getListSolicitudes");
        }
    
        public virtual ObjectResult<UserLastMessages_Result> UserLastMessages(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UserLastMessages_Result>("UserLastMessages", idParameter);
        }
    
        public virtual int sp_alterdiagram1(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram1", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram1(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram1", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram1(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram1", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition1_Result> sp_helpdiagramdefinition1(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition1_Result>("sp_helpdiagramdefinition1", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams1_Result> sp_helpdiagrams1(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams1_Result>("sp_helpdiagrams1", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram1(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram1", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams1");
        }
    }
}
