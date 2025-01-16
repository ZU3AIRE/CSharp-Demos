
bool next = false;
var list = new List<SpecialDiscount>();

do
{

    Console.Write("Enter Amount: ");
    var amount = Convert.ToInt32(Console.ReadLine());


    Console.Write("Choose discount type:\n1. Employee\n2.Student\n> ");
    var choice = Convert.ToInt32(Console.ReadLine());


    SpecialDiscount discount = null;

    switch (choice)
    {
        case 1:
            discount = new Employee();
            discount.Amount = amount;
            break;
        case 2:
            discount = new Student();
            discount.Amount = amount;
            break;
        default:
            Console.WriteLine("Invalid Input, Bye 👋");
            break;
    }

    if (discount != null)
    {
        list.Add(discount);
    }


    // Result
    Console.WriteLine($"Total Amount: {discount.Calculate()}");

    // Again Input or Not?
    Console.Write("Do you want to calculate again? Y/N: ");
    var key = Console.ReadLine();
    next = key == "Y" || key == "y";

} while (next);


Console.WriteLine($"\n#, Type, Amount, Disounted");
int x = 1;
foreach (var inp in list)
{
    Console.WriteLine($"{x++}, {inp.GetType()}, {inp.Amount}, {inp.Calculate()}");
}


class SpecialDiscount
{
    public int Amount { get; set; }

    public virtual double Calculate()
    {
        return Amount * 0.98;
    }
}


class Employee : SpecialDiscount
{
    public override double Calculate()
    {
        return Amount * 0.80;
    }
}

class Student : SpecialDiscount
{
    public override double Calculate()
    {
        return Amount * 0.95;
    }
}