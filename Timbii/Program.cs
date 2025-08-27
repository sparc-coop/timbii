using Sparc.Blossom.Engine;
using Timbii.Shared;

var builder = BlossomApplication.CreateBuilder<BlossomApp<Program, MainLayout>>(args);
builder.Services.AddBlossomEngine("https://localhost:7185");
builder.Services.AddDexie<Room>();
var app = builder.Build();

await app.RunAsync<BlossomApp<Program, MainLayout>>();
