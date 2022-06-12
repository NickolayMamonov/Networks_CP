using CourseProject_1.Data;
using CourseProject_1.GraphQL.Schema;
using CourseProject_1.GraphQL.Services;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<HospitalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalContext")));

//Add GraphQL
builder.Services.AddScoped<ISchema, PatientSchema>();
builder.Services.AddGraphQL(options => { options.EnableMetrics = true; }).AddSystemTextJson();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseGraphQL<ISchema>();
app.MapControllers();

app.Run();