var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/reverse", async (string input) =>
{
    var reverse = new StringBuilder(input.Length);
    for (int i = input.Length - 1; i >= 0; i--)
    {
        reverse.Append(input[i]);
    }
    await Task.Delay(500);
    return reverse.ToString();
});
app.Run();