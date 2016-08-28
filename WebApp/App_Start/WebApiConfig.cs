using BundleTransformer.Core.Transformers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApp.Infrastructure;

namespace WebApp
{
    public static class WebApiConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            RegisterRoutes(config);
            ConfigureSerializer(config);
            // RegisterFilters(config);
            RemoveUnnecessaryFormatters(config);

            RegisterGlobalFilters(GlobalFilters.Filters);
            RemoveUnnecessaryViewEngines(ViewEngines.Engines);
            RegisterBundles(BundleTable.Bundles);
        }

        private static void RegisterRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }

        private static void ConfigureSerializer(HttpConfiguration config)
        {
            var serializerSettings = config.Formatters.JsonFormatter.SerializerSettings;

            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        }

        
        private static void RemoveUnnecessaryFormatters(
            HttpConfiguration config)
        {
            var formatters = config.Formatters;
            var unnecessaryFormatters = formatters.Where(f => f != formatters.JsonFormatter)
                .ToList();

            foreach (var formatter in unnecessaryFormatters)
            {
                formatters.Remove(formatter);
            }
        }

        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new MvcAuthenticationAttribute());

            filters.Add(new HandleErrorAttribute());
        }

        private static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(CreateWebAppBundle("~/scripts/app", "~/scripts/application"));
        }

        private static Bundle CreateWebAppBundle(
            string bundlePath,
            string directoryPath)
        {
            var bundle = new ScriptBundle(bundlePath)
                                .IncludeDirectory(directoryPath, "*.js", true);

            bundle.Transforms.Clear();
            //bundle.Transforms.Add(new ScriptTransformer(new BundleTransformer.JsMin.Minifiers.CrockfordJsMinifier()));

           

            bundle.Orderer = new WebAppScriptBundleOrderer();

            return bundle;
        }

        private static void RemoveUnnecessaryViewEngines(
            ICollection<IViewEngine> viewEngines)
        {
            var unnecessaryEngines = viewEngines.Where(ve => ve is WebFormViewEngine)
                .ToList();

            foreach (var viewEngine in unnecessaryEngines)
            {
                viewEngines.Remove(viewEngine);
            }
        }

    }
}
