using System.Text;
using Newtonsoft.Json;
//using System.Text.Json;

namespace DataManagement;
public class DataManagementService
{
    public static bool save_data<T>(T data,string filename)
    {
        
        try
        {
            string filePath = $"../../../Data/{filename}";
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            string directoryPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            
            Console.WriteLine(directoryPath);
            
            File.WriteAllText(filePath, json,Encoding.UTF8);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public  static  T  get_data<T>(string filename)
    {
        try
        {
            string filePath = $"../../../Data/{filename}";
            string directoryPath = Path.GetDirectoryName(filePath);
           var stringData=  File.ReadAllText(directoryPath,Encoding.UTF8);
           T data = JsonConvert.DeserializeObject<T>(stringData);
           return data;        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }
}