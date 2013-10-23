using System;
using AcklenAvenue.Data;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using LigaNacional.Domain;

namespace LigaNacional.Data
{
    public class MappingScheme : IDatabaseMappingScheme<MappingConfiguration>
    {
        public Action<MappingConfiguration> Mappings
        {
            get
            {
                var autoPersistenceModel = AutoMap.Assemblies(typeof(IEntity).Assembly)

                    .Where(t => typeof(IEntity).IsAssignableFrom(t))
                    .Conventions.Add(DefaultCascade.All());

                Action<MappingConfiguration> result = x => x.AutoMappings.Add(autoPersistenceModel);
                
                return result ;
            }
        }
    }
}
