using System.Runtime.Serialization.Formatters.Binary;
using TikTakToe.Core.Boards;
using TikTakToe.Core.Enums;

namespace TikTakToe.Core.Helpers {
    public static class DeepCloneExtension {
        public static Board DeepCloneByReflection(this Board source) {
            var type = source.GetType();

            var target = Activator.CreateInstance(type);

            foreach(var propertyInfo in type.GetProperties()) {
                // Handle value types and string
                if((propertyInfo.PropertyType.IsValueType ||
                propertyInfo.PropertyType == typeof(string)) && propertyInfo.CanWrite) {
                    propertyInfo.SetValue(target, propertyInfo.GetValue(source));
                }
                // Handle arrays
                else if(propertyInfo.PropertyType.IsSubclassOf(typeof(Array))) {
                    var value = (Array)propertyInfo.GetValue(source);

                    if(value != null) {
                        propertyInfo.SetValue(target, value.Clone());
                    }
                }
            }

            return (Board)target;
        }

        public static Board DeepCloneBySerialization(this Board source) {
            using(MemoryStream stream = new MemoryStream()) {
                if(source.GetType().IsSerializable) {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, source);
                    stream.Position = 0;
                    return (Board)formatter.Deserialize(stream);
                }
                return default;
            }
        }

        public static Board DeepCloneByCopy(this Board source) {
            var target = new Board();

            for(int i = 0; i < source.BoardSquares.Length; i++) {
                target.BoardSquares[i] = source.BoardSquares[i];
            }
            target.Score = source.Score;
            target.Move = source.Move;
            target.LengthX = source.LengthX;
            target.LengthY = source.LengthY;

            return target;
        }
    }
}
