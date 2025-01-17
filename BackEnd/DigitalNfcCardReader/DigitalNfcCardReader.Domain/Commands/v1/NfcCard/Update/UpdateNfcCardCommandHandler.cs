using DigitalNfcCardReader.Domain.Contracts.v1;
using DigitalNfcCardReader.Domain.Entities.v1;
using MediatR;

namespace DigitalNfcCardReader.Domain.Commands.v1.NfcCard.Update
{
    public sealed class UpdateNfcCardCommandHandler : IRequestHandler<UpdateNfcCardCommand>
    {
        private readonly INfcCardRepository _repository;

        public UpdateNfcCardCommandHandler(INfcCardRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateNfcCardCommand request, CancellationToken cancellationToken)
        {
            var nfcData = new NfcData()
            {
                Id = request.Id,
                TagId = request.TagId,
                CardSerialCode = request.CardSerialCode,
                PatientName = request.PatientName,
                CardDeliveryDate = request.CardDeliveryDate,
                NfcStatus = request.NfcStatus,
                CardUpdateDate = request.CardUpdateDate,
                ModifierUserCode = request.ModifierUserCode
            };

            await _repository.UpdateNfcDataAsync(nfcData);
        }
    }
}
