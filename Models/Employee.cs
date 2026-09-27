namespace Bai03.Models;

public class Employee
{
    private string _id = string.Empty;
    private string _fullName = string.Empty;
    private double _baseSalary;

    public string Id
    {
        get => _id;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            _id = value;
        }
    }

    public string FullName
    {
        get => _fullName;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            _fullName = value;
        }
    }

    public double BaseSalary
    {
        get => _baseSalary;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _baseSalary = value;
        }
    }

    public Employee() : this("UNKNOWN", "Unnamed employee") { }

    public Employee(string id, string fullName) : this(id, fullName, 0)
    {
        Console.WriteLine($"Employee created with ID: {id}, Name: {fullName}");
    }

    public Employee(string id, string fullName, double baseSalary)
    {
        Id = id;
        FullName = fullName;
        BaseSalary = baseSalary;
    }

    public void IncreaseSalary(double amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        BaseSalary += amount;
        Console.WriteLine($"Salary of {FullName} increased by {amount:N0}. New salary: {BaseSalary:N0}");
    }

    public void IncreaseSalary(double value, bool byPercentage)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
        BaseSalary += byPercentage ? BaseSalary * value / 100 : value;
        string unit = byPercentage ? "%" : "";
        Console.WriteLine($"... increased by {value:N0}{unit}. New salary: {BaseSalary:N0}");
    }

    public virtual double CalculateMonthlyCost()
    {
        return BaseSalary;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}, Name: {FullName}, Base Salary: {BaseSalary:N0}, Monthly Cost: {CalculateMonthlyCost():N0}");
    }
    ~Employee()
    {
        Console.WriteLine($"Destructor Employee {FullName}, ID: {Id}");
    }
}