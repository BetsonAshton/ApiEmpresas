namespace ApiEmpresas.Presentation.Configurations
{
    public class AutoMapperConfiguration
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
