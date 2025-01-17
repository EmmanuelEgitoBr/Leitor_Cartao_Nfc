using DigitalNfcCardReader.Domain.Entities.v1;
using DigitalNfcCardReader.Infra.Data.Queries.v1.NfcCard.GetNfcInfoByTagId;
using MediatR;

namespace DigitalNfcCardReader.Infra.Data.Queries.v1.NfcCard.GetNfcInfoBySerialCode
{
    public sealed class GetNfcInfoBySerialCodeQuery() : IRequest<GetNfcInfoBySerialCodeQueryResponse>
    {
        public string SerialCode { get; set; } = string.Empty;
    }
}
