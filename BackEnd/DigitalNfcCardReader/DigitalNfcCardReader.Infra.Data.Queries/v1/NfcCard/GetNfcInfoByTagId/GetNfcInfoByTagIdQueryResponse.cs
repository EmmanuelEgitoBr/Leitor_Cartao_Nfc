namespace DigitalNfcCardReader.Infra.Data.Queries.v1.NfcCard.GetNfcInfoByTagId
{
    public sealed record GetNfcInfoByTagIdQueryResponse
    {
        public GetNfcInfoByTagIdQueryResponseDetail? NfcCard { get; init; }
    }
}
