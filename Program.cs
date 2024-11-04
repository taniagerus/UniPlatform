using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using UniPlatform.DB;
using UniPlatform.DB.Entities;
using UniPlatform.DB.Repositories;
using UniPlatform.Interfaces;
using UniPlatform.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PlatformDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DBCS"))
);
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<TestService, TestService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ITestAssignmentRepository, TestAssignmentRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

//builder.Services.AddScoped<IGenericRepository<T>, GenericRepository<T>();

// ������ �������� ������������ string �� enum � JSON
builder
    .Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// ������������ Identity
builder
    .Services.AddIdentity<User, IdentityRole<int>>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = true;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
    })
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<PlatformDbContext>();

// ������������ JWT
var validIssuer = builder.Configuration.GetValue<string>("JwtTokenSettings:ValidIssuer");
var validAudience = builder.Configuration.GetValue<string>("JwtTokenSettings:ValidAudience");
var symmetricSecurityKey = builder.Configuration.GetValue<string>(
    "JwtTokenSettings:SymmetricSecurityKey"
);

builder
    .Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.IncludeErrorDetails = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ClockSkew = TimeSpan.Zero,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = validIssuer,
            ValidAudience = validAudience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(symmetricSecurityKey)
            ),
        };
    });

// ������ ������ ��� ����������
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));

// ������������ Swagger
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Test API", Version = "v1" });
    option.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer",
        }
    );
    option.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer",
                    },
                },
                new string[] { }
            },
        }
    );
});

// ������ �����������
builder.Services.AddAuthorization();

// ������ ���� ������
builder.Services.AddProblemDetails();

//builder.Services.AddApiVersioning();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
