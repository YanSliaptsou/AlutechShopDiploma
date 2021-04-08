using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlutechShopDiploma.Startup))]
namespace AlutechShopDiploma
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
