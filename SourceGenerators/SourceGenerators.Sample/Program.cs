// See https://aka.ms/new-console-template for more information

using Currencies;
using Country = SourceGenerators.Sample.Country;

var channel = Country.Items.FirstOrDefault(x => x.CountryCode == "PL");
Console.WriteLine(channel);

var currency = Currency.Items.FirstOrDefault(x => x.Code == "PLN");
Console.WriteLine(currency);

Console.ReadLine();