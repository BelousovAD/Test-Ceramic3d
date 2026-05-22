using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace InputOutput
{
    internal class MatrixConverter : JsonConverter<Matrix4x4>
    {
        private const string M00 = nameof(Matrix4x4.m00);
        private const string M10 = nameof(Matrix4x4.m10);
        private const string M20 = nameof(Matrix4x4.m20);
        private const string M30 = nameof(Matrix4x4.m30);
        private const string M01 = nameof(Matrix4x4.m01);
        private const string M11 = nameof(Matrix4x4.m11);
        private const string M21 = nameof(Matrix4x4.m21);
        private const string M31 = nameof(Matrix4x4.m31);
        private const string M02 = nameof(Matrix4x4.m02);
        private const string M12 = nameof(Matrix4x4.m12);
        private const string M22 = nameof(Matrix4x4.m22);
        private const string M32 = nameof(Matrix4x4.m32);
        private const string M03 = nameof(Matrix4x4.m03);
        private const string M13 = nameof(Matrix4x4.m13);
        private const string M23 = nameof(Matrix4x4.m23);
        private const string M33 = nameof(Matrix4x4.m33);
        
        public override void WriteJson(JsonWriter writer, Matrix4x4 value, JsonSerializer serializer)
        {
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName(M00);
            writer.WriteValue(value[0, 0]);
            writer.WritePropertyName(M10);
            writer.WriteValue(value[1, 0]);
            writer.WritePropertyName(M20);
            writer.WriteValue(value[2, 0]);
            writer.WritePropertyName(M30);
            writer.WriteValue(value[3, 0]);
            writer.WritePropertyName(M01);
            writer.WriteValue(value[0, 1]);
            writer.WritePropertyName(M11);
            writer.WriteValue(value[1, 1]);
            writer.WritePropertyName(M21);
            writer.WriteValue(value[2, 1]);
            writer.WritePropertyName(M31);
            writer.WriteValue(value[3, 1]);
            writer.WritePropertyName(M02);
            writer.WriteValue(value[0, 2]);
            writer.WritePropertyName(M12);
            writer.WriteValue(value[1, 2]);
            writer.WritePropertyName(M22);
            writer.WriteValue(value[2, 2]);
            writer.WritePropertyName(M32);
            writer.WriteValue(value[3, 2]);
            writer.WritePropertyName(M03);
            writer.WriteValue(value[0, 3]);
            writer.WritePropertyName(M13);
            writer.WriteValue(value[1, 3]);
            writer.WritePropertyName(M23);
            writer.WriteValue(value[2, 3]);
            writer.WritePropertyName(M33);
            writer.WriteValue(value[3, 3]);
            writer.WriteEndObject();
        }

        public override Matrix4x4 ReadJson(JsonReader reader, Type objectType, Matrix4x4 existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);

            return new Matrix4x4(
                new Vector4((float)jObject[M00], (float)jObject[M10], (float)jObject[M20], (float)jObject[M30]),
                new Vector4((float)jObject[M01], (float)jObject[M11], (float)jObject[M21], (float)jObject[M31]),
                new Vector4((float)jObject[M02], (float)jObject[M12], (float)jObject[M22], (float)jObject[M32]),
                new Vector4((float)jObject[M03], (float)jObject[M13], (float)jObject[M23], (float)jObject[M33]));
        }
    }
}