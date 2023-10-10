using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FW.UI
{
    public class CaminhoConfig
    {

        public static string RaizPath => HttpContext.Current.Server.MapPath("~/");
        public static string IconesPath => HttpContext.Current.Server.MapPath("~/Imagens/icones/bootstrap-icons.svg#");
        public static string ObjetosEmpresaPath => HttpContext.Current.Server.MapPath("~/Images/objetos-empresa/");
        public static string UndrawPath => HttpContext.Current.Server.MapPath("~/Images/undraw/");
        public static string ImagensPath => HttpContext.Current.Server.MapPath("~/Images/");
        public static string ClientCurriculoPath => HttpContext.Current.Server.MapPath("~/Cliente/curriculo/");
        public static string ClientFotoPath => HttpContext.Current.Server.MapPath("~/Cliente/foto_cliente/");
        public static string ClientPath => HttpContext.Current.Server.MapPath("~/Cliente/");
        public static string ScriptsPath => HttpContext.Current.Server.MapPath("~/scripts/");
        public static string EmpresaPath => HttpContext.Current.Server.MapPath("~/empr/");
        public static string ProfissionalPath => HttpContext.Current.Server.MapPath("~/pro/");
        public static string ContainersPath => HttpContext.Current.Server.MapPath("~/containers/");
        public static string ContainersAspxPath => HttpContext.Current.Server.MapPath("~/containers/aspx");
        public static string ContainersAscxPath => HttpContext.Current.Server.MapPath("~/containers/ascx/");

    }
}