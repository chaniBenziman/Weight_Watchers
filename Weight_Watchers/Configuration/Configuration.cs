using AutoMapper;
using Subscriber.CORE.Interface_DAL;
using Subscriber.CORE.Interface_Service;
using Subscriber.DAL;
using Subscriber.Services;

namespace Subscriber.WebApi.Configuration
{
    public static class Configuration
    {
        public static void Configurations(this IServiceCollection services)
        {
            services.AddScoped<IWeight_WatchersRepository, Weight_WatchersRepository>();
            services.AddScoped<IWeight_WatchersService, Weight_WatchersService>();

            var mappingConfig = new MapperConfiguration(p =>
            {
                p.AddProfile(new Weight_WatchersProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
