using System.Web.Http;
using Autofac.Integration.WebApi;
using Autofac;
using Location.Service.Controllers;
using Location;
using Location.Impl;
using Location.Repository;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Amazon;
using Waiting.Service.Controllers;
using Waiting.Repository;
using Waiting.Impl;
using Waiting;

namespace LocationService.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            config.EnsureInitialized();

            ContainerBuilder builder = new ContainerBuilder();

            // Location Components
            builder.RegisterType<LocationsController>().InstancePerRequest();
            builder.RegisterType<LiveCheckController>().InstancePerRequest();
            builder.RegisterType<PlaceFetcher>().As<IPlaceFetcher>();
            builder.RegisterType<LocationRepository>().As<ILocationRepository>();

            builder.RegisterType<WaitTimeController>().InstancePerRequest();
            builder.RegisterType<WaitRepository>().As<IWaitRepository>();
            builder.RegisterType<WaitManager>().As<IWaitManager>();

            // General Components
            builder.Register(x => BuildContext());
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }

        public static AmazonDynamoDBClient BuildClient()
        {
            var config = new AmazonDynamoDBConfig();
            config.RegionEndpoint = RegionEndpoint.USWest2;
            return new AmazonDynamoDBClient(config);
        }

        public static DynamoDBContext BuildContext()
        {
            return new DynamoDBContext(BuildClient());
        }
    }
}
