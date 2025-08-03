using System.Net.Http.Headers;
using System.Text.Json;

namespace TwitchChatBot
{
    class Faceit
    {
        public string apikey;
        public Faceit(string apikey)
        {
            this.apikey = apikey;
            Console.WriteLine("Модуль Faceit загружен");
        }
        public async Task<string> GetPlayerIdByNickname(string nickname)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);

                string url = $"https://open.faceit.com/data/v4/players?nickname={nickname}";

                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    using (JsonDocument doc = JsonDocument.Parse(json))
                    {
                        JsonElement root = doc.RootElement;
                        if (root.TryGetProperty("player_id", out JsonElement playerIdElement))
                        {
                            return playerIdElement.GetString();
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Ошибка: {response.StatusCode}");
                }
            }

            return null;
        }
        //Получение АВГ игрока
        public async Task<string> GetAverageKillsAsync(string nickname)
        {
            string playerId = await GetPlayerIdByNickname(nickname);
            if (string.IsNullOrEmpty(playerId))
                return $"Не найден игрок {nickname}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);

                string url = $"https://open.faceit.com/data/v4/players/{playerId}/games/cs2/stats?limit=20";
                HttpResponseMessage response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    return $"Ошибка запроса: {response.StatusCode}";

                string json = await response.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(json);

                JsonElement items = doc.RootElement.GetProperty("items");
                int totalKills = 0;
                int count = 0;
                int totalDeath = 0;
                int totalAssists = 0;

                foreach (JsonElement match in items.EnumerateArray())
                {
                    if (match.TryGetProperty("stats", out JsonElement stats) &&
                        stats.TryGetProperty("Kills", out JsonElement killsElement) &&
                        int.TryParse(killsElement.GetString(), out int kills) &&
                        stats.TryGetProperty("Deaths", out JsonElement deadsElement) &&
                        int.TryParse(deadsElement.GetString(), out int deaths) &&
                        stats.TryGetProperty("Assists", out JsonElement assistsElement) &&
                        int.TryParse(assistsElement.GetString(), out int assists))
                    {
                        totalAssists += assists;
                        totalDeath += deaths;
                        totalKills += kills;
                        count++;
                    }
                }

                if (count == 0)
                    return "Нет данных по играм.";

                double avgKills = (double)totalKills / count;
                double avgDeaths = (double)totalDeath / count;
                double avgAssists = (double)totalAssists / count;

                int avgKillsInt = Convert.ToInt32(avgKills);
                int avgDeathsInt = Convert.ToInt32(avgDeaths);
                int AvgAssistsInt = Convert.ToInt32(avgAssists);
                return $"Stat for {count} Match, AVG: Kill: {avgKillsInt}, Death: {avgDeathsInt}, Assist: {avgAssists}";
            }
        }
        //Получаем Ело игрока
        public async Task<string> GetPlayerElo(string nickname)
        {
            string playerId = await GetPlayerIdByNickname(nickname);
            if (string.IsNullOrEmpty(playerId))
                return $"Не найден игрок {nickname}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apikey);
                string url = $"https://open.faceit.com/data/v4/players/{playerId}";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    using (JsonDocument doc = JsonDocument.Parse(json))
                    {
                        JsonElement root = doc.RootElement;

                        if (root.TryGetProperty("games", out JsonElement games) &&
                            games.TryGetProperty("cs2", out JsonElement cs2) &&
                            cs2.TryGetProperty("faceit_elo", out JsonElement eloElement) &&
                            cs2.TryGetProperty("skill_level", out JsonElement eloLvl))

                        {

                            return $" LVL: {eloLvl}, ELO: {eloElement.GetInt32().ToString()} ";
                        }
                    }
                }
            }
            return "Ошибка получения Elo";
        }
    }
}
