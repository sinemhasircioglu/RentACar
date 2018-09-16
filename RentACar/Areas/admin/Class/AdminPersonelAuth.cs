using RentACar.Core.Infrastructure;
using RentACar.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RentACar.Areas.admin.Class
{
    public class AdminPersonelAuth : AuthorizeAttribute, IAuthorizationFilter
    {
        public static string Mesaj;
        private readonly IKullaniciRepository _kullaniciRepository = new KullaniciRepository();

        public AdminPersonelAuth()
        {
            IKullaniciRepository _kullaniciRepository = new KullaniciRepository();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);
            //Kullanıcı giriş yapmamışsa login sayfasına at
            var SessionControl = wrapper.Session["KullaniciId"];
            if (SessionControl == null )
            {
                httpContext.Response.Redirect("/admin/Account/Login");
            }
            else
            {
                //session'daki kullanıcı idsini alıyoruz
                int gelenKullanici = (int)wrapper.Session["KullaniciId"];
                //idsini aldığım kullanıcıyı db'den çekiyoruz
                var user = _kullaniciRepository.Get(x => x.Id == gelenKullanici);
                //kullanıcı admin veya personel ise 
                if (user.Rol.Ad == "Personel" || user.Rol.Ad == "Admin")
                {
                    return true;
                }
                else
                {
                    Mesaj = "Bu işleme yetkiniz yoktur.";
                    httpContext.Response.Redirect("/admin/Home/Index");
                }
            }
            return base.AuthorizeCore(httpContext);
        }
    }
}