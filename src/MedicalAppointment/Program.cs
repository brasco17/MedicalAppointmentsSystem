// using MedicalAppointment.Data.DbContexts;
// using MedicalAppointment.Data.IRepositories;
// using MedicalAppointment.Data.Repositories;
// using MedicalAppointment.Service.AppointmentService;
// using MedicalAppointment.Service.Interfaces;
// using MedicalAppointment.Service.Interfaces.IAppointmentService;
// using MedicalAppointment.Service.Interfaces.IDoctorService;
// using MedicalAppointment.Service.Interfaces.IPatientService;
// using MedicalAppointment.Service.Interfaces.IPrescriptionService;
// using MedicalAppointment.Service.Interfaces.IUserService;
// using MedicalAppointment.Service.Services;
// using MedicalAppointment.Service.Services.DoctorService;
// using MedicalAppointment.Service.Services.PatientService;
// using MedicalAppointment.Service.Services.UserService;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.OpenApi.Models;
//
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         var builder = WebApplication.CreateBuilder(args);
//
//         builder.Services.AddControllers();
//         builder.Services.AddEndpointsApiExplorer();
//         ConfigureSwaggerServices(builder);
//
//         var app = builder.Build();
//         app.MapControllers();
//
//         if (app.Environment.IsDevelopment())
//         {
//             ConfigureSwaggerMiddlewares(app);
//         }
//
//         
//
//         void ConfigureSwaggerServices(WebApplicationBuilder builder)
//         {
//             builder.Services.AddSwaggerGen();
//         }
//
//         void ConfigureSwaggerMiddlewares(WebApplication app)
//         {
//             app.UseSwagger();
//             app.UseSwaggerUI();
//         }
//         builder.Services.AddDbContext<AppDbContext>(options =>
//             options.UseNpgsql(builder.Configuration.GetConnectionString("Npgsql")));
//         app.Run();
//     }
// }


using MedicalAppointment.Data.DbContexts;
using MedicalAppointment.Data.IRepositories;
using MedicalAppointment.Data.Repositories;
using MedicalAppointment.Domain.Entities;
using MedicalAppointment.Service.AppointmentService;
using MedicalAppointment.Service.Interfaces.IAppointmentService;
using MedicalAppointment.Service.Interfaces.IDoctorService;
using MedicalAppointment.Service.Interfaces.IPatientService;
using MedicalAppointment.Service.Interfaces.IPrescriptionService;
using MedicalAppointment.Service.Interfaces.IUserService;
using MedicalAppointment.Service.Mappers;
using MedicalAppointment.Service.Services;
using MedicalAppointment.Service.Services.DoctorService;
using MedicalAppointment.Service.Services.PatientService;
using MedicalAppointment.Service.Services.UserService;
using Microsoft.EntityFrameworkCore;

// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddScoped<IUserService, UserService>();
// // 🔹 1. Controller larni qo‘shish
// builder.Services.AddControllers();
//
// // 🔹 2. Swagger UI ni yoqish
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
//
// var app = builder.Build();
//
//
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
//
// app.UseHttpsRedirection();
// app.UseAuthorization();
//
// // 🔹 5. Routing va Controller larni sozlash
// app.MapControllers();
//
// // 🔹 6. API serverni ishga tushirish
// app.Run();


public class Program
{
    public static void Main(string[] args)
    {
        
        
        var builder = WebApplication.CreateBuilder(args);

        
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("Npgsql")));
        
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IDoctorService, DoctorService>();
        builder.Services.AddScoped<IPatientService, PatientService>();
        builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
        builder.Services.AddScoped<IAppointmentService, AppointmentService>();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}