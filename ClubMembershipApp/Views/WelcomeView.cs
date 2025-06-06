using ClubMembershipApp.FieldValidators;
using ClubMembershipApp.Models;

namespace ClubMembershipApp.Views;

public class WelcomeView(User user) : IView
{
    User _user = user;
    public IFieldValidator FieldValidator => null;

    public void RunView()
    {
        CommonOutputFormat.ChangeColor(FontTheme.Success);
        Console.WriteLine($"Hello! {_user.FirstName}{_user.LastName}!!{Environment.NewLine}Welcome to the Cycling club");
        CommonOutputFormat.ChangeColor(FontTheme.Default);
        Console.ReadKey();
    } 
}
 