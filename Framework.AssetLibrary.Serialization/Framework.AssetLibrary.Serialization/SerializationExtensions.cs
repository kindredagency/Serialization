namespace Framework.AssetLibrary.Serialization
{
    public static class SerializationExtensions
    {
        public static byte[] SerializeToBytes(this object item)
        {
            var binarySerialization = new Serialization();

            return binarySerialization.SerializeToBytes(item);
        }

        public static string SerializeToBase64String(this object item)
        {
            var binarySerialization = new Serialization();

            return binarySerialization.SerializeToBase64String(item);
        }

        public static T DeserializeFromBytes<T>(this byte[] item) where T : class
        {
            var binarySerialization = new Serialization();

            return binarySerialization.DeserializeFromBytes<T>(item);
        }

        public static T DeserializeFromBase64String<T>(this string item) where T : class
        {
            var binarySerialization = new Serialization();

            return binarySerialization.DeserializeFromBase64String<T>(item);
        }
    }
}