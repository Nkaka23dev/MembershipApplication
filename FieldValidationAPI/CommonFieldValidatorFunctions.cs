using System.Text.RegularExpressions;

namespace FieldValidationAPI
{

    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string dateTime, out DateTime validDateTime);
    public delegate bool PatternMatchValidDel(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);

    public class CommonFieldValidatorFunctions
    {
        private static RequiredValidDel? _requiredValidatorDel = null;
        private static StringLengthValidDel? _stringValidatorDel = null;
        private static DateValidDel? _dateValidatorDel = null;
        private static PatternMatchValidDel? _patternMatchValidDel = null;
        private static CompareFieldsValidDel? _compareFieldsValidDel = null;

        /// <summary>
        /// Delagate Assignement
        /// </summary>
        public static RequiredValidDel RequiredFieldValidDel
        {
            get
            {
                _requiredValidatorDel ??= new RequiredValidDel(RequiredFieldValid);
                return _requiredValidatorDel;
            }
        }

        public static StringLengthValidDel StringFieldLengthValidDel
        {
            get
            {
                _stringValidatorDel ??= new StringLengthValidDel(StringLenghtFieldValid);
                return _stringValidatorDel;
            }
        }
        public static DateValidDel DateValidDel
        {
            get
            {
                _dateValidatorDel ??= new DateValidDel(DateFieldValid);
                return _dateValidatorDel;
            }
        }
        public static PatternMatchValidDel PatternFieldMatchDel
        {
            get
            {
                _patternMatchValidDel ??= new PatternMatchValidDel(FieldPatternValid);
                return _patternMatchValidDel;
            }
        }
        /// <summary>
        /// Easy to understan
        /// </summary>
        // public static CompareFieldsValidDel CompareFieldsValidDel
        // {
        //     get
        //     {
        //         _compareFieldsValidDel ??= FieldComparisonValid;
        //         return _compareFieldsValidDel;
        //     }
        // }

        public static CompareFieldsValidDel CompareFieldsValidDel
        {
            get
            {
                _compareFieldsValidDel ??= new CompareFieldsValidDel(FieldComparisonValid);
                return _compareFieldsValidDel;
            }
        }

        /// <summary> 
        /// Methods that will be assigned to Delates
        /// </summary>
        /// <param name="Methods"></param>
        /// <returns></returns>
        private static bool RequiredFieldValid(string fieldVal)
        {
            if (!string.IsNullOrEmpty(fieldVal))
                return true;
            return false;
        }
        private static bool StringLenghtFieldValid(string fieldVal, int min, int max)
        {
            if (fieldVal.Length >= min && fieldVal.Length <= max)
                return true;
            return false;
        }
        private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
        {
            if (DateTime.TryParse(dateTime, out validDateTime))
                return true;
            return false;
        }
        private static bool FieldPatternValid(string fieldVal, string regularExpressionPattern)
        {
            Regex regex = new Regex(regularExpressionPattern);
            if (regex.IsMatch(fieldVal))
                return true;
            return false;

        }
        private static bool FieldComparisonValid(string fieldVal1, string fieldVal2)
        {
            if (fieldVal1.Equals(fieldVal2))
                return true;
            return false;

        }
    }
}