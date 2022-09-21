namespace csharp_banca_oop;

public class User
{
    public string FirstName { get; }
    public string LastName { get; }
    public string TaxCode { get; private set; }
    public int Salary { get; set; }

    public User(string name, string lastName)
    {
        FirstName = name;
        LastName = lastName;
        TaxCode = "";
        Salary = new Random().Next(800, 2500);
    }
    
    public void SetTaxCode(string taxCode)
    {
        TaxCode = taxCode;
    }
}