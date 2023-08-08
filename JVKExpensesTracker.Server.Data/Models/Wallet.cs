using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


namespace JVKExpensesTracker.Server.Data.Models;


public class Wallet
{//now we serialize the names as names in cosmos are camel case and in class are capitals, so we use json serializer
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("type")]
    public string? TypeName { get; set; }

    public WalletType? Type => GetWalletTypeFromString(TypeName);

    
    [JsonProperty("bankName")]
    public string? BankName { get; set;}

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("iban")]
    public string? Iban { get; set; }

    [JsonProperty("accountType")]
    public string? AccountType { get; set; }

    [JsonProperty("userId")]
    public string? UserId { get; set; }

    [JsonProperty("swift")]
    public string? Swift { get; set;}

    [JsonProperty("balance")]
    public decimal Balance { get; set; }

    [JsonProperty("currency")]
    public string? Currency { get;  set; }

    [JsonProperty("username")]
    public string? Username { get; set; }

    [JsonProperty("creationDate")]
    public DateTime CreationDate { get; set; }

    [JsonProperty("modificationDate")]
    public DateTime ModificationDate { get; set; }



    private WalletType? GetWalletTypeFromString(String? typeName)
    {
        return typeName switch
        {
            "Bank" => WalletType.Bank,
            "PayPal" => WalletType.PayPal,
            "Cash" => WalletType.Cash,
            _ => WalletType.Others // default case
        };
    }

}
