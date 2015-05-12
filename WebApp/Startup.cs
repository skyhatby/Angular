using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Kon.Voi.Model.DecisionModels;
using Kon.Voi.Model.DecisionModels.ViewModels;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApp.Startup))]

namespace WebApp
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Configures AutoMapper instance.
        /// </summary>
        public static void Configure()
        {
            Mapper.CreateMap<Criterion, CriterionViewModel>();
            Mapper.CreateMap<Decision, DecisionViewModel>();
            Mapper.CreateMap<DecisionSubject, DecisionSubjectViewModel>();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Configurations the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configuration(IAppBuilder app)
        {
            AutoMapperConfiguration.Configure();
            this.ConfigureAuth(app);
        }
    }
}
