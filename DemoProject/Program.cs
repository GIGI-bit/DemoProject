
using DemoProject.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskFlow.Business.Abstract;
using TaskFlow.Business.Concrete;
using TaskFlow.Core.DataAccess;
using TaskFlow.Core.DataAccess.EntityFramework;
using TaskFlow.DataAccess.Abstract;
using TaskFlow.DataAccess.Concrete;
using TaskFlow.Entities.Data;
using TaskFlow.Entities.Models;

var builder = WebApplication.CreateBuilder(args);

 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("http://localhost:3001/").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
}));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSignalR();
 
builder.Services.AddScoped<IUserDal,UserDal>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ICommentDal,CommentDal>();
builder.Services.AddScoped<ICommentService,CommentService>();
builder.Services.AddScoped<IQuizDal,QuizDal>();
builder.Services.AddScoped<IQuizService,QuizService>();
builder.Services.AddScoped<IProjectDal,ProjectDal>();
builder.Services.AddScoped<IProjectService,ProjectService>();
builder.Services.AddScoped<ITaskDal,TaskDal>();
builder.Services.AddScoped<ITaskService,TaskService>();
builder.Services.AddScoped<ITaskCustomizeDal, TaskCustomizeDal>();
builder.Services.AddScoped<ITaskCustomizeService, TaskCustomizeService>(); 
builder.Services.AddScoped<ITeamMemberDal,TeamMemberDal>();
builder.Services.AddScoped<ITeamMemberService,TeamMemberService>(); 
builder.Services.AddScoped<IMessageDal,MessageDal>(); 
builder.Services.AddScoped<IMessageService,MessageService>(); 
builder.Services.AddScoped<IFriendDal,FriendDal>(); 
builder.Services.AddScoped<IFriendService,FriendService>(); 
builder.Services.AddScoped<ITaskAssignDal,TaskAssignDal>(); 
builder.Services.AddScoped<ITaskAssignService,TaskAssigneService>(); 
builder.Services.AddScoped<INotificationDal,NotificationDal>(); 
builder.Services.AddScoped<INotificationService,NotificationService>(); 


var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value);



//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(key),
//            ValidateIssuer = false,
//            ValidateAudience = false,
          
//        };
//    });



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
  .AddJwtBearer(options =>
  {
      options.RequireHttpsMetadata = false;
      options.SaveToken = true;
      options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false
      };
  });

var conn = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<TaskFlowContext>(opt =>
{
    opt.UseSqlServer(conn);
    opt.UseLazyLoadingProxies();
}); 

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x =>
{
    x.AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.MapHub<ConnectionHub>("/connect");
app.Run();
