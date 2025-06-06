using ClubMembershipApp.Data;
using ClubMembershipApp.FieldValidators;
using ClubMembershipApp.Models;

namespace ClubMembershipApp.Views;

public class UserLogin(ILogin login) : IView
{
    readonly ILogin _loginUser = login;
    public IFieldValidator? FieldValidator => null;

    public void RunView()
    {
        CommonOutputText.WriteMainHeading();
        CommonOutputText.WriteLoginHeading();
        Console.WriteLine("Please enter you email address: ");
        string emailAddress = Console.ReadLine()!;
        Console.WriteLine("Please enter you Password: ");
        string password = Console.ReadLine()!;

        User user = _loginUser.Login(emailAddress, password);
        if (user != null)
        {
            WelcomeView welcomeView = new(user);
            welcomeView.RunView();

        }
        else
        {
            // Console.Clear();
            CommonOutputFormat.ChangeColor(FontTheme.Danger);
            Console.WriteLine("The credentials you entered are invalid!");
            CommonOutputFormat.ChangeColor(FontTheme.Default);
            Console.ReadKey();
        }
         
    }
}
   