using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SolMagro.Services
{
    public class FileService
    {
        public async Task SaveAsync<T>(string fileName, T content, string directoryName = null)
        {
            try
            {

                await Task.Run(() =>
                {

                    var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);

                    if (!string.IsNullOrEmpty(directoryName))
                    {
                        var folders = directoryName.Split('/');

                        foreach (var item in folders)
                        {
                            documentsPath = Path.Combine(documentsPath, item);

                            if (!Directory.Exists(documentsPath))
                                Directory.CreateDirectory(documentsPath);
                        }
                    }

                    var filePath = Path.Combine(documentsPath, fileName);


                    if (File.Exists(filePath))
                        File.Delete(filePath);


                    string result = JsonConvert.SerializeObject(content);
                    File.WriteAllText(filePath, result);
                });
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<T> LoadAsync<T>(string fileName, string directoryName = null)
        {
            try
            {
                return await Task.Run(async () =>
                {
                    if (await FileExists(fileName, directoryName))
                    {
                        var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                        if (!string.IsNullOrEmpty(directoryName))
                        {
                            var folders = directoryName.Split('/');

                            foreach (var item in folders)
                            {
                                documentsPath = Path.Combine(documentsPath, item);

                                if (!Directory.Exists(documentsPath))
                                    Directory.CreateDirectory(documentsPath);
                            }
                        }

                        var filePath = Path.Combine(documentsPath, fileName);

                        string result = System.IO.File.ReadAllText(filePath);
                        if (result.Equals("{}") || string.IsNullOrEmpty(result.Trim()) || result.Equals("\"\""))
                        {
                            return default(T);
                        }
                        else
                        {
                            T serializedResponse = JsonConvert.DeserializeObject<T>(result);
                            return serializedResponse;
                        }
                    }
                    else
                        return default(T);
                });
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<bool> FileExists(string fileName, string directoryName = null)
        {
            return await Task.Run<bool>(() =>
            {
                string documentsPath = string.Empty;

                if (fileName.Split('/').Length == 1)
                    documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                if (!string.IsNullOrEmpty(directoryName))
                {
                    var folders = directoryName.Split('/');

                    foreach (var item in folders)
                    {
                        documentsPath = Path.Combine(documentsPath, item);

                        if (!Directory.Exists(documentsPath))
                            return false;
                    }
                }

                var filename = Path.Combine(documentsPath, fileName);
                return File.Exists(filename);
            });
        }

    }
}
