namespace Products
{
    public static class ProductsModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddMediatR(r => r.RegisterServicesFromAssemblies(typeof(ProductsModule).Assembly));
        }
    }
}
