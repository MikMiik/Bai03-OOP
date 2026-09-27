namespace Bai03.Models;

public class ProjectTeam
{
    private string _projectCode = string.Empty;
    private string _projectName = string.Empty;
    public string ProjectCode
    {
        get => _projectCode;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            _projectCode = value;
        }
    }
    public string ProjectName
    {
        get => _projectName;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            _projectName = value;
        }
    }
    public Employee? Leader { get; private set; }
    public List<Employee> Members { get; } = new();
    public ProjectTeam(string projectCode, string projectName)
    {
        ProjectCode = projectCode;
        ProjectName = projectName;
        Leader = null;
        Console.WriteLine($"ProjectTeam created with Code: {projectCode}, Name: {projectName}, No leader assigned.");
    }
    public ProjectTeam(string projectCode, string projectName, Employee leader)
    {
        ArgumentNullException.ThrowIfNull(leader);
        ProjectCode = projectCode;
        ProjectName = projectName;
        Members.Add(leader);
        Leader = leader;
        Console.WriteLine($"ProjectTeam created with Code: {projectCode}, Name: {projectName}, Leader: {leader.FullName}.");
    }

    public bool AddMember(Employee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);
        if (Members.Contains(employee))
        {
            Console.WriteLine($"Employee {employee.FullName} is already a member of the team.");
            return false;
        }
        Members.Add(employee);
        Console.WriteLine($"Added employee {employee.FullName} to the team.");
        return true;
    }

    public bool AddMember(Employee employee, bool makeLeader)
    {
        ArgumentNullException.ThrowIfNull(employee);
        if (Members.Contains(employee))
        {
            Console.WriteLine($"Employee {employee.FullName} is already a member of the team.");
            return false;
        }
        Members.Add(employee);
        if (makeLeader)
        {
            Leader = employee;
            Console.WriteLine($"Employee {employee.FullName} has been added to the team and set as the leader.");
        }
        else
        {
            Console.WriteLine($"Employee {employee.FullName} has been added to the team.");
        }
        return true;
    }

    public void RemoveMember(string employeeId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(employeeId);
        var employee = Members.FirstOrDefault(m => m.Id == employeeId);
        if (employee == null)
        {
            Console.WriteLine($"Employee with ID {employeeId} is not a member of the team.");
            return;
        }
        if (Leader?.Id == employeeId)
        {
            Console.WriteLine($"Cannot remove employee {employee.FullName} - the leader of the team.");
            return;
        }
        Members.Remove(employee);
        Console.WriteLine($"Employee {employee.FullName} has been removed from the team.");
    }

    public void ChangeLeader(Employee employee)
    {
        if (!Members.Contains(employee))
        {
            Members.Add(employee);
            Console.WriteLine($"Employee {employee.FullName} added to team as new leader.");
        }
        Leader = employee;
        Console.WriteLine($"Employee {employee.FullName} is now the leader of the team.");
    }

    public bool Contains(string employeeId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(employeeId);
        bool result = Members.Any(m => m.Id == employeeId);
        Console.WriteLine($"Team contains employee with ID {employeeId}: {result}");
        return result;
    }
    public double CalculateTotalMonthlyCost()
    {
        double totalCost = Members.Sum(m => m.CalculateMonthlyCost());
        Console.WriteLine($"Total monthly cost for project {ProjectName} is: {totalCost:N0}");
        return totalCost;
    }
    public void DisplayTeam()
    {
        Console.WriteLine($"Project Code: {ProjectCode}");
        Console.WriteLine($"Project Name: {ProjectName}");
        Console.WriteLine($"Leader: {(Leader != null ? $"{Leader.FullName}" : "None")}");
        Console.WriteLine("Members:");
        foreach (var member in Members)
        {
            Console.Write("  - ");
            member.DisplayInfo();
        }
    }

    ~ProjectTeam()
    {
        Members.Clear();
        Leader = null;
        Console.WriteLine($"Destructor ProjectTeam {ProjectCode}, Name: {ProjectName}");
    }

}