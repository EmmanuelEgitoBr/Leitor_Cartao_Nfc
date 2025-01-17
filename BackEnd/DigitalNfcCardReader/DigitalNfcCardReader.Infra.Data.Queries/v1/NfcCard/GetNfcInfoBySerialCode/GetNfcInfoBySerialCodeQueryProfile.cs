using AutoMapper;
using DigitalNfcCardReader.Domain.Entities.v1;

namespace DigitalNfcCardReader.Infra.Data.Queries.v1.NfcCard.GetNfcInfoBySerialCode
{
    public sealed class GetNfcInfoBySerialCodeQueryProfile : Profile
    {
        public GetNfcInfoBySerialCodeQueryProfile()
        {
            CreateMap<NfcData, GetNfcInfoBySerialCodeQueryResponseDetail>(MemberList.None);
        }
    }
}
