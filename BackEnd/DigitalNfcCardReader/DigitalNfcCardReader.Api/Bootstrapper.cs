using DigitalNfcCardReader.Domain.Commands.v1.NfcCard.Create;
using DigitalNfcCardReader.Domain.Contracts.v1;
using DigitalNfcCardReader.Infra.Data.MongoDb.Configuration.v1;
using DigitalNfcCardReader.Infra.Data.MongoDb.Repositories.v1;
using DigitalNfcCardReader.Infra.Data.Queries.v1.NfcCard.GetNfcInfoBySerialCode;
using DigitalNfcCardReader.Infra.Data.Queries.v1.NfcCard.GetNfcInfoByTagId;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace DigitalNfcCardReader.Api
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddApiInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<INfcCardRepository, NfcCardMongoRepository>();

            services.AddAutoMapper(typeof(GetNfcInfoBySerialCodeQueryProfile).Assembly);

            return services;
        }

        public static IServiceCollection AddMongoInfrastructure(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            MongoSettings mongoDBSettings = new MongoSettings
            {
                ConnectionString = configuration.GetSection("MongoSettings:ConnectionString").Value
                    ?? throw new InvalidOperationException("Configuração MongoSettings não foi informada"),
                Database = configuration.GetSection("MongoSettings:DatabaseName").Value
                    ?? throw new InvalidOperationException("Configuração MongoSettings não foi informada")
            };

            services.Configure<MongoSettings>(configuration.GetSection("MongoSettings"));

            services.AddScoped(services => mongoDBSettings);

            services.AddScoped(provider => new MongoClient(mongoDBSettings.ConnectionString)
            .GetDatabase(mongoDBSettings.Database))
                .AddSingleton<IMongoClient>(sp => sp.GetRequiredService<MongoClient>());

            return services;
        }

        public static IServiceCollection AddCorsConfiguration(
            this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            return services;
        }

        public static IServiceCollection AddMediator(
            this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblies(
                        typeof(GetNfcInfoByTagIdQuery).Assembly));
            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblies(
                        typeof(CreateNfcCardCommand).Assembly));

            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

            return services;
        }

        public static IServiceCollection AddFirebaseInfrastructure(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            string firebaseConfigPath = configuration.GetSection("FirebaseConfig:configPath").Value!;
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(firebaseConfigPath)
            });

            return services;
        }
    }
}
