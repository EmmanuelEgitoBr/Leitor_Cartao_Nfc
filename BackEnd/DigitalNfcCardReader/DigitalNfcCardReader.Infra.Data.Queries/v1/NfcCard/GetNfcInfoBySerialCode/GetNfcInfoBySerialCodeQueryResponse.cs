namespace DigitalNfcCardReader.Infra.Data.Queries.v1.NfcCard.GetNfcInfoBySerialCode
{
    public sealed record GetNfcInfoBySerialCodeQueryResponse
    {
        public GetNfcInfoBySerialCodeQueryResponseDetail? NfcCard { get; init; }
    }
}
