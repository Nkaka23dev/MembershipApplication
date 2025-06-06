using ClubMembershipApp.Data;
using FieldValidationAPI;

namespace ClubMembershipApp.FieldValidators;

public class UserRegistrationSignature : IFieldValidator
{
    const int FirstName_Min_Length = 2;
    const int FirstName_Max_Length = 100;
    const int LastName_Min_Length = 2;
    const int LastName_Max_Length = 100;

    delegate bool EmailExistDel(string emailAddress);
    FieldValidatorDel _fieldValidatorDel = null;
    RequiredValidDel _requiredValidDel = null;
    StringLengthValidDel _stringLengthValidDel = null;
    DateValidDel _dateValidDel = null;
    PatternMatchValidDel _patternMatchValidDel = null;
    CompareFieldsValidDel _compareFieldsValidDel = null;
    EmailExistDel _emailExistdel = null;

    /// <summary>
    /// Property to store valid field
    /// </summary>
    string[] _fieldArray = null;
    IRegister _register = null;

    public string[] FieldArray
    {
        get
        {
            _fieldArray ??= new string[Enum.GetValues<FieldConstants.UserRegistrationFields>().Length];
            return _fieldArray;
        }
    }

    public FieldValidatorDel ValidatorDel => _fieldValidatorDel;
    public UserRegistrationSignature(IRegister register)
    {
        _register = register; 
    }
    public void InitialiseValidatorDelegates()
    {
        _fieldValidatorDel = new FieldValidatorDel(ValidField);
        _emailExistdel = new EmailExistDel(_register.EmailExist);
        _requiredValidDel = CommonFieldValidatorFunctions.RequiredFieldValidDel;
        _stringLengthValidDel = CommonFieldValidatorFunctions.StringFieldLengthValidDel;
        _dateValidDel = CommonFieldValidatorFunctions.DateValidDel;
        _patternMatchValidDel = CommonFieldValidatorFunctions.PatternFieldMatchDel;
        _compareFieldsValidDel = CommonFieldValidatorFunctions.CompareFieldsValidDel;
    }
    private bool ValidField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
    {
        fieldInvalidMessage = "";
        FieldConstants.UserRegistrationFields userRegistrationField = (FieldConstants.UserRegistrationFields)fieldIndex;
        switch (userRegistrationField)
        {
            case FieldConstants.UserRegistrationFields.EmailAddress:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for the field: {Enum.GetName(userRegistrationField)}{Environment.NewLine}" : "";
                fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionsPattern.Email_Address_RegEx_Pattern)) ? $"You must enter a valid email address{Environment.NewLine}" : fieldInvalidMessage;
                fieldInvalidMessage = (fieldInvalidMessage == "" && _emailExistdel(fieldValue)) ? $"The email already exist. Please try again{Environment.NewLine}" : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationFields.FirstName:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for the field: {Enum.GetName(userRegistrationField)}{Environment.NewLine}" : "";
                fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLengthValidDel(fieldValue, FirstName_Min_Length, FirstName_Max_Length)) ? $"The length for the field {Enum.GetName(userRegistrationField)} must be between {FirstName_Min_Length} and {FirstName_Max_Length}{Environment.NewLine}" : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationFields.LastName:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for the field: {Enum.GetName(userRegistrationField)}{Environment.NewLine}" : "";
                fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLengthValidDel(fieldValue, LastName_Min_Length, LastName_Max_Length)) ? $"The length for the field {Enum.GetName(userRegistrationField)} must be between {LastName_Min_Length} and {LastName_Max_Length}{Environment.NewLine}" : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationFields.Password:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for the field: {Enum.GetName(userRegistrationField)}{Environment.NewLine}" : "";
                fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionsPattern.Strong_Password_RegEx_Pattern)) ? $"Your password must be at least 1 small case letter, 1 special character and the length should be between 6-10 characters{Environment.NewLine}" : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationFields.PasswordCompare:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for the field: {Enum.GetName(userRegistrationField)}{Environment.NewLine}" : "";
                fieldInvalidMessage = (fieldInvalidMessage == "" && !_compareFieldsValidDel(fieldValue, fieldArray[(int)FieldConstants.UserRegistrationFields.Password])) ? $"Your entry did  match your password {Environment.NewLine}" : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationFields.DateOfBirth:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for the field: {Enum.GetName(userRegistrationField)}{Environment.NewLine}" : "";
                fieldInvalidMessage = (fieldInvalidMessage == "" && !_dateValidDel(fieldValue, out DateTime validDateTime)) ? $"You did not enter a valid date {Environment.NewLine}" : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationFields.PhoneNumber:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for the field: {Enum.GetName(userRegistrationField)}{Environment.NewLine}" : "";
                fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionsPattern.Rwanda_PhoneNumber_RegEx_Pattern)) ? $"You did not entser a valid Rwanda phone{Environment.NewLine}" : fieldInvalidMessage;
                break;
            case FieldConstants.UserRegistrationFields.AddressFirstLine:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for the field: {Enum.GetName(userRegistrationField)}{Environment.NewLine}" : "";
                break;
            case FieldConstants.UserRegistrationFields.AddressSecondLine:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for the field: {Enum.GetName(userRegistrationField)}{Environment.NewLine}" : "";
                break;
            case FieldConstants.UserRegistrationFields.addressCity:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for the field: {Enum.GetName(userRegistrationField)}{Environment.NewLine}" : "";
                break;
            case FieldConstants.UserRegistrationFields.PostCode:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for the field: {Enum.GetName(userRegistrationField)}{Environment.NewLine}" : "";
                fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionsPattern.Rwanda_Post_Code_RegEx_Pattern)) ? $"You did not a Rwanda valid Post code": fieldInvalidMessage;
                break;
            default:
                throw new ArgumentException("This field does not exist!");
        } 
        return fieldInvalidMessage == "";
    }
} 
