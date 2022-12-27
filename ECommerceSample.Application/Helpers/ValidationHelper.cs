using System.Text.RegularExpressions;

namespace ECommerceSample.Application.Helpers;

public class ValidationHelper
{
    public static bool CheckEmailValidation(string email)
    {
        var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        return regex.IsMatch(email);
    }

    public static bool CheckPhoneNumberValidation(string phoneNumber)
    {
        var regex = new Regex(@"^[5]{1}[0-9]{9}$");
        return regex.IsMatch(phoneNumber);
    }

    public static bool CheckPasswordValidation(string password)
    {
        var regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[#?!@$%^&*-]).{9,}$");
        return regex.IsMatch(password);
    }
}