using DigitalNfcCardReader.Domain.Contracts.v1;
using DigitalNfcCardReader.Domain.Entities.v1;
using MediatR;

namespace DigitalNfcCardReader.Domain.Commands.v1.NfcCard.Create
{
    public sealed class CreateNfcCardCommandHandler : IRequestHandler<CreateNfcCardCommand>
    {
        private readonly INfcCardRepository _repository;

        public CreateNfcCardCommandHandler(INfcCardRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateNfcCardCommand request, CancellationToken cancellationToken)
        {
            var nfcData = new NfcData
            {
                TagId = request.TagId,
                CardSerialCode = request.CardSerialCode,
                PatientName = request.PatientName,
                CardDeliveryDate = request.CardDeliveryDate,
                NfcStatus = request.NfcStatus,
                CardUpdateDate = request.CardUpdateDate,
                ModifierUserCode = request.ModifierUserCode
            };

            await _repository.CreateNfcDataAsync(nfcData, cancellationToken);
        }
    }
}
