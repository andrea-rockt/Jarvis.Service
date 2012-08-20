using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.Mappers;
using Ninject;
using Ninject.Modules;
using DTO = Jarvis.WCF.Contracts.Data;
using Domain = Jarvis.Service.Domain;

namespace Jarvis.Service.IoC
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITypeMapFactory>().To<TypeMapFactory>();
            foreach (var mapper in MapperRegistry.AllMappers())
                Bind<IObjectMapper>().ToConstant(mapper);
            Bind<ConfigurationStore>().ToSelf().InSingletonScope()
                .WithConstructorArgument("mappers",
                    ctx => ctx.Kernel.GetAll<IObjectMapper>());
            Bind<IConfiguration>().ToMethod(ctx => ctx.Kernel.Get<ConfigurationStore>());
            Bind<IConfigurationProvider>().ToMethod(ctx =>
                ctx.Kernel.Get<ConfigurationStore>());
            Bind<IMappingEngine>().To<MappingEngine>();

            MapDomainToDto(Kernel.Get<IConfiguration>());
        }

        private void MapDomainToDto(IConfiguration configuration)
        {
            configuration.CreateMap<Domain.Location.Location, DTO.Location>();
            configuration.CreateMap<Domain.Location.LocationCategory, DTO.LocationCategory>();
            configuration.CreateMap<Domain.Action.Action, DTO.Action>()
                .Include<Domain.Action.ExecuteProgramAction, DTO.ExecuteProgramAction>()
                .Include<Domain.Action.ShowMessageAction, DTO.ShowMessageAction>()
                .Include<Domain.Action.TerminateProgramAction, DTO.TerminateProgramAction>();
            configuration.CreateMap<Domain.Action.ExecuteProgramAction, DTO.ExecuteProgramAction>();
            configuration.CreateMap<Domain.Action.ShowMessageAction, DTO.ShowMessageAction>();
            configuration.CreateMap<Domain.Action.TerminateProgramAction, DTO.TerminateProgramAction>();


            configuration.CreateMap<DTO.Location, Domain.Location.Location>();
            configuration.CreateMap<DTO.LocationCategory, Domain.Location.LocationCategory>();
            configuration.CreateMap<DTO.Action, Domain.Action.Action>()
                .Include<DTO.ExecuteProgramAction, Domain.Action.ExecuteProgramAction>()
                .Include<DTO.ShowMessageAction, Domain.Action.ShowMessageAction>()
                .Include<DTO.TerminateProgramAction, Domain.Action.TerminateProgramAction>();
            configuration.CreateMap<DTO.ExecuteProgramAction, Domain.Action.ExecuteProgramAction>();
            configuration.CreateMap<DTO.ShowMessageAction, Domain.Action.ShowMessageAction>();
            configuration.CreateMap<DTO.TerminateProgramAction, Domain.Action.TerminateProgramAction>();

        }
    }
}
