using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace DotNetUrlDeserializer.Implementation
{
    public static class UrlDeserializer
    {
        private static readonly string[] _booleans = { "false", "true" };
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        ///     Deserializes an UrlEncoded formatted string into an actual object of the provided type.
        /// </summary>
        /// <param name="decoded">The decoded UrlEncoded <see cref="string"/> formatted to deserialize.</param>
        /// <typeparam name="TResponse">The type into which string will be deserialized.</typeparam>
        /// <returns>The created object as result of deserialization.</returns>
        public static TResponse DeserializeEncoded<TResponse>(string query, Encoding? encoding = null)
        {
            return Deserialize<TResponse>(HttpUtility.UrlDecode(query, encoding ?? Encoding.UTF8).AsSpan());
        }
        
        /// <summary>
        ///     Deserializes an UrlEncoded formatted string into an actual object of the provided type.
        /// </summary>
        /// <param name="decoded">The decoded UrlEncoded <see cref="ReadOnlySpan{char}"/> formatted to deserialize.</param>
        /// <typeparam name="TResponse">The type into which string will be deserialized.</typeparam>
        /// <returns>The created object as result of deserialization.</returns>
        public static TResponse Deserialize<TResponse>(ReadOnlySpan<char> decoded)
        {
            var count = 0;
            foreach (var t in decoded)
            {
                if (t == '=') count += 1;
            }

            var jsonSpanLength = decoded.Length + count * 4 + 2;
            Span<char> jsonSpan = stackalloc char[jsonSpanLength];
            jsonSpan[0] = '{';
            jsonSpan[^1] = '}';

            var offset = 0;
            var length = 0;
            var index = 1;

            try
            {
                for (var i = 0; i < decoded.Length; i++)
                {
                    if (decoded[i] == '=')
                    {
                        if (i == decoded.Length - 1 || decoded[i + 1] == '&')
                        {
                            var tempIndex = offset == 0 || jsonSpan[index - 1] != ',' || i != decoded.Length - 1
                                ? index
                                : index - 1;
                            jsonSpan[tempIndex..^1].Fill(' ');
                        }
                        else
                        {
                            var name = decoded.Slice(offset, length);
                            jsonSpan[index++] = '\"';
                            name.CopyTo(jsonSpan[index..]);
                            index += length;
                            jsonSpan[index++] = '\"';
                            jsonSpan[index++] = ':';
                        }

                        offset = i + 1;
                        length = 0;

                        continue;
                    }

                    if (decoded[i] == '&' && length == 0)
                    {
                        jsonSpan[index] = ' ';
                        offset = i + 1;
                        continue;
                    }

                    if (decoded[i] == '&' || i == decoded.Length - 1 && length != 0)
                    {
                        var valueLength = i == decoded.Length - 1 ? length + 1 : length;
                        var value = decoded.Slice(offset, valueLength);

                        var isBoolean = value.SequenceEqual(_booleans[0]) || value.SequenceEqual(_booleans[1]);
                        jsonSpan[index] = value[0] != '{' && value[0] != '[' && !isBoolean ? '\"' : ' ';
                        index++;
                        value.CopyTo(jsonSpan[index..]);
                        index += valueLength;
                        jsonSpan[index] = value[^1] != '}' && value[^1] != ']' && !isBoolean ? '\"' : ' ';
                        index++;
                        if (i != decoded.Length - 1) jsonSpan[index++] = ',';

                        offset = i + 1;
                        length = 0;
                        continue;
                    }

                    length++;
                }

                return JsonSerializer.Deserialize<TResponse>(jsonSpan, _jsonSerializerOptions);
            }
            catch (Exception e)
            {
                throw new UrlException(jsonSpan.ToString(), e);
            }
        }
    }
}
