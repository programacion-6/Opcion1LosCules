using System;

namespace Opcion1LosCules;

public class Program 
{
    static void Main(string[] arg) 
    {
        Library library = new Library();
        HomePage homePage = new HomePage(library);
        homePage.DisplayMenu();
    }
}