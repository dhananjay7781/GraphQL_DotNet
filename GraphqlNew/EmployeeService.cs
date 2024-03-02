public interface IEmployeeService
{
    public List<EmployeeDetails> GetEmployees();

    public List<EmployeeDetails> GetEmployee(int empId);

    public List<EmployeeDetails> GetEmployeesByDepartment(int deptId);
}

public class EmployeeService : IEmployeeService
{
    public EmployeeService(){}
    private List<Employee> employees = new List<Employee>
        {
            new Employee(1, "Tom", 25, 1),
            new Employee(2, "Henry", 28, 1),
            new Employee(3, "Steve", 30, 2),
            new Employee(4, "Ben", 26, 2),
            new Employee(5, "John", 35, 3),

        };
        private List<Department> departments = new List<Department>
        {
            new Department(1, "IT"),
            new Department(2, "Finance"),
            new Department(3, "HR"),
        };

    public List<EmployeeDetails> GetEmployees()
    {
        return employees.Select(emp => new EmployeeDetails
        {
            Id = emp.Id,
            Name = emp.Name,
            Age = emp.Age,
            DeptName = departments.First(d => d.Id == emp.DeptId).Name,
        }).ToList();

    }
    public List<EmployeeDetails> GetEmployee(int empId)
    {
        return employees.Where(emp => emp.Id == empId).Select(emp => new EmployeeDetails
        {
            Id = emp.Id,
            Name = emp.Name,
            Age = emp.Age,
            DeptName = departments.First(d => d.Id == emp.DeptId).Name,
        }).ToList();
    }

    public List<EmployeeDetails> GetEmployeesByDepartment(int deptId)
    {
        return employees.Where(emp => emp.DeptId == deptId).Select(emp => new EmployeeDetails
        {
            Id = emp.Id,
            Name = emp.Name,
            Age = emp.Age,
            DeptName = departments.First(d => d.Id == deptId).Name,
        }).ToList();
    }
}