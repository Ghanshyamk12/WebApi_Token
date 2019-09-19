using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi_tokan.Providers;

//[assembly:OwinStartup(typeof(WebApi_tokan.Startup))]
namespace WebApi_tokan
{
    public class Startup
    {
        //public Startup(IApplicationEnvironment env,
        //           IHostingEnvironment hostenv, ILoggerFactory logger)
        //{
        //}

        public void ConfigureService(IServiceCollection service)
        {

        }

        public void ConfigureAuth(IAppBuilder app)
        {
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/tokan"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                Provider = new ApplicationOAuthProvider(),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true

            };

            app.UseOAuthBearerTokens(OAuthOptions);
            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}