using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Framework.AssetLibrary.Serialization
{
    /// <summary>
    /// Class Serialization.
    /// </summary>
    internal class Serialization
    {
        #region Public Methods

        /// <summary>
        /// Serializes to bytes.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public byte[] SerializeToBytes(object obj)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, obj);
            byte[] bytes = memoryStream.GetBuffer();

            return bytes;
        }

        /// <summary>
        /// Serializes to base64 string.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>Serialized string</returns>
        public string SerializeToBase64String(object obj)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, obj);
            byte[] bytes = memoryStream.GetBuffer();

            return Convert.ToBase64String(bytes, 0, bytes.Length, Base64FormattingOptions.None);
        }

        /// <summary>
        /// Deserialized from base64 string.
        /// </summary>
        /// <typeparam name="T">Type to convert after deserialization</typeparam>
        /// <param name="content">The content.</param>
        /// <returns>Deserialized object</returns>
        public T DeserializeFromBase64String<T>(string content) where T : class
        {
            T obj = (T)DeserializeFromBase64String(content);

            return obj;
        }

        /// <summary>
        /// Deserialized from bytes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content">The content.</param>
        /// <returns>T.</returns>
        public T DeserializeFromBytes<T>(byte[] content) where T : class
        {
            T obj = (T)DeserializeFromBytes(content);

            return obj;
        }

        /// <summary>
        /// Deserialized from base64 string.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>Deserialized Object</returns>
        public object DeserializeFromBase64String(string content)
        {
            byte[] memoryData = Convert.FromBase64String(content);
            int length = memoryData.Length;

            MemoryStream memoryStream = new MemoryStream(memoryData, 0, length);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            object obj = binaryFormatter.Deserialize(memoryStream);

            return obj;
        }

        /// <summary>
        /// Deserialized from bytes.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public object DeserializeFromBytes(byte[] content)
        {
            byte[] memoryData = content;
            int length = memoryData.Length;

            MemoryStream memoryStream = new MemoryStream(memoryData, 0, length);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            object obj = binaryFormatter.Deserialize(memoryStream);

            return obj;
        }

        #endregion Public Methods
    }
}