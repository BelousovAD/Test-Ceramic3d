using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace InputOutput
{
    public static class Reader
    {
        public static IEnumerable<Matrix4x4> ReadMatrices(string filename) =>
            JsonConvert.DeserializeObject<List<Matrix4x4>>(ReadFile(filename));

        private static string ReadFile(string name)
        {
            string path = Path.Combine(Application.persistentDataPath, name);

            try
            {
                return File.ReadAllText(path);
            }
            catch (FileNotFoundException exception)
            {
                Debug.LogError(exception.Message);

                return null;
            }
        }
    }
}