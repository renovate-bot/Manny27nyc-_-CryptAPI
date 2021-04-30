# CryptAPI
Unofficial API Wrapper for CryptAPI in .NET

### Characteristics:
- Library written in .NET Standard for greater compatibility in C#
- Easy to use

### Usage:
#### Initialization:
```csharp
var CryptApi = new CryptAPI(CryptoCurrency.BTC);
```

#### Create a charge:
```csharp
// The address obtained is where the user must pay, after payment, CryptApi will make a GET request to your callback
// note: you can put the parameters you want in the callback
var address_in = CryptApi.CreateCharge("bc1qhkl8kmardm8jcmn5jtm8u78v8jc7hzsu0weea2", CallBack: "https://biitez.dev/");
```

#### Currency Info:
```csharp
var CurrencyInfo = CryptApi.CurrencyInfo();

Console.WriteLine(CurrencyInfo.coin);
Console.WriteLine(CurrencyInfo.minimum_fee);
Console.WriteLine(CurrencyInfo.minimum_fee_coin);
Console.WriteLine(CurrencyInfo.minimum_transaction);
Console.WriteLine(CurrencyInfo.prices.USD);
Console.WriteLine(CurrencyInfo.fee_percent);
```

#### Callback Logs:
```csharp
// returns all the information about the times the request was made to your callback or payment information
var callbacklogs = CryptApi.CallBackLogs("https://biitez.dev/");

// Example:
foreach (var i in callbacklogs.callbacks)
{
   Console.WriteLine(i.last_update);
   Console.WriteLine(i.txid_in);
   Console.WriteLine(i.confirmations);

   foreach (var e in i.logs)
   {
      Console.WriteLine(e.request_url);
      Console.WriteLine(e.timestamp);
      Console.WriteLine(e.next_try);
      Console.WriteLine(e.request_url);
   }
}
```

### Credits:
- https://t.me/biitez
- BTC Address: bc1qhkl8kmardm8jcmn5jtm8u78v8jc7hzsu0weea2
