using System;
using csharp_banca_oop;

Bank bank = new Bank("Intesa");
int prompt;
User client1 = new User("Mario", "Rossi", "27489284");
User client2 = new User("Luigi", "Bianchi");

Prompt();
while (prompt != -1)
{
    switch (prompt)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("Inserisci il nome del cliente: ");
            string? fullName = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome del cliente: ");
            string? lastName = Console.ReadLine();
            Console.WriteLine("Inserisci il codice fiscale del cliente: ");
            string? taxCode = Console.ReadLine();
            User client = new User(fullName, lastName, taxCode);
            bank.AddUser(client);
            Console.WriteLine("Cliente registrato con successo!");
            Console.Clear();
            Prompt();
            break;
        case 2:
            
            break;
        case 3:
           
            break;
        case 4:
           
            break;
        case 5:
           
            break;
        case -1:
            break;
        default:
            Console.WriteLine("Operazione non valida");
            break;
    }
        
}

void Prompt()
{
    Console.WriteLine($"Benvento presso la banca {bank.Name}");
    Console.WriteLine("Ecco le operazioni possibili da fare:");
    Console.WriteLine("1. Registrare un cliente");
    Console.WriteLine("2. Creare un prestito per un cliente");
    Console.WriteLine("3. Creare i prestiti concessi per un cliente");
    Console.WriteLine("4. Cercare la somma totale dei prestiti richiesti da un cliente");
    Console.WriteLine("5. Mostrare le rate residue che il cliente deve pagare");
    Console.Write("A quale servizio vuoi accedere? (-1 Per Uscire) ");
    prompt = Convert.ToInt32(Console.ReadLine());
}