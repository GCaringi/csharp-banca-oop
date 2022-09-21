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

    public void AddUser(User user)
    {
        if (user.TaxCode == "")
        {
            throw new Exception("Tax code is empty, fill it");
        }
        
        _clients.Add(user);
    }
    
    public User FindUserByName(string name)
    {
        User? findedUser = _clients.Find(user => user.FirstName == name);
        if (findedUser == null)
        {
            throw new Exception("User not found");
        }

        return findedUser;
    }
    
    public  User FindUserByTaxCode(string taxCode)
    {
        User? fidnedUser = _clients.Find(user => user.TaxCode == taxCode);
        if (fidnedUser == null)
        {
            throw new Exception("User not found");
        }
        
        return fidnedUser;
    }
    
    public static void ModifyUser(User user, int newSalary)
    {
        user.Salary = newSalary;
    }
    
    public void AddLoan(Loan loan, User user)
    {
        _loans.Add(loan);
        user.Loans.Add(loan);
    }

}