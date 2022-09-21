using System;
using csharp_banca_oop;

Bank bank = new Bank("Intesa");
int prompt;
User client1 = new User("Mario", "Rossi", "27489284");
Loan cliloan1 = new Loan(client1, 500, 50);
Loan cliloan2 = new Loan(client1, 1000, 100);
bank.AddUser(client1);
bank.AddLoan(cliloan1, client1);
bank.AddLoan(cliloan2, client1);

Prompt();
while (prompt != -1)
{
    switch (prompt)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("REGISTRA CLIENTE\n");
            Console.WriteLine("Inserisci il nome del cliente: ");
            string? fullName = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome del cliente: ");
            string? lastName = Console.ReadLine();
            Console.WriteLine("Inserisci il codice fiscale del cliente: ");
            string? taxCode = Console.ReadLine();
            User client = new User(fullName, lastName, taxCode);
            bank.AddUser(client);
            Console.WriteLine("Cliente registrato con successo!");
            Thread.Sleep(500);
            Console.Clear();
            Prompt();
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("CREAZIONE PRESTITO\n");
            Console.Write("Vuoi creare un prestito per un cliente già registrato? (S/N): ");
            char choice = Convert.ToChar(Console.ReadLine());
            if (choice == 'S')
            {
                Console.Write("Inserisci il codice fiscale: ");
                string? taxcode = Console.ReadLine();
                User findClient = bank.FindUserByTaxCode(taxcode);
                Console.Write("Inserisci l'importo del prestito: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Inserisci l'importo della rata: ");
                decimal rate = Convert.ToDecimal(Console.ReadLine());
                Loan loan = new Loan(findClient, amount, rate);
                bank.AddLoan(loan, findClient);
                Console.WriteLine("Prestito registrato con successo!");
                Thread.Sleep(500);
                Console.Clear();
                Prompt();
            }
            else
            {
                Console.WriteLine("Inserisci il nome del cliente: ");
                string? fullname = Console.ReadLine();
                Console.WriteLine("Inserisci il cognome del cliente: ");
                string? lastname = Console.ReadLine();
                Console.WriteLine("Inserisci il codice fiscale del cliente: ");
                string? Taxcode = Console.ReadLine();
                User Client = new User(fullname, lastname, Taxcode);
                bank.AddUser(Client);
                Console.Write("Inserisci il codice fiscale: ");
                string? taxcode = Console.ReadLine();
                User findClient = bank.FindUserByTaxCode(taxcode);
                Console.Write("Inserisci l'importo del prestito: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Inserisci l'importo della rata: ");
                decimal rate = Convert.ToDecimal(Console.ReadLine());
                Loan loan = new Loan(findClient, amount, rate);
                bank.AddLoan(loan, findClient);
                Console.WriteLine("Prestito registrato con successo!");
                Thread.Sleep(500);
                Console.Clear();
                Prompt();
            }
            break;
        case 3:
                Console.Clear();
                Console.WriteLine("CERCA PRESTITI PER CLIENTE\n");
                Console.Write("Inserisci il codice fiscale: ");
                string? TaxCode = Console.ReadLine();
                List<Loan> listLoan = bank.GetLoansByUser(TaxCode);
                if (!listLoan.Any())
                {
                    Console.WriteLine("Nessun prestito trovato!");
                    Thread.Sleep(500);
                    Console.Clear();
                    Prompt();
                }
                else
                {
                    foreach (Loan loan in listLoan)
                    {
                        Console.WriteLine(loan);
                    }

                    Thread.Sleep(500);
                    Console.Clear();
                    Prompt();
                }
                break;
        case 4:
            Console.Clear();
            Console.WriteLine("CERCA TOTALE PRESTITI CLIENTI\n");
            User user = new User("Mario", "Rossi", "27489284");
            bank.AddUser(user);
            Loan userLoan = new Loan(user, 1000, 100);
            bank.AddLoan(userLoan, user);
            Loan userLoan2 = new Loan(user, 1000, 500);
            bank.AddLoan(userLoan2, user);
            Console.WriteLine("Totale prestiti: " + bank.GetTotalLoansByUser("27489284"));
            Thread.Sleep(500);
            Console.Clear();
            Prompt();
            break;
        case 5:
            Console.Clear();
            Console.WriteLine("CERCA TOTALE RATE MANCANTI\n");
            int total = bank.GetTotalRateMissToPay(client1.TaxCode);
            Console.WriteLine($"Totale: {total}");
            Thread.Sleep(500);
            Console.Clear();
            Prompt();
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