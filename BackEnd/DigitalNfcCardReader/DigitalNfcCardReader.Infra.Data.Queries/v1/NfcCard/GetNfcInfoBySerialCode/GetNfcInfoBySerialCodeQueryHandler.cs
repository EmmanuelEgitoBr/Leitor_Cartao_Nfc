using AutoMapper;
using DigitalNfcCardReader.Domain.Contracts.v1;
using DigitalNfcCardReader.Domain.Entities.v1;
using DigitalNfcCardReader.Domain.Models.v1;
using DigitalNfcCardReader.Infra.Data.Queries.v1.NfcCard.GetNfcInfoByTagId;
using MediatR;
using System.Xml.Linq;

namespace DigitalNfcCardReader.Infra.Data.Queries.v1.NfcCard.GetNfcInfoBySerialCode
{
    public sealed class GetNfcInfoBySerialCodeQueryHandler : IRequestHandler<GetNfcInfoBySerialCodeQuery, GetNfcInfoBySerialCodeQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly INfcCardRepository _repository;

        public GetNfcInfoBySerialCodeQueryHandler(IMapper mapper, INfcCardRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetNfcInfoBySerialCodeQueryResponse> Handle(GetNfcInfoBySerialCodeQuery request, CancellationToken cancellationToken)
        {
            var nfcData = await _repository.GetNfcDataBySerialCodeAsync(request.SerialCode, cancellationToken);

            var response = new GetNfcInfoBySerialCodeQueryResponse
            {
                NfcCard = _mapper.Map<NfcData, GetNfcInfoBySerialCodeQueryResponseDetail>(nfcData)
            };

            return response;
        }
    }
}
