namespace PixPayment.Api.Models;

public class PixPaymentRequest
{
    // chave Pix do recebedor (E-mail, CPF, CNPJ ou Chave Aleatória)
    public string PixKey { get; set; } = string.Empty;

    // nome de quem vai receber o dinheiro
    public string ReceiverName { get; set; } = string.Empty;

    // cidade do recebedor
    public string City { get; set; } = string.Empty;

    // valor da transação
    public decimal Amount { get; set; }

    // descrição para o pagamento
    public string Description { get; set; } = string.Empty;
}