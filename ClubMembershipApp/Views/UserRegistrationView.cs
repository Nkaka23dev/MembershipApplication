using ClubMembershipApp.Data;
using ClubMembershipApp.FieldValidators;

namespace ClubMembershipApp.Views;

public class UserRegistrationView(IRegister register, IFieldValidator fieldValidator) : IView
{
    readonly IFieldValidator _fieldValidator = fieldValidator;
    public IRegister _register = register;

    public IFieldValidator FieldValidator { get => _fieldValidator; }

    public void RunView()
    {
        CommonOutputText.WriteMainHeading();
        CommonOutputText.WriteRegistrationHeading();
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.EmailAddress] = GetInputFromTheUser(FieldConstants.UserRegistrationFields.EmailAddress, "Please Enter your email address: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.FirstName] = GetInputFromTheUser(FieldConstants.UserRegistrationFields.FirstName, "Please Enter your firstname :");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.LastName] = GetInputFromTheUser(FieldConstants.UserRegistrationFields.LastName, "Please Enter your lastname: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.Password] = GetInputFromTheUser(FieldConstants.UserRegistrationFields.Password, $"Please Enter your password.{Environment.NewLine} Your password must contain atlease 1 small-case letter{Environment.NewLine}1 capital 1 digit 1 special character and lenght between 6-10 characters ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.PasswordCompare] = GetInputFromTheUser(FieldConstants.UserRegistrationFields.PasswordCompare, "Please re-enter your password: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.DateOfBirth] = GetInputFromTheUser(FieldConstants.UserRegistrationFields.DateOfBirth, "Please Enter your date of birth: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.AddressFirstLine] = GetInputFromTheUser(FieldConstants.UserRegistrationFields.AddressFirstLine, "Please Enter your first line address: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.AddressSecondLine] = GetInputFromTheUser(FieldConstants.UserRegistrationFields.AddressSecondLine, "Please your address second line: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.addressCity] = GetInputFromTheUser(FieldConstants.UserRegistrationFields.addressCity, "Please enter your city address: ");
        _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationFields.PostCode] = GetInputFromTheUser(FieldConstants.UserRegistrationFields.PostCode, "Please Enter you post code: ");
        
        RegisterUser();
    }
    private void RegisterUser()
    {
        _register.Register(_fieldValidator.FieldArray);
        CommonOutputFormat.ChangeColor(FontTheme.Success);
        Console.WriteLine("You have successfully registered. Please press any key to login");
        CommonOutputFormat.ChangeColor(FontTheme.Default);
        Console.ReadKey();
    }
    private string GetInputFromTheUser(FieldConstants.UserRegistrationFields field, string promptText)
    {
        string fieldVal;
        do
        {
            Console.Write(promptText);
            fieldVal = Console.ReadLine()!;
        } while (!FieldValid(field, fieldVal));
        return fieldVal;
    }
    private bool FieldValid(FieldConstants.UserRegistrationFields field, string fieldValue)
    {
        if (!_fieldValidator.ValidatorDel((int)field, fieldValue, _fieldValidator.FieldArray, out string invalidMessage))
        {
            CommonOutputFormat.ChangeColor(FontTheme.Danger);
            Console.WriteLine(invalidMessage);
            CommonOutputFormat.ChangeColor(FontTheme.Default);
            return false;
        }
        return true;
    }
}
