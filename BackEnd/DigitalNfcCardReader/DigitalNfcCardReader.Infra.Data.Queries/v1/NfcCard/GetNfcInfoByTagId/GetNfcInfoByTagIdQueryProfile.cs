using AutoMapper;
using DigitalNfcCardReader.Domain.Entities.v1;

namespace DigitalNfcCardReader.Infra.Data.Queries.v1.NfcCard.GetNfcInfoByTagId
{
    public sealed class GetNfcInfoByTagIdQueryProfile : Profile
    {
        public GetNfcInfoByTagIdQueryProfile()
        {
            CreateMap<NfcData, GetNfcInfoByTagIdQueryResponseDetail>(MemberList.None);
        }
    }
}
