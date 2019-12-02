using EntityFrameworkCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkCodeFirst
{
    public static class EmployeeRepository
    {
        public static List<Department> GetDepartments()
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            return employeeDBContext.Departments.ToList();
        }

        public static List<Employee> GetEmployees()
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            return employeeDBContext.Employees.ToList();
        }

        public static Employee GetEmployee(int Id)
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            return employeeDBContext.Employees.FirstOrDefault(x => x.Id == Id);
        }

        public static bool CreateEmployee(Employee employee)
        {
            try
            {
                EmployeeDBContext employeeDBContext = new EmployeeDBContext();
                employeeDBContext.Employees.Add(employee);
                employeeDBContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool UpdateEmployee(Employee employee)
        {
            try
            {
                EmployeeDBContext employeeDBContext = new EmployeeDBContext();
                var employeeToUpdate = employeeDBContext.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
                if (employeeToUpdate != null)
                {
                    employeeToUpdate.FirstName = employee.FirstName;
                    employeeToUpdate.LastName = employee.LastName;
                    employeeToUpdate.Gender = employee.Gender;
                    employeeToUpdate.Department = employee.Department;
                    employeeToUpdate.Salary = employee.Salary;
                }
                employeeDBContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeleteEmployee(int Id)
        {
            try
            {
                EmployeeDBContext employeeDBContext = new EmployeeDBContext();
                var employeeToDelete = employeeDBContext.Employees.FirstOrDefault(x => x.Id == Id);
                employeeDBContext.Employees.Remove(employeeToDelete);
                employeeDBContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}