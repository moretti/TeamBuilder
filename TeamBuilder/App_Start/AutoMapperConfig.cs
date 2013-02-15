using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamBuilder.Models;
using TeamBuilder.ViewModels;

namespace TeamBuilder
{
    public static class AutoMapperConfig
    {
        public static void CreateMapping()
        {
            CreateEmployeeMapping();
            CreateTeamMapping();

            Mapper.AssertConfigurationIsValid();
        }

        private static void CreateEmployeeMapping()
        {
            Mapper.CreateMap<Employee, IndexEmployeeViewModel>();

            Mapper.CreateMap<Employee, EditEmployeeViewModel>()
                .ForMember(dest => dest.SelectedTeamId, opt => opt.MapFrom(m => m.Team.Id))
                .ForMember(dest => dest.Teams, opt => opt.Ignore());

            Mapper.CreateMap<EditEmployeeViewModel, Employee>()
               .ForMember(dest => dest.Team, opt => opt.Ignore());
        }

        private static void CreateTeamMapping()
        {
            Mapper.CreateMap<Team, IndexTeamViewModel>();

            Mapper.CreateMap<Team, EditTeamViewModel>();

            Mapper.CreateMap<EditTeamViewModel, Team>()
               .ForMember(dest => dest.Employees, opt => opt.Ignore())
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        }
    }
}