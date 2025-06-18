var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Middleware #1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware #1: Before calling next\r\n");

    await next(context);

    await context.Response.WriteAsync("Middleware #1: After calling next\r\n");
});

//Middleware #2
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Middleware #2: Processed\r\n");
});

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Middleware #2: Before calling next\r\n");

//    await next(context); //Commenting this line will give an arror if you don't use the types of the parameters. You have to call the "next" delegate

//    await context.Response.WriteAsync("Middleware #2: After calling next\r\n");
//});

//Middleware #3
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware #3: Before calling next\r\n");

    await next(context);

    await context.Response.WriteAsync("Middleware #3: After calling next\r\n");
});

app.Run();
