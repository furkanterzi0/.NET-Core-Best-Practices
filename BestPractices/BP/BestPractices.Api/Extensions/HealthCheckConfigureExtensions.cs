namespace BestPractices.Api.Extensions
{
    public static class HealthCheckConfigureExtensions
    {
        public static IApplicationBuilder UseCustomHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/api/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
            {
                ResponseWriter = async (context, reprot) =>
                {
                    await context.Response.WriteAsync("OK");
                }
            });
            return app;
        }
    }
}
