using ClubMembershipApp.FieldValidators;
using ClubMembershipApp.Models;

namespace ClubMembershipApp.Data; 

public class RegisterUser : IRegister
{
    public bool EmailExist(string emailAddress)
    {
        bool emailExists = false;

        using var dbContext = new ClubMembershipDbContext();
        emailExists = dbContext.Users.Any(u => u.Email!.ToLower().Trim() == emailAddress.ToUpper().Trim());
        return emailExists;
    }

    public bool Register(string[] fields)
    {
        using var dbContext = new ClubMembershipDbContext();
        User user = new()
        {
            Email = fields[(int)FieldConstants.UserRegistrationFields.EmailAddress],
            FirstName = fields[(int)FieldConstants.UserRegistrationFields.FirstName],
            LastName = fields[(int)FieldConstants.UserRegistrationFields.LastName],
            Password = fields[(int)FieldConstants.UserRegistrationFields.Password],
            DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationFields.DateOfBirth]),
            PhoneNumber = fields[(int)FieldConstants.UserRegistrationFields.PhoneNumber],
            AddressFirstLine = fields[(int)FieldConstants.UserRegistrationFields.AddressFirstLine],
            AddressSecondLine = fields[(int)FieldConstants.UserRegistrationFields.AddressSecondLine],
            PostCode = fields[(int)FieldConstants.UserRegistrationFields.PostCode],
        };
        dbContext.Users.Add(user);
        dbContext.SaveChanges();
        return true;
    }
}
   