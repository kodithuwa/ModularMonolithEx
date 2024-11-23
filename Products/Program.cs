using Products;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


// Register MediatR for all modules
builder.Services.AddMediatR(r =>
{
    r.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

// Register module-specific services
ProductsModule.Register(services);

var app = builder.Build();
app.Run();
