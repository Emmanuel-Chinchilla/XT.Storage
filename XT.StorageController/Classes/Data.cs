using XT.StorageController.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace XT.StorageController.Classes
{
    public class Data : IData
    {
        private readonly string fileRoute;

        public Data(IConfiguration configuration) 
        {
            fileRoute = configuration["JSONPath"];
        }

        public dynamic GetData(int type)
        {
            var data = "";
            switch (type)
            {
                case 1:
                    data = GetJSONData();
                    break;
                default:
                    data = "Dato por defecto";
                    break;
            }

            return data;
        }

        private string GetJSONData()
        {
            string jsonString = "";
            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileRoute);

                if (File.Exists(filePath))
                {
                    jsonString = System.IO.File.ReadAllText(filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return jsonString;
            }


            return jsonString;
        }

    }
}
