using AutoMapper;
using DigitalNfcCardReader.Domain.Contracts.v1;
using DigitalNfcCardReader.Domain.Entities.v1;
using MediatR;

namespace DigitalNfcCardReader.Infra.Data.Queries.v1.NfcCard.GetNfcInfoByTagId
{
    public sealed class GetNfcInfoByTagIdQueryHandler : IRequestHandler<GetNfcInfoByTagIdQuery, GetNfcInfoByTagIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly INfcCardRepository _repository;

        public GetNfcInfoByTagIdQueryHandler(IMapper mapper, INfcCardRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetNfcInfoByTagIdQueryResponse> Handle(GetNfcInfoByTagIdQuery request, CancellationToken cancellationToken)
        {
            var nfcData = await _repository.GetNfcDataByTagIdAsync(request.TagId, cancellationToken);

            var response = new GetNfcInfoByTagIdQueryResponse
            {
                NfcCard = _mapper.Map<NfcData, GetNfcInfoByTagIdQueryResponseDetail>(nfcData)
            };

            return response;
        }
    }
}
