using AutoMapper;
using DeviceManager.Areas.Admin.Models;
using DeviceManager.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DeviceManager.App_Start.AutoMapperConfig))]

namespace DeviceManager.App_Start
{
    public class AutoMapperConfig
    {
        public void Configuration(IAppBuilder app)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserEditViewModel, User>();
                cfg.CreateMap<User, UserEditViewModel>();

            });
        }
    }
}
