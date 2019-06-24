using Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Rfid;

namespace Api
{
    public static class ServicesExtensions
    {
        public static async void RegisterReaderService(this IServiceCollection services)
        {
            services.AddSingleton<ReaderService>(await ReaderService.Create(new RfidReader()));
        }
    }
}