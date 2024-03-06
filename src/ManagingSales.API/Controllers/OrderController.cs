using ManagingSales.API.Core;
using ManagingSales.API.DTOs;
using ManagingSales.API.Mappings;
using ManagingSales.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagingSales.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class OrderController: BaseApiController
    {
        #region Fields

        private readonly IOrderService orderService;
        private readonly ILogger logger;

        #endregion


        #region Ctors

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
		{
            this.orderService = orderService;
            this.logger = logger;
        }

        #endregion


        #region Methods

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleResult(await Task.Run(async () =>
            {
                var models = await orderService.GetAllAsync(CancellationToken.None);

                return Result<IReadOnlyCollection<OrderDto>>.Success(models.ToViewModel());
            }));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken ct)
        {
            return HandleResult(await Task.Run(async () =>
            {
                var certificate = await orderService.GetByIdAsync(id, ct);

                return Result<OrderDto>.Success(certificate.ToViewModel());
            }));
        }

        [HttpPut]
        [Route("id")]
        public async Task<IActionResult> UpdateAsync(long id, OrderDto model, CancellationToken ct)
        {
            var certificate = await orderService.UpdateAsync(model.ToModel(), ct);

            return Ok(certificate.ToViewModel());
        }

        [HttpPost]
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> AddAsync(OrderDto model, CancellationToken ct)
        {
            var certificate = await orderService.AddAsync(model.ToModel(), ct);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = certificate.Id }, certificate);
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> RemoveAsync(long id, CancellationToken ct)
        {
            await orderService.RemoveAsync(id, ct);

            return NoContent();
        }

        #endregion
    }
}

