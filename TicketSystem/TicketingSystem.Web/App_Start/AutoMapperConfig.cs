namespace TicketingSystem.Web.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using AutoMapper;
    using TicketingSystem.Web.Infrastructure.Mapping;


    public static class AutoMapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(c => Execute(c));
        }

        public static void Execute(IMapperConfigurationExpression config)
        {
            config.ConstructServicesUsing(t => DependencyResolver.Current.GetService(t));

            Type[] types = Assembly.GetExecutingAssembly().GetExportedTypes();

            LoadStandartMappings(config, types);

            LoadCustomMapping(config, types);
        }



       private static void LoadStandartMappings( IMapperConfigurationExpression config,IEnumerable<Type> types)
       {
            var maps = types
                 .SelectMany(t => t.GetInterfaces(), (t, i) => new { t, i })
                 .Where(type => type.i.IsGenericType && type.i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                                !type.t.IsAbstract && !type.t.IsInterface)
                 .Select(type => new
                 {
                     Source = type.i.GetGenericArguments()[0],
                     Destination = type.t
                 });
       
               foreach (var map in maps)
           {
               config.CreateMap(map.Source, map.Destination);
               config.CreateMap(map.Destination, map.Source);
           }
       }

        private static void LoadCustomMapping( IMapperConfigurationExpression config, IEnumerable<Type> types)
        {
            var maps = types
                 .SelectMany(t => t.GetInterfaces(), (t, i) => new { t, i })
                 .Where(type => typeof(IHaveCustomMappings).IsAssignableFrom(type.t) &&
                        !type.t.IsAbstract &&
                        !type.t.IsInterface)
                        .Select ( type => (IHaveCustomMappings)Activator.CreateInstance(type.t));

            foreach (var map in maps)
            {
                map.CreateMappings(config);
            }

        }
    }
}