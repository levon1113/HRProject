
namespace HRProject
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            Departments.LoadFromFile();
            Blocknot.LoadFromFile();

            bool f = true;
            int dep;
            string name, phone;

            while (f)
            {
                Helper.ShowMenu();                
                MenuItems choice = 0;
                choice = (MenuItems)Helper.CheckedInput(Enum.GetValues<MenuItems>().Length);
                Console.WriteLine();
                
                switch (choice)
                {
                    case MenuItems.AddAnEmployee:
                        Console.Write("Input name -> ");
                        name = Helper.CheckedInput();

                        Console.Write("Input phone -> ");
                        phone = Helper.CheckedInput();
                   
                        if (Departments.Count()!=0)
                        {
                            Departments.ShowAll();
                            Console.Write("Choose department -> ");
                            dep = Helper.CheckedInput(Departments.Count());

                            try
                            {
                                Blocknot.Add(new Employee(name, phone, dep - 1));
                                Blocknot.SaveToFile();
                                Console.WriteLine("Successfully added");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("There is already an employee with this name");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no departments");
                        }
                        
                        Helper.Next();
                        break;

                    case MenuItems.RemoveAnEmployee:
                        Console.Write("Input name -> ");
                        name = Helper.CheckedInput();

                        try
                        {
                            Blocknot.Remove(Blocknot.FindEmployee(name));
                            Blocknot.SaveToFile();
                            Console.WriteLine("Successfully removed");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("There are no employees with this name");
                        }
                        
                        Helper.Next();
                        break;

                    case MenuItems.FindAnEmployee:
                        Console.Write("Input name -> ");
                        name = Helper.CheckedInput();

                        if (Blocknot.Contains(name))
                        {
                            Console.WriteLine($"Employee finded -> {Blocknot.FindEmployee(name)}");
                        }
                        else
                        {
                            Console.WriteLine("There are no employees with this name");
                        }
                        Helper.Next();
                        break;

                    case MenuItems.ShowAllEmployees:
                        Blocknot.ShowAll();
                        Helper.Next();
                        break;

                    case MenuItems.ShowAllDepartments:
                        Departments.ShowAll();
                        Helper.Next();
                        break;

                    case MenuItems.AddADepartment:
                        Console.Write("Input name -> ");
                        try
                        {
                            name = Helper.CheckedInput();
                            Departments.Add(name);
                            Departments.SaveToFile();
                            Console.WriteLine("Successfully added");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("There is already a department with this name");
                        }
                        
                        Helper.Next();
                        break;

                    case MenuItems.RemoveADepartment:
                        Departments.ShowAll();
                        Console.Write("Choose department -> ");

                        dep = Helper.CheckedInput(Departments.Count());
                        Departments.Remove(dep);
                        Departments.SaveToFile();

                        Console.WriteLine("Successfully removed");
                        Helper.Next();

                        break;

                    case MenuItems.ShowByDepartment:
                        Departments.ShowAll();
                        Console.Write("Choose department -> ");
                        dep = Helper.CheckedInput(Departments.Count());

                        if (Blocknot.ShowByDepartment(dep).ToList<Employee>().Count !=0)
                        {
                            foreach (Employee item in Blocknot.ShowByDepartment(dep))
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no users from this departmenr");
                        }

                        Helper.Next();
                        break;

                    case MenuItems.Exit:
                        f=false; 
                        break;

                    default:
                        break;
                }
            }
        }
    }
}