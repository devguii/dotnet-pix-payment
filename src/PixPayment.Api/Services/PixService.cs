using System.Text;
using PixPayment.Api.Models;

namespace PixPayment.Api.Services;

public class PixService
{
    public string GeneratePixString(PixPaymentRequest request)
    {
        // O Pix é composto por vários blocos (IDs). 
        // Aqui estamos montando o "Pix Estático" simplificado.
        
        var payload = new StringBuilder();
        
        // 00: Payload Format Indicator
        payload.Append("000201");
        
        // 26: Merchant Account Information (Chave Pix)
        // O tamanho desse bloco varia conforme a chave
        var merchantInfo = $"0014BR.GOV.BCB.PIX01{request.PixKey.Length:D2}{request.PixKey}";
        payload.Append($"26{merchantInfo.Length:D2}{merchantInfo}");
        
        // 52: Merchant Category Code (0000 para não categorizado)
        payload.Append("52040000");
        
        // 53: Transaction Currency (986 é o código para o Real BRL)
        payload.Append("5303986");
        
        // 54: Transaction Amount (valor com duas casas decimais)
        var amountStr = request.Amount.ToString("F2").Replace(",", ".");
        payload.Append($"54{amountStr.Length:D2}{amountStr}");
        
        // 58: Country Code (BR)
        payload.Append("5802BR");
        
        // 59: Merchant Name
        payload.Append($"59{request.ReceiverName.Length:D2}{request.ReceiverName}");
        
        // 60: Merchant City
        payload.Append($"60{request.City.Length:D2}{request.City}");
        
        // 62: Additional Data Field (ID do campo 05 para descrição)
        var additionalData = $"05{request.Description.Length:D2}{request.Description}";
        payload.Append($"62{additionalData.Length:D2}{additionalData}");

        // 63: CRC16 ("CheckSum" final - usando um placeholder por ser um projeto de estudo)
        // Em um sistema real, iria um cálculo matemático específico do CRC16.
        payload.Append("6304"); 

        return payload.ToString();
    }
}