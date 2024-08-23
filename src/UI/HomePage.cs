namespace Opcion1LosCules;
using Spectre.Console;
    public class HomePage
    {

        private BookMenu _bookMenu;
        private PatronMenu _patronMenu;
        private PatronBorrowMenu _patronBorrowMenu;
        private Library _library;
        private BookSearchMenu _bookSearchMenu;
        private PatronSearchMenu _patronSearchMenu;
        private ReportMenu _reportMenu;

        public HomePage()
        {
            _library = new Library();
            _patronBorrowMenu = new PatronBorrowMenu(_library);
            _patronMenu = new PatronMenu(_library);
            _bookMenu = new BookMenu(_library);
            _bookSearchMenu = new BookSearchMenu(_library.booksManager());
            _patronSearchMenu = new PatronSearchMenu(_library.patronsManager());
            _reportMenu = new ReportMenu(_library.booksManager() , _library.patronsManager());
        }

        public void DisplayMenu()
        {
            AnsiConsole.Write(new FigletText("Library Management System")
                    .Centered()
                    .Color(Color.Green));

            while (true)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]Select an option:[/]")
                        .AddChoices(new[]
                        {
                            "Manage Books", "Manage Patrons", "Borrow Books",
                            "Return Books", "Search Books", "Search Patrons",
                            "Generate Reports", "Exit"
                        }));

                var panel = new Panel(option)
                {
                    Header = new PanelHeader("Election", Justify.Center),
                    Border = BoxBorder.Rounded,
                    Padding = new Padding(1, 1)
                };

                AnsiConsole.Write(panel);

                switch (option)
                {
                    case "Manage Books":
                        _bookMenu.ShowBookMenu();
                        break;
                    case "Manage Patrons":
                        _patronMenu.showPatronMenu();
                        break;
                    case "Borrow Books":
                        _patronBorrowMenu.BorrowBook();
                        break;
                    case "Return Books":
                        _patronBorrowMenu.ReturnBook();
                        break;
                    case "Search Books":
                        _bookSearchMenu.DisplaySearchMenu();
                        break;
                    case "Search Patrons":
                        _patronSearchMenu.DisplaySearchMenu();
                        break;
                    case "Generate Reports":
                        _reportMenu.DisplayReportMenu();
                        break;
                    case "Exit":
                        return;
                    default:
                        AnsiConsole.MarkupLine("[red]Invalid option. Please try again.[/]");
                        break;
                }
            }
        }
    }
