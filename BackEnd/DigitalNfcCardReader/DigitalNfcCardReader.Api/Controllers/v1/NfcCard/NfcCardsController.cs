using DigitalNfcCardReader.Domain.Commands.v1.NfcCard.Create;
using DigitalNfcCardReader.Infra.Data.Queries.v1.NfcCard.GetNfcInfoBySerialCode;
using DigitalNfcCardReader.Infra.Data.Queries.v1.NfcCard.GetNfcInfoByTagId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalNfcCardReader.Api.Controllers.v1.NfcCard
{
    [Route("api/nfc-cards")]
    [ApiController]
    public class NfcCardsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("by-serial-code/{serialCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetNfcInfoBySerialCodeQueryResponse>> GetNfcInfoBySerialCodeAsync(
            string serialCode)
        {
            var result = await _mediator.Send(new GetNfcInfoBySerialCodeQuery { SerialCode = serialCode });

            return result;
        }

        [HttpGet("by-tag-id/{tagId:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetNfcInfoByTagIdQueryResponse>> GetNfcInfoByTagIdAsync(long tagId)
        {
            var result = await _mediator.Send(new GetNfcInfoByTagIdQuery { TagId = tagId });

            return result;
        }

        [HttpPost("create-tag-id")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateNfcInfoByTagIdAsync(
            [FromBody] CreateNfcCardCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}