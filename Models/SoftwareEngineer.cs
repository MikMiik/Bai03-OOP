namespace Bai03.Models;

public class SoftwareEngineer : Employee
{
    private string _primaryLanguage = string.Empty;
    private double _technicalAllowance;

    public string PrimaryLanguage
    {
        get => _primaryLanguage;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            _primaryLanguage = value;
        }
    }

    public double TechnicalAllowance
    {
        get => _technicalAllowance;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _technicalAllowance = value;
        }
    }

    public SoftwareEngineer(string id, string fullName, string primaryLanguage) : base(id, fullName)
    {
        PrimaryLanguage = primaryLanguage;
    }

    public SoftwareEngineer(string id, string fullName, double baseSalary, string primaryLanguage, double technicalAllowance) : base(id, fullName, baseSalary)
    {
        PrimaryLanguage = primaryLanguage;
        TechnicalAllowance = technicalAllowance;
    }

    public override double CalculateMonthlyCost()
    {
        double total = base.CalculateMonthlyCost() + TechnicalAllowance;
        return total;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}, Name: {FullName}, Base Salary: {BaseSalary:N0}, Primary Language: {PrimaryLanguage}, Technical Allowance: {TechnicalAllowance:N0}, Monthly Cost: {CalculateMonthlyCost():N0}");
    }

    ~SoftwareEngineer()
    {
        Console.WriteLine($"Destructor SoftwareEngineer {FullName} (Lang: {PrimaryLanguage}), ID: {Id}");
    }
}