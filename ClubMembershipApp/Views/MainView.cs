using ClubMembershipApp.FieldValidators;

namespace ClubMembershipApp.Views;

public class MainView(IView loginView, IView registerView) : IView
{
    IView _registerView = registerView;
    IView _loginView = loginView;
    public IFieldValidator FieldValidator => null;

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
            // Console.Clear();
            Console.WriteLine("Good bye!!!");
        }

    }
    private void RunUserRegistrationView() {
        _registerView.RunView();
    }  
    private void RunUserLoginView() {
        _loginView.RunView();
    }  
}
  