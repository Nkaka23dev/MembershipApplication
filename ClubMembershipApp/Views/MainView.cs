using ClubMembershipApp.FieldValidators;

namespace ClubMembershipApp.Views;

public class MainView: IView
{
    public IFieldValidator FieldValidator => null;
    IView _registerView = null;
    IView _loginView = null;
    public MainView(IView registerView, IView loginView)
    {
        _registerView = registerView;
        _loginView = loginView;
    }
    public void RunView()
    {
        CommonOutputText.WriteMainHeading();
        Console.WriteLine("Please press 'l' to login or 'r' to register if not registered yet");
        ConsoleKey key = Console.ReadKey().Key;
        if (key == ConsoleKey.R)
        {
            RunUserRegistrationView();
            RunUserLoginView();
        }
        else if (key == ConsoleKey.L)
        {
           RunUserLoginView();
        }
        else
        {

            Console.Clear();
            Console.WriteLine("I am doing nothing..");
            Console.WriteLine("Good bye!!!");
        }

    }
    private void RunUserRegistrationView()
    {
         Console.WriteLine("REGISTERING USER....................ION");
        _registerView.RunView();
    }
    private void RunUserLoginView()
    {
        _loginView.RunView();
    }
}
