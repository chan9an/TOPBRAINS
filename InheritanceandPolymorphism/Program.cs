using System;
using System.Collections.Generic;
using System.Globalization;

abstract class Employee
{
    public abstract decimal GetPay();
}

class HourlyEmployee : Employee
{
    decimal rate;
    decimal hours;
    public HourlyEmployee(decimal rate, decimal hours)
    {
        this.rate = rate;
        this.hours = hours;
    }
    public override decimal GetPay()
    {
        return rate * hours;
    }
}

class SalariedEmployee : Employee
{
    decimal salary;
    public SalariedEmployee(decimal salary)
    {
        this.salary = salary;
    }
    public override decimal GetPay()
    {
        return salary;
    }
}

class CommissionEmployee : Employee
{
    decimal commission;
    decimal baseSalary;
    public CommissionEmployee(decimal commission, decimal baseSalary)
    {
        this.commission = commission;
        this.baseSalary = baseSalary;
    }
    public override decimal GetPay()
    {
        return baseSalary + commission;
    }
}

class Program
{
    static void Main()
    {
        var lines = new List<string>();
        string line;
        while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            lines.Add(line);

        decimal total = 0;

        foreach (var s in lines)
        {
            var parts = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) continue;

            Employee emp = null;

            if (parts[0] == "H" && parts.Length == 3)
                emp = new HourlyEmployee(decimal.Parse(parts[1], CultureInfo.InvariantCulture),
                                          decimal.Parse(parts[2], CultureInfo.InvariantCulture));
            else if (parts[0] == "S" && parts.Length == 2)
                emp = new SalariedEmployee(decimal.Parse(parts[1], CultureInfo.InvariantCulture));
            else if (parts[0] == "C" && parts.Length == 3)
                emp = new CommissionEmployee(decimal.Parse(parts[1], CultureInfo.InvariantCulture),
                                              decimal.Parse(parts[2], CultureInfo.InvariantCulture));

            if (emp != null)
                total += emp.GetPay();
        }

        Console.WriteLine(Math.Round(total, 2, MidpointRounding.AwayFromZero));
    }
}