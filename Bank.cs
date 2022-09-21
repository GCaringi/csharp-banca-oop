namespace csharp_banca_oop;

public class Bank
{
    public string Name { get; }
    private List<User> _clients { get; }
    private List<Loan> _loans { get; }

    public Bank(string name)
    {
        Name = name;
        _clients = new List<User>();
        _loans = new List<Loan>();
    }
    
}