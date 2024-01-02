using TodoApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// 종속성 주입 설정
builder.SetupDependencyInjection();

// Log 설정
builder.SetupLogger();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // swagger 설정
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Globl 에러 처리
app.UseExceptionHandleMiddleware();

// controller 매핑
TodoEndpoints.MappingTodoApiController(app);

app.Run();
