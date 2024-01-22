using System;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Net.Shared.Extensions.Serialization.Json;

public static class JsonExtensions
{
    public static JsonSerializerOptions Options { get; }

    static JsonExtensions()
    {
        Options = new(JsonSerializerDefaults.Web);
        Options.Converters.Add(new DateOnlyConverter());
        Options.Converters.Add(new TimeOnlyConverter());
        Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    }

    public static T FromJson<T>(this string data) where T : class =>
        JsonSerializer.Deserialize<T>(data, Options) ?? throw new SerializationException($"The data '{data}' is not valid JSON");
    public static T FromJson<T>(this JsonDocument data) where T : class =>
        data.Deserialize<T>(Options) ?? throw new SerializationException($"The data '{data}' is not valid JSON");
    public static bool TryFromJson<T>(this string data, out T? result) where T : class
    {
        try
        {
            result = JsonSerializer.Deserialize<T>(data, Options);
            
            if (result is null)
                throw new SerializationException($"The data '{data}' is not valid JSON");

            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }
    public static string ToJson<T>(this T data) where T : class => data as string ?? JsonSerializer.Serialize(data, Options);

    public sealed class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly string _serializationFormat;
        public DateOnlyConverter() : this(null) { }
        public DateOnlyConverter(string? serializationFormat) => _serializationFormat = serializationFormat ?? "yyyy-MM-dd";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options) =>
            writer.WriteStringValue(value.ToString(_serializationFormat));
    }
    public sealed class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        private readonly string _serializationFormat;
        public TimeOnlyConverter() : this(null) { }
        public TimeOnlyConverter(string? serializationFormat) => _serializationFormat = serializationFormat ?? "HH:mm:ss";

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options) =>
            writer.WriteStringValue(value.ToString(_serializationFormat));
    }
}
