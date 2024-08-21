namespace Opcion1LosCules;
public class PatronMenu 
{
    private PatronSearchMenu _patronSearchMenu;
    private PatronsManagementMenu _patronsManagement;
    private Library _library;
    
    public PatronMenu(Library library) 
    {
        _library = library;
        _patronsManagement = new PatronsManagementMenu(_library);
    }

    public void showPatronMenu()
    {
         while (true)
            {
                Console.WriteLine("Patron Menu");
                Console.WriteLine("1. Add Patron");
                Console.WriteLine("2. Update Patron");
                Console.WriteLine("3. Remove Patron");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        _patronsManagement.AddPatron();
                        break;
                    case "2":
                        _patronsManagement.UpdatePatron();
                        break;
                    case "3":
                        _patronsManagement.RemovePatron();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
    }
}