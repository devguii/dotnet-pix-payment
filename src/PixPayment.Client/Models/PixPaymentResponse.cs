namespace PixPayment.Client.Models;

public class PixPaymentResponse
{
    public string CopyAndPaste { get; set; } = string.Empty;
    public string QrCodeBase64 { get; set; } = string.Empty; // imagem convertida em texto
}