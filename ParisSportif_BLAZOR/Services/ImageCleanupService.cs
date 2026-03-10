using System;

using ParisSportif_BLAZOR.Model;
using System.Net.Http;

namespace ParisSportif_BLAZOR.Services;

public class ImageCleanupService
{
    private readonly HttpClient _http;

    public ImageCleanupService(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient("API");
    }


    public async Task CleanUnusedImagesForClubs()
    {
        var folder = Path.Combine(Directory.GetCurrentDirectory(),
                                  "wwwroot", "images", "clubs");

        var files = Directory.GetFiles(folder);


        //Pour plus de performance  => créer une nouvelle fonction dans l'API (un nouveau controller) qui ne renvoie que les logos et pas le reste
        var clubs = await _http.GetFromJsonAsync<List<Club>>("api/Clubs") ?? new List<Club>();

        var logosInDb = clubs
            .Where(c => !string.IsNullOrEmpty(c.Logo))
            .Select(c => c.Logo)
            .ToList();

        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file);
            var fileInfo = new FileInfo(file);

            // On vérifie si l'image (le file) apparait dans les logos des clubs
            bool used = logosInDb.Any(l => l != null && l.Contains(fileName));

            //SI il n'est pas utilisé et si son datetome de création est supérieur à 1h => on le supprime
            /*
            if (!used && fileInfo.CreationTime < DateTime.Now.AddHours(-1))
            {
                File.Delete(file);
            }
            */
            if (!used)
            {
                File.Delete(file);
            }
        }
    }
    public async Task CleanUnusedImagesForLigues()
    {
        var folder = Path.Combine(Directory.GetCurrentDirectory(),
                                  "wwwroot", "images", "ligues");

        var files = Directory.GetFiles(folder);


        //Pour plus de performance  => créer une nouvelle fonction dans l'API (un nouveau controller) qui ne renvoie que les logos et pas le reste
        var ligues = await _http.GetFromJsonAsync<List<Ligue>>("api/Ligues") ?? new List<Ligue>();

        var logosInDb = ligues
            .Where(l => !string.IsNullOrEmpty(l.Logo))
            .Select(l => l.Logo)
            .ToList();

        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file);
            var fileInfo = new FileInfo(file);

            // On vérifie si l'image (le file) apparait dans les logos des clubs
            bool used = logosInDb.Any(l => l != null && l.Contains(fileName));

            //SI il n'est pas utilisé et si son datetome de création est supérieur à 1h => on le supprime
            /*
            if (!used && fileInfo.CreationTime < DateTime.Now.AddHours(-1))
            {
                File.Delete(file);
            }
            */
            if (!used)
            {
                File.Delete(file);
            }
        }
    }
}
