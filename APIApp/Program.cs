using BLL.Services;
using DAL;
using DAL.EF;
using DAL.Interface;
using DAL.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<UserRepo>();
//builder.Services.AddScoped<FeedbackRepo>();
//builder.Services.AddScoped<BookingRepo>();
//builder.Services.AddScoped<PaymentRepo>();
builder.Services.AddScoped<DataAccessFactory>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<FeedbackService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<ReportService>();


builder.Services.AddDbContext<SSMSContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
