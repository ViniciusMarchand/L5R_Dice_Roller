using api.Repositories;
using api.Repositories.Interfaces;
using api.Services;
using api.Services.Application;
using api.Services.Application.Interfaces;
using api.Services.Domain;
using api.Services.Domain.Interfaces;

namespace api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISessionRepository, SessionRepository>();
        services.AddScoped<ISessionService, SessionService>();

        return services;
    }
}

