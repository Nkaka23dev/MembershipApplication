namespace ClubMembershipApp;

public static class CommonOutputText
{
    static string MainHeading
    {
        get
        {
            string heading = "Cycling Club";
            return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
        }

    }
    public static string RegistrationHeading
    {
        get
        {
            string heading = "Register";
            return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
        }
    } 
    public static string LoginHeading
    {
        get
        {
            string heading = "Login";
            return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
        }
    }
    public static void WriteMainHeading()
    {

        Console.Clear();
        Console.WriteLine(MainHeading);
        Console.WriteLine();
        Console.WriteLine();

    }
    public static void WriteLoginHeading()
    {
        Console.WriteLine(LoginHeading);
        Console.WriteLine();
        Console.WriteLine();

    }
     
    public static void WriteRegistrationHeading()
    {
        Console.WriteLine(RegistrationHeading);
        Console.WriteLine();
        Console.WriteLine();

    }
}
