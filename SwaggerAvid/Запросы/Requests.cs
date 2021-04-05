using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SwaggerAvid.моделиAPI;

namespace SwaggerAvid
{
    public static class Requests
    {
        /// <summary>
        /// Получает список узлов
        /// </summary>
        /// <returns></returns>
        public static async Task<Nodes> GetNodes()
        {
            const string localPath = "/v2/data_model/_node/";
            using (var response = await ApiHelper.ApiClient.GetAsync(localPath))
            {
                if (response.IsSuccessStatusCode)
                {
                    var node = await response.Content.ReadAsAsync<Nodes>();
                    return node;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Получить узел по id
        /// </summary>
        /// <returns></returns>
        public static async Task<Nodes> GetNode(int id)
        {
            var localPath = $"/v2/data_model/_node/{id}/";
            using (var response = await ApiHelper.ApiClient.GetAsync(localPath))
            {
                if (response.IsSuccessStatusCode)
                {
                    var node = await response.Content.ReadAsAsync<Nodes>();
                    return node;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        /// <summary>
        /// Создает новый узел
        /// </summary>
        public static async Task<bool> PostNode(Node node)
        {
            const string localPath = "/v2/data_model/_node/";

            var jsonMessage = JsonSerializer.Serialize(node, typeof(Node));
            var httpContent = new StringContent(jsonMessage);
            var response = await ApiHelper.ApiClient.PostAsync(localPath, httpContent);

            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Удаляет узел
        /// </summary>
        public static async Task<bool> DeleteNode(int id)
        {
            var localPath = $"/v2/data_model/_node/{id}/";
            var response = await ApiHelper.ApiClient.DeleteAsync(localPath);

            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Создает новый узел
        /// </summary>
        public static async Task<bool> PutNode(int id, Node node)
        {
            var localPath = $"/v2/data_model/_node/{id}/";

            var jsonMessage = JsonSerializer.Serialize(node, typeof(Node));
            var httpContent = new StringContent(jsonMessage);
            var response = await ApiHelper.ApiClient.PutAsync(localPath, httpContent);

            return response.IsSuccessStatusCode;
        }
    }
}