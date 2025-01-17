using FluentValidation;

namespace DigitalNfcCardReader.Domain.Commands.v1.NfcCard.Create
{
    public sealed class CreateNfcCardCommandValidator : AbstractValidator<CreateNfcCardCommand>
    {
        public CreateNfcCardCommandValidator()
        {
            RuleFor(x => x.CardSerialCode)
                .NotEmpty();
            RuleFor(x => x.PatientName)
                .NotEmpty();
        }
    }
}
