using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;


namespace JVKExpensesTracker.Server.Data.Models;


public class Wallet
{//now we serialize the names as names in cosmos are camel case and in class are capitals, so we use json serializer
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("type")]
    public string? TypeName { get; set; }

    public WalletType? Type => GetWalletTypeFromString(TypeName);

    
    [JsonPropertyName("bankName")]
    public string? BankName { get; set;}

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("iban")]
    public string? Iban { get; set; }

    [JsonPropertyName("accountType")]
    public string? AccountType { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("swift")]
    public string? Swift { get; set;}

    [JsonPropertyName("balance")]
    public decimal Balance { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get;  set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; set; }

    [JsonPropertyName("modificationDate")]
    public DateTime ModificationDate { get; set; }



    private WalletType? GetWalletTypeFromString(String? typeName)
    {
        return typeName switch
        {
            "Bank" => WalletType.Bank,
            "Paypal" => WalletType.Paypal,
            "Cash" => WalletType.Cash,
            _ => WalletType.Others // default case
        };
    }

}
