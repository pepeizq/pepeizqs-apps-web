using Herramientas;
using Microsoft.AspNetCore.ResponseCompression;
using System.Globalization;
using System.IO.Compression;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

#region Compresion (Primero)

builder.Services.AddResponseCompression(options =>
{
	options.Providers.Add<GzipCompressionProvider>();
	options.EnableForHttps = true;
});

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
	options.Level = CompressionLevel.Optimal;
});

#endregion

builder.Services.AddWebOptimizer(opciones => {
	opciones.AddCssBundle("/css/bundle.css", new NUglify.Css.CssSettings
	{
		CommentMode = NUglify.Css.CssComment.None,

	}, "lib/bootstrap/dist/css/bootstrap.min.css", "css/colores_texto.css", "css/principal.css", "css/site.css", "lib/font-awesome/css/all.css");

	opciones.AddJavaScriptBundle("/superjs.js", "lib/jquery/dist/jquery.min.js", "lib/bootstrap/dist/js/bootstrap.bundle.min.js", "js/site.js");
});

try
{
	builder.Services.AddRazorPages();
}
catch { }


builder.Services.AddServerSideBlazor()
	.AddCircuitOptions(options => { options.DetailedErrors = true; });

#region Redireccionador

try
{
	builder.Services.AddControllersWithViews();
}
catch { }

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

#region Antibots

builder.Services.AddRateLimiter(opciones =>
{
	opciones.OnRejected = (contexto, _) =>
	{
		if (contexto.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
		{
			contexto.HttpContext.Response.Headers.RetryAfter =
				((int)retryAfter.TotalSeconds).ToString(NumberFormatInfo.InvariantInfo);
		}

		contexto.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
		contexto.HttpContext.Response.WriteAsync("Too many requests. Please try again later. If you are a bot, go fuck yourself somewhere else.");

		return new ValueTask();
	};

	opciones.GlobalLimiter = PartitionedRateLimiter.CreateChained(
		PartitionedRateLimiter.Create<HttpContext, string>(contexto =>
		{
			string? usuario = contexto.User.Identity?.Name;

			if (string.IsNullOrEmpty(usuario) == true)
			{
				return RateLimitPartition.GetFixedWindowLimiter(
					partitionKey: contexto.Request.Headers.Host.ToString(),
					factory: partition => new FixedWindowRateLimiterOptions
					{
						AutoReplenishment = true,
						PermitLimit = 500,
						QueueLimit = 0,
						Window = TimeSpan.FromMinutes(1)
					});
			}
			else
			{
				return RateLimitPartition.GetNoLimiter("");
			}
		})
	);
});

#endregion

#region Blazor

//builder.Services.AddRazorComponents().AddInteractiveServerComponents(opciones =>
//{
//	opciones.DetailedErrors = true;
//});

#endregion

#region Mejora velocidad carga

builder.Services.AddHsts(opciones =>
{
	opciones.Preload = true;
	opciones.IncludeSubDomains = true;
	opciones.MaxAge = TimeSpan.FromDays(730);
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
    //app.UseExceptionHandler("/Error");
    app.UseDeveloperExceptionPage();
    app.UseHsts();
//}

#region Compresion (Primero)

app.UseResponseCompression();

#endregion

#region Optimizador (Despues Compresion)

app.UseWebOptimizer();

#endregion

app.UseHttpsRedirection();
app.MapStaticAssets();

app.UseAuthorization();

#region Blazor

app.MapBlazorHub();

#endregion

#region Redireccionador

try
{
	app.MapControllers();
}
catch { }



#endregion

#region Antibots

app.UseRateLimiter();

#endregion

//app.MapRazorPages();

app.Run();
