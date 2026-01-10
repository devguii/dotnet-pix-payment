using Microsoft.AspNetCore.Mvc;
using PixPayment.Api.Models;
using PixPayment.Api.Services;

namespace PixPayment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PixController : ControllerBase
{
    private readonly PixService _pixService;

    // injetando o serviço automaticamente no construtor
    public PixController(PixService pixService)
    {
        _pixService = pixService;
    }

   [HttpPost("generate")]
   public IActionResult GeneratePix([FromBody] PixPaymentRequest request)
   {
       if (string.IsNullOrEmpty(request.PixKey))
           return BadRequest("A chave Pix é obrigatória.");
           
       var response = _pixService.CreatePayment(request);
   
       return Ok(response);
   }
}