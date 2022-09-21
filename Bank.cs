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
        User? findUser = _clients.Find(user => user.FirstName == name);
        if (findUser == null)
        {
            throw new Exception("User not found");
        }

        return findUser;
    }
    
    public  User FindUserByTaxCode(string taxCode)
    {
        User? findUser = _clients.Find(user => user.TaxCode == taxCode);
        if (findUser == null)
        {
            throw new Exception("User not found");
        }
        
        return findUser;
    }
    
    public void ModifyUser(User user, int newSalary)
    {
        if (_clients.Contains(user))
        {
            user.Salary = newSalary;
        }
        else
        {
            throw new Exception("User not found");
        }
    }
    
    public void AddLoan(Loan loan, User user)
    {
        _loans.Add(loan);
        user.Loans.Add(loan);
    }

    public List<Loan> GetLoansByUser(string taxCode)
    {
        User? user = FindUserByTaxCode(taxCode);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (!user.Loans.Any())
        {
            throw new Exception("User has no loans");
        }
        
        return user.Loans;
    }
    
    public int GetTotalLoansByUser(string taxCode)
    {
        User? user = FindUserByTaxCode(taxCode);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (!user.Loans.Any())
        {
            throw new Exception("User has no loans");
        }
        
        return (int)user.Loans.Sum(loan => loan.Amount);
    }

    public int GetTotalRateMissToPay(string taxCode)
    {
        User? user = FindUserByTaxCode(taxCode);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        
        if (!user.Loans.Any())
        {
            throw new Exception("User has no loans");
        }

        int total = 0;
        foreach (Loan loan in user.Loans)
        {
            int tempRate = (int)(loan.Amount / loan.Rate);
            total += tempRate;
        }

        return total;
    }
}