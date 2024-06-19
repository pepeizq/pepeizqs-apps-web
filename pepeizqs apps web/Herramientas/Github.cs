#nullable disable

using Newtonsoft.Json;

namespace Herramientas
{
	public static class Github
	{
		public static async Task<GithubAPI> CargarAPI(string proyecto)
		{
			string html = await Decompiladores.Estandar("https://api.github.com/repos/pepeizq/" + proyecto);

			if (string.IsNullOrEmpty(html) == false)
			{
				GithubAPI api = JsonConvert.DeserializeObject<GithubAPI>(html);

				if (api != null) 
				{
					return api;
				}
			}

			return null;
		}
	}

	public class GithubAPI
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("pushed_at")]
		public string UltimaModificacion { get; set; }

		[JsonProperty("stargazers_count")]
		public string Estrellas { get; set; }

		[JsonProperty("forks_count")]
		public string Forks { get; set; }

        [JsonProperty("subscribers_count")]
        public string Suscriptores { get; set; }
    }
}
