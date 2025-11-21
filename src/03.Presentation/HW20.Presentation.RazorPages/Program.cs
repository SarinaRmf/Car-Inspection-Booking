using HW20.Domain.Core.Contracts.ApplicationServices;
using HW20.Domain.Core.Contracts.Repository;
using HW20.Domain.Core.Contracts.Services;
using HW20.Domain.Service.ApplicationServices;
using HW20.Domain.Service.Services;
using HW20.Infra.Data.Repos.Ef;
using HW20.Infra.Db.SqlServer.Ef;
using HW20.Presentation.RazorPages.Extentions;
using Microsoft.EntityFrameworkCore;

namespace HW20.Presentation.RazorPages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddHttpContextAccessor();

            #region ServiceRegisteration
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=HW20;User ID=sa;Password=Az@r4180;Trust Server Certificate=True "));
            builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
            builder.Services.AddScoped<ICarRepository , CarRepository>();
            builder.Services.AddScoped<ICarOwnerRepository, CarOwnerRepository>();
            builder.Services.AddScoped<IUserRepository,UserRepository>();
            builder.Services.AddScoped<IRequestRepository,RequestRepository>();

            builder.Services.AddScoped<ICarModelAppService,CarModelAppService>();
            builder.Services.AddScoped<IRequestAppService, RequestAppservice>();
            builder.Services.AddScoped<IUserAppService, UserAppService>();

            builder.Services.AddScoped<ICarModelService,CarModelService>();
            builder.Services.AddScoped<ICarService,CarService>();
            builder.Services.AddScoped<IRequestService,RequestService>();
            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddScoped<ICarOwnerService,CarOwnerService>();

            builder.Services.AddScoped<ICookieService, CookieService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<ICarImageService,CarImageService>();
            builder.Services.AddScoped<ICarImageRepository,CarImageRepository>();
            builder.Services.AddScoped<ICarImageAppService,CarImageAppService>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.MapGet("/", (context) =>
            {
                context.Response.Redirect("/Home/Index");
                return Task.CompletedTask;
            });

            app.Run();

        }
    }
}
