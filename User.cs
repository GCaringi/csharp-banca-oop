namespace csharp_banca_oop;

public class User
{
    public string FirstName { get; }
    public string LastName { get; }
    public string TaxCode { get; private set; }
    public int Salary { get; set; }
    public List<Loan> Loans { get; }

    public User(string name, string lastName)
    {
        FirstName = name;
        LastName = lastName;
        TaxCode = "";
        Salary = new Random().Next(800, 2500);
        Loans = new List<Loan>();
    }
    
    public User(string name, string lastName, string taxCode)
    {
        FirstName = name;
        LastName = lastName;
        TaxCode = taxCode;
        Salary = new Random().Next(800, 2500);
        Loans = new List<Loan>();
    }
    
    public void SetTaxCode(string taxCode)
    {
        TaxCode = taxCode;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} - {TaxCode} - {Salary} $";
    }
}