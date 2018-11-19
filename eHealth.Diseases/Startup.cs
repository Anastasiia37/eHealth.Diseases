using AutoMapper;
using eHealth.Diseases.BusinessLogic.Contracts;
using eHealth.Diseases.BusinessLogic.Contracts.Service;
using eHealth.Diseases.BusinessLogic.DbContext;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;
using eHealth.Diseases.BusinessLogic.Managers.Service;
using eHealth.Diseases.BusinessLogic.Models;
using eHealth.Diseases.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace eHealth.Diseases
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string con = "Server=(localdb)\\mssqllocaldb;Database=eHealth9;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<IDataAccessManager, DataAccessManager>(options => options.UseSqlServer(con));
            services.AddScoped<IDiseaseManager, DiseaseManager>();
            services.AddScoped<IPatientDiseaseManager, PatientDiseaseManager>();
            services.AddScoped<IDiseaseCategoryManager, DiseaseCategoryManager>();
            Mapper.Initialize(config =>
            {
                config.CreateMap<AddPatientDiseaseRequest, PatientDisease>();
                config.CreateMap<UpdatePatientDiseaseRequest, PatientDisease>();
                config.CreateMap<PatientDisease, PatientDiseaseView>();
                config.CreateMap<PatientDisease, PatientDiseaseNamesView>().
                    ForMember(dest => dest.DiseaseName, src => src.MapFrom(s => s.Disease.Name));
                config.CreateMap<DiseaseRequest, Disease>();
                config.CreateMap<Disease, DiseaseView>();
                config.CreateMap<DiseaseCategoryRequest, DiseaseCategory>();
                config.CreateMap<DiseaseCategory, DiseaseCategoryView>();
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("eHealth.Diseases", new Info
                {
                    Version = "v1",
                    Title = "eHealth.Diseases",
                    Description = "EHealth project. Subsystem Diseases",
                    TermsOfService = "None",
                    Contact = new Contact()
                    {
                        Name = "Anastasiia Peretiatko",
                        Email = "_nastya_@ua.fm",
                        Url = "www.github.com/Anastasiia37"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/eHealth.Diseases/swagger.json", "eHealth.Diseases");
            });
        }
    }
}