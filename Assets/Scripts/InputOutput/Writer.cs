using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace InputOutput
{
    public static class Writer
    {
        public static void WriteMatrices(string filename, IEnumerable<Matrix4x4> matrices)
        {
            string path = Path.Combine(Application.streamingAssetsPath, filename);
            string json = JsonConvert.SerializeObject(matrices, new MatrixConverter());
            File.WriteAllText(path, json);
        }
    }
}