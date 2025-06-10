
using ClubMembershipApp.Data;
using ClubMembershipApp.FieldValidators;
using ClubMembershipApp.Views;

namespace ClubMembershipApp;

public static class Factory
{
    public static IView GetMainViewObject()
    {
        ILogin login = new LoginUser();
        IRegister register = new RegisterUser();
        IFieldValidator userRegistrationValidator = new UserRegistrationSignature(register);
        userRegistrationValidator.InitialiseValidatorDelegates();

        IView registerView = new UserRegistrationView(register, userRegistrationValidator);
        IView loginView = new UserLoginView(login);
        IView mainView = new MainView(registerView, loginView);
        return mainView;
    }

}
