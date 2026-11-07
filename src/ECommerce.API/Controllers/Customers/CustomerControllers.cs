using Asp.Versioning;
using ECommerce.API.Infrastructure;
using ECommerce.Application.Common;
using ECommerce.Application.Customers;
using ECommerce.Application.Ordering;
using ECommerce.Application.Shopping;
using ECommerce.Ordering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers.Customers;

[ApiController]
[ApiVersion(1.0)]
[Authorize(Policy = SecurityRegistration.CustomerPolicy)]
[Route("api/v{version:apiVersion}/customer")]
[Tags("Müşteri - Hesap")]
public class CustomerAccountController(ICustomerAuthService auth, ICustomerAddressService addresses) : ControllerBase
{
    [HttpGet("me")]
    public async Task<IActionResult> Me(CancellationToken cancellationToken)
    {
        var profile = await auth.GetProfileAsync(User.GetAccountId(), cancellationToken);
        return profile is null ? Problem(title: "Oturum geçersiz.", statusCode: StatusCodes.Status401Unauthorized) : Ok(profile);
    }

    [HttpPut("me")]
    public async Task<IActionResult> UpdateProfile(UpdateCustomerProfileRequest request, CancellationToken cancellationToken) =>
        this.ToActionResult(await auth.UpdateProfileAsync(User.GetAccountId(), request, cancellationToken), Ok);

    [HttpGet("addresses")]
    public async Task<IReadOnlyList<AddressDto>> ListAddresses(CancellationToken cancellationToken) =>
        await addresses.ListAsync(User.GetAccountId(), cancellationToken);

    [HttpPost("addresses")]
    public async Task<IActionResult> AddAddress(SaveAddressRequest request, CancellationToken cancellationToken) =>
        this.ToActionResult(await addresses.AddAsync(User.GetAccountId(), request, cancellationToken), a => StatusCode(StatusCodes.Status201Created, a));

    [HttpPut("addresses/{addressId:int}")]
    public async Task<IActionResult> UpdateAddress(int addressId, SaveAddressRequest request, CancellationToken cancellationToken) =>
        this.ToActionResult(await addresses.UpdateAsync(User.GetAccountId(), addressId, request, cancellationToken), Ok);

    [HttpDelete("addresses/{addressId:int}")]
    public async Task<IActionResult> DeleteAddress(int addressId, CancellationToken cancellationToken) =>
        this.ToActionResult(await addresses.DeleteAsync(User.GetAccountId(), addressId, cancellationToken), _ => NoContent());

    [HttpPost("addresses/{addressId:int}/default")]
    public async Task<IActionResult> SetDefaultAddress(int addressId, CancellationToken cancellationToken) =>
        this.ToActionResult(await addresses.SetDefaultAsync(User.GetAccountId(), addressId, cancellationToken), _ => NoContent());
}

[ApiController]
[ApiVersion(1.0)]
[Authorize(Policy = SecurityRegistration.CustomerPolicy)]
[Route("api/v{version:apiVersion}/customer/cart")]
[Tags("Müşteri - Sepet")]
public class CartController(ICartService cart) : ControllerBase
{
    [HttpGet]
    public async Task<CartDto> Get(CancellationToken cancellationToken) => await cart.GetAsync(User.GetAccountId(), cancellationToken);

    [HttpPost("items")]
    public async Task<IActionResult> AddItem(AddCartItemRequest request, CancellationToken cancellationToken) =>
        this.ToActionResult(await cart.AddItemAsync(User.GetAccountId(), request, cancellationToken), Ok);

    [HttpPut("items/{variantId:int}")]
    public async Task<IActionResult> UpdateItem(int variantId, UpdateCartItemRequest request, CancellationToken cancellationToken) =>
        this.ToActionResult(await cart.UpdateItemAsync(User.GetAccountId(), variantId, request.Quantity, cancellationToken), Ok);

    [HttpDelete("items/{variantId:int}")]
    public async Task<CartDto> RemoveItem(int variantId, CancellationToken cancellationToken) =>
        await cart.RemoveItemAsync(User.GetAccountId(), variantId, cancellationToken);
}

[ApiController]
[ApiVersion(1.0)]
[Authorize(Policy = SecurityRegistration.CustomerPolicy)]
[Route("api/v{version:apiVersion}/customer")]
[Tags("Müşteri - Sipariş")]
public class CustomerOrdersController(ICheckoutService checkout, IOrderManagementService orders) : ControllerBase
{
    [HttpGet("checkout/preview")]
    public async Task<IActionResult> Preview([FromQuery] PaymentMethod paymentMethod, CancellationToken cancellationToken) =>
        this.ToActionResult(await checkout.PreviewAsync(User.GetAccountId(), paymentMethod, cancellationToken), Ok);

    [HttpPost("orders")]
    [ProducesResponseType<OrderDto>(StatusCodes.Status201Created)]
    public async Task<IActionResult> PlaceOrder(CheckoutRequest request, CancellationToken cancellationToken) =>
        this.ToActionResult(await checkout.PlaceOrderAsync(User.GetAccountId(), request, cancellationToken),
            o => CreatedAtAction(nameof(Get), new { orderNumber = o.OrderNumber, version = "1" }, o));

    [HttpGet("orders")]
    public async Task<PagedResult<OrderSummaryDto>> List([FromQuery] int page = 0, [FromQuery] int size = 20, CancellationToken cancellationToken = default) =>
        await orders.ListForCustomerAsync(User.GetAccountId(), page, size, cancellationToken);

    [HttpGet("orders/{orderNumber}")]
    public async Task<IActionResult> Get(string orderNumber, CancellationToken cancellationToken) =>
        this.ToActionResult(await orders.GetForCustomerAsync(User.GetAccountId(), orderNumber, cancellationToken), Ok);

    [HttpPost("orders/{orderNumber}/cancel")]
    public async Task<IActionResult> Cancel(string orderNumber, CancellationToken cancellationToken) =>
        this.ToActionResult(await orders.CancelByCustomerAsync(User.GetAccountId(), orderNumber, cancellationToken), Ok);
}
