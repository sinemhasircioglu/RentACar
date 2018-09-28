using Autofac;
using Autofac.Integration.Mvc;
using RentACar.Core.Infrastructure;
using RentACar.Core.Repository;
using System.Web.Mvc;

namespace RentACar.Class
{
    public class Bootstrapper
    {
        //Boot aşamasında çalışacak

        public static void RunConfig()
        {
            BuildAutoFac();
        }

        private static void BuildAutoFac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<AracRepository>().As<IAracRepository>();
            builder.RegisterType<ResimRepository>().As<IResimRepository>();
            builder.RegisterType<KullaniciRepository>().As<IKullaniciRepository>();
            builder.RegisterType<RolRepository>().As<IRolRepository>();
            builder.RegisterType<HizmetRepository>().As<IHizmetRepository>();
            builder.RegisterType<IslemRepository>().As<IIslemRepository>();
            builder.RegisterType<MusteriRepository>().As<IMusteriRepository>();
            builder.RegisterType<OdemeRepository>().As<IOdemeRepository>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}