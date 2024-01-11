using CardapioOnline.Infra.Data;
using CardapioOnline.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraStructure(builder.Configuration);
builder.Services.AddInfrastructureCors();
builder.Services.AddInfraStructureSwagger();

// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
// app.UseCors("_myAllowSpecificOrigins");

app.UseRouting();
app.MapControllers();
app.UseCors();

app.Run();