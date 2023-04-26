using FluentEmail.Smtp;
using Microsoft.Extensions.Configuration;
using SampleCorePractice.Helpers;
using SampleCorePractice.Services;
using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFluentEmail(
    builder.Configuration.GetValue<string>("Mail:FromEmail"),
    builder.Configuration.GetValue<string>("Mail:FromName")
    ).AddRazorRenderer()
.AddSmtpSender( new SmtpClient(builder.Configuration.GetValue<string>("SES:SMTP"))
{
    UseDefaultCredentials = false,
    Port = builder.Configuration.GetValue<int>("SES:Port"),
    Credentials = new NetworkCredential(builder.Configuration.GetValue<string>("SES:Username")
                , builder.Configuration.GetValue<string>("SES:Password")),
    EnableSsl = true
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<TwilioSettings>(builder.Configuration.GetSection("Twilio"));
builder.Services.AddTransient<ITwilioSMS, TwilioSMS>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
