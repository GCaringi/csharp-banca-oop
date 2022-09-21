using System;
using csharp_banca_oop;

Bank bank = new Bank("Intesa");
User client_1 = new User("Gianni","Caringi");


Console.WriteLine($"Nome banca: {bank.Name}");

Console.WriteLine(client_1.ToString());;

Console.WriteLine();
client_1.SetTaxCode("CRNGNN65D16B453P");

Console.WriteLine(client_1.ToString());
