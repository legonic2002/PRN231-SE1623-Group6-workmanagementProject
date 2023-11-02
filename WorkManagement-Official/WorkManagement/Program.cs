using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WorkManagement.Hubs;

Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.ConfigureServices((hostContext, services) =>
        {
            services.AddControllersWithViews();
            //services.AddControllers
            services.AddDbContext<WorkManagementStableContext>(options =>
            {
                options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection") ?? "",
                    sqlServerOptions =>
                    {
                        sqlServerOptions.EnableRetryOnFailure();
                    });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WorkManagement API", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Program).Assembly);
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddSession(options =>
            {
                // Configure session options
                options.Cookie.Name = "MySession";
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddSignalR();
        });

        webBuilder.Configure(app =>
        {
            var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Work Management API V1");
                });
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<AuthorizeMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        });
    })
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        // Register Autofac module
        builder.RegisterModule(new DataAccessModule());
    })
    .Build().Run();
