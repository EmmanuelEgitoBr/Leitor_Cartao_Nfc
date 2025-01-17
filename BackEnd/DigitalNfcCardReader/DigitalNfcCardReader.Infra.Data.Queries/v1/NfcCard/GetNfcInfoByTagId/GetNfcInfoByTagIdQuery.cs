using DigitalNfcCardReader.Domain.Entities.v1;
using MediatR;

namespace DigitalNfcCardReader.Infra.Data.Queries.v1.NfcCard.GetNfcInfoByTagId
{
    public sealed class GetNfcInfoByTagIdQuery() : IRequest<GetNfcInfoByTagIdQueryResponse>
    {
        public long TagId { get; set; }
    }
}
