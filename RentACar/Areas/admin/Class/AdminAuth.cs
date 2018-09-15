using RentACar.Core.Infrastructure;
using RentACar.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Areas.admin.Class
{
    public class AdminAuth : AuthorizeAttribute, IAuthorizationFilter
    {
        public static string Mesaj;
        private readonly IKullaniciRepository _kullaniciRepository = new KullaniciRepository();

        public AdminAuth()
        {
            IKullaniciRepository _kullaniciRepository = new KullaniciRepository();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);
            //Kullanıcı giriş yapmamışsa login sayfasına at
            var SessionControl = wrapper.Session["KullaniciId"];
            if (SessionControl == null)
            {
                httpContext.Response.Redirect("/admin/Account/Login");
            }
            else
            {
                //session'daki kullanıcı idsini alıyoruz
                int gelenKullanici = (int)wrapper.Session["KullaniciId"];
                //idsini aldığım kullanıcıyı db'den çekiyoruz
                var user = _kullaniciRepository.Get(x => x.Id == gelenKullanici);
                //kullanıcı admin ise 
                if (user.Rol.Ad == "Admin")
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