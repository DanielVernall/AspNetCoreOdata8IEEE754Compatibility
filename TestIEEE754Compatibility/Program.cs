using TestIEEE754Compatibility.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.OData.Json;

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntityType<Order>();
modelBuilder.EntitySet<Customer>("Customers");

var edmModel = modelBuilder.GetEdmModel();

builder.Services.AddControllers().AddOData(
    options => {
        options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
            "odata",
            edmModel,
            services =>
            {
                services.AddSingleton<IStreamBasedJsonWriterFactory>(o => new CustomStreamBasedJsonWriterFactory());
            });
    });

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseODataRouteDebug();
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();