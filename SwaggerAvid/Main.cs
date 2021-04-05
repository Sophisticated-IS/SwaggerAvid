using System;

namespace SwaggerAvid
{
    class Program
    {
        static void Main(string[] args)
        {
            const string baseAddress = "https://back.platform.main-dev.factory5.ai/api";
            ApiHelper.InitializeClient(baseAddress);

            #region Вызовы
            // Requests.GetNodes();
            // Requests.GetNode();
            // Requests.DeleteNode();
            // Requests.PutNode();
            // Requests.PostNode();
            #endregion
       
        }
    }
}