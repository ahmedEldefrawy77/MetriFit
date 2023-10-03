namespace MetriFit;
    public static class Options
    {
        public static void AddServiceOptions(this IServiceCollection services)
        {
            services.AddOptions();
            services.ConfigureOptions<AccessOptionSetup>();
            services.ConfigureOptions<BearerOptionSetup>();
            services.ConfigureOptions<RefreshOptionSetup>();
        }
    }
