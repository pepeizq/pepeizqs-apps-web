using Herramientas;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
//   .AddNegotiate();

//builder.Services.AddAuthorization(options =>
//{
//	// By default, all incoming requests will be authorized according to the default policy.
//	options.FallbackPolicy = options.DefaultPolicy;
//});

builder.Services.AddRazorPages();

#region Redireccionador

builder.Services.AddControllersWithViews();

#endregion

#region Seo

builder.Services.AddHeadElementHelper();

#endregion

#region Tareas

builder.Services.Configure<HostOptions>(hostOptions =>
{
    hostOptions.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.Ignore;
});

builder.Services.AddSingleton<Tareas.TareaGithub>();

builder.Services.AddHostedService(provider => provider.GetRequiredService<Tareas.TareaGithub>());

#endregion

#region Decompilador

builder.Services.AddHttpClient<IDecompiladores, Decompiladores2>()
    .ConfigurePrimaryHttpMessageHandler(() =>
        new HttpClientHandler
        {
            AutomaticDecompression = System.Net.DecompressionMethods.GZip,
            MaxConnectionsPerServer = 2
        });

builder.Services.AddSingleton<IDecompiladores, Decompiladores2>();

#endregion

#region Blazor

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
    //app.UseExceptionHandler("/Error");
    app.UseDeveloperExceptionPage();
    app.UseHsts();
//}

#region Seo

app.UseHeadElementServerPrerendering();

#endregion

app.UseHttpsRedirection();
app.UseStaticFiles();

#region Redireccionador

app.MapControllers();

#endregion

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

#region Blazor

app.MapBlazorHub();

#endregion

app.Run();
