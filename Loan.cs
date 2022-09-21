namespace csharp_banca_oop;

public class Loan
{
   private static int _id { get; set; } = 0;
   public User LoanHolder { get; }
   public decimal Amount { get; }
   public decimal Rate { get; }
   public DateOnly StartDate { get; }
   public DateOnly EndDate { get; private set; }

   public Loan(User user, decimal amount, decimal rate)
   {
      _id += 1;
      LoanHolder = user;
      Amount = amount;
      Rate = rate;
      StartDate = new DateOnly(2022, 9, 21);
      EndDate = StartDate.AddMonths((int)(amount / rate) + 1);
   }

   public override string ToString()
   {
      return $"{LoanHolder.FirstName} {LoanHolder.LastName} - {Amount} {Rate} {StartDate} {EndDate}";
   }
}