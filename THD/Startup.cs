using FluentValidation;
using FluentValidation.AspNetCore;
using THD.DataAccess.DbContexts;
using THD.DataAccess.Json;
using THD.Service.Dtos;
using THD.Service.Mappings;
using THD.Web.Core.Extensions;
using THD.Web.Core.Options;
using THD.Web.Mappings;
using THD.Web.Mvc.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using Volo.Abp;

namespace THD.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSqlServer(Configuration);
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ServiceAutoMapperProfile>();
                cfg.AddProfile<WebAutoMapperProfile>();
            });
            services.AddAppServices();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/Forbidden";
            });

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AjaxResponseWrapFilter>();
                options.Filters.Add<WebExceptionFilter>();
                options.Filters.Add<ModelValidationFilter>();
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Insert(0, new TrimStringJsonConverter());
            });

            services.AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<UserDto>();
                fv.ValidatorOptions.CascadeMode = CascadeMode.Stop;
                fv.ValidatorOptions.LanguageManager.Culture = new CultureInfo("zh-CN");
            });

            var emailOptions = Configuration.GetSection(EmailOptions.Name).Get<EmailOptions>();
            services.AddFluentEmail(emailOptions.FromEmail)
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient
                {
                    Host = emailOptions.SmtpClient.Host,
                    Port = emailOptions.SmtpClient.Port,
                    EnableSsl = emailOptions.SmtpClient.EnableSsl,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(emailOptions.FromEmail, emailOptions.FromEmailPassword)
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext appDbContext, OADbContext oADbContext)
        {
            if (env.IsDevelopment())
            {
                appDbContext.Database.Migrate();
                oADbContext.Database.Migrate();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>();
                    if (exception.Error is UserFriendlyException ex)
                    {
                        if (context.Request.AcceptJson())
                        {
                            context.Response.StatusCode = StatusCodes.Status200OK;
                            await context.Response.WriteAsync(ex.Message);
                        }
                        else
                        {
                            await context.Response.WriteAsync(@$"<script type=""text/javascript"">alert(""{ex.Message}"")</script>");
                        }
                    }
                });
            });

            

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                HttpOnly = HttpOnlyPolicy.Always,
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
