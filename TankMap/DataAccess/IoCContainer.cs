using System.Configuration;
using System.Reflection;
using Autofac;
using Autofac.Integration.Web.Mvc;

namespace TankMap.DataAccess
{
    public sealed class IoCContainer
    {
        private static IContainer _baseContainer { get; set; }

        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            var connectionString = ConfigurationManager.ConnectionStrings["MongoConnection"].ConnectionString;
            builder.RegisterGeneric(typeof(MongoRepository<>))
                   .WithParameter(new NamedParameter("connectionString", connectionString))
                   .As(typeof(IRepository<>));

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());

            _baseContainer = builder.Build();
            return _baseContainer;
        }

        public TService Resolve<TService>()
        {
            if (_baseContainer == null) CreateContainer();
            return _baseContainer.Resolve<TService>();
        }

        private IoCContainer()
        {
        }

        private static readonly IoCContainer _instance = new IoCContainer();
        public static IoCContainer Instance
        {
            get { return _instance; }
        }
    }
}