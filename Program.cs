namespace CRUDOperation_UsingSP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DBAccess obj_DBAccess = new DBAccess();

                Console.WriteLine("Enter the Operation Which you required to Perform");
                string? operation = Console.ReadLine();

                switch (operation)
                {
                    case "Insert":
                        InsertOperation(obj_DBAccess);
                        break;
                    case "Select":
                        SelectOperation(obj_DBAccess);
                        break;
                    case "Update":
                        UpdateOperation(obj_DBAccess);
                        break;
                    case "Delete":
                        DeleteOperation(obj_DBAccess);
                        break;
                    default:
                        Console.WriteLine("Invalid Operation");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        private static void InsertOperation(DBAccess obj_DBAccess)
        {
            Console.WriteLine("Enter FirstName");
            string? firstName = Console.ReadLine();

            Console.WriteLine("Enter LastName");
            string? lastName = Console.ReadLine();

            Console.WriteLine("Enter Salary");
            string? salary = Console.ReadLine();

            obj_DBAccess.InsertEmployee(firstName, lastName, double.Parse(salary));
            Console.WriteLine("Employee inserted successfully.");
        }

        private static void DeleteOperation(DBAccess obj_DBAccess)
        {
            Console.WriteLine("Enter Employee ID");
            string? employeeID = Console.ReadLine();

            obj_DBAccess.DeleteEmployee(Convert.ToInt32(employeeID));
            Console.WriteLine("Employee deleted successfully.");
        }

        private static void UpdateOperation(DBAccess obj_DBAccess)
        {
            Console.WriteLine("Enter Employee ID");
            string? employeeID = Console.ReadLine();

            Console.WriteLine("Enter FirstName");
            string? firstName = Console.ReadLine();

            Console.WriteLine("Enter LastName");
            string? lastName = Console.ReadLine();

            Console.WriteLine("Enter Salary");
            string? salary = Console.ReadLine();

            obj_DBAccess.UpdateEmployee(Convert.ToInt32(employeeID), firstName, lastName, double.Parse(salary));
            Console.WriteLine("Employee updated successfully.");
        }

        private static void SelectOperation(DBAccess obj_DBAccess)
        {
            Console.WriteLine("Enter Employee ID");
            string? employeeID = Console.ReadLine();

            obj_DBAccess.GetEmployee(Convert.ToInt32(employeeID));
            Console.WriteLine("Employee retrieved successfully.");
        }
    }

}