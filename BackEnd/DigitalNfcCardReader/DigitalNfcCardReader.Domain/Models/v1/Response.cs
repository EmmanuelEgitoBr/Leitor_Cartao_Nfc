namespace DigitalNfcCardReader.Domain.Models.v1
{
    public record Response<T> where T : class
    {
        public T? Content { get; init; }

        public static long Timestamp => new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

        public string? TraceId { get; set; }

        public Response(T? content)
        {
            Content = content;
        }
    }
}
