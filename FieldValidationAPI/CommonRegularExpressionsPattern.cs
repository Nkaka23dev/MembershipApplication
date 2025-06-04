namespace FieldValidationAPI;

public class CommonRegularExpressionsPattern
{


    public const string Email_Address_RegEx_Pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

    /// <summary>
    /// Matches Rwandan phone numbers in either local or international format:
    ///  • Local: 07X XXX XXX (where X are digits)
    ///  • International: +250 7X XXX XXX
    ///  • Also covers landlines starting with 25X XXX XXX
    ///  • Optional extension (e.g. “ext 123” or “#123”)
    /// </summary>
    public const string Rwanda_PhoneNumber_RegEx_Pattern =
        @"^(?:\+250|0)(?:7\d{2}|25\d)[\s-]?\d{3}[\s-]?\d{3}(?:(?:[\s-]?(?:x|ext\.?\s?|\#)\d+)?)$";

    /// <summary>
    /// Rwanda does not use postal‐code numbers. If you need to accept only blank (no postal code),
    /// use a pattern that only matches the empty string. If you prefer to allow a P.O. Box (“B.P. 1234”),
    /// you can use the commented‐out variant instead.
    /// </summary>
    // Matches only an empty string (i.e. no postal code)
    public const string Rwanda_Post_Code_RegEx_Pattern = @"^$";

    /// If you want to allow a B.P. box (e.g. “B.P. 3425”) instead of “no code”, uncomment this:
    /// public const string Rwanda_Post_Code_RegEx_Pattern = @"^B\.P\.\s?\d+$";

    public const string Strong_Password_RegEx_Pattern = @"(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$";
}

