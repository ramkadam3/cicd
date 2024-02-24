using System;

namespace Yrefy_AutomationProject.Utility
{
  public static class Extensions
  {
    public static string FormatAsPhoneNumber(this string phoneNumber)
    {
      if (phoneNumber.Length == 10)
      {
        return $"({phoneNumber.Substring(0, 3)}) {phoneNumber.Substring(3, 3)}-{phoneNumber.Substring(6)}";
      }
      else
      {
        // Handle invalid phone number length
        return "Invalid phone number";
      }
    }
    public static void MergeDictionaries<TKey, TValue>(this IDictionary<TKey, TValue> destination, IDictionary<TKey, TValue> source)
    {
      foreach (var kvp in source)
      {
        destination[kvp.Key] = kvp.Value;
      }
    }

    public static string RemoveCurrencyFormat(this string input)
    {
      // Remove "$" and ","
      string cleanedString = input.Replace("$", "").Replace(",", "");

      // Find the index of the decimal point (.)
      int decimalIndex = cleanedString.IndexOf('.');

      // If there is a decimal point, truncate the string to remove digits after it
      if (decimalIndex != -1)
      {
        cleanedString = cleanedString.Substring(0, decimalIndex + 3);
      }
      cleanedString = (Math.Floor(double.Parse(cleanedString))).ToString();
      return cleanedString;
    }

    public static string ChangeEmailDomain(this string email, string newDomain)
    {
      try
      {
        // Parse the email address using MailAddress class
        System.Net.Mail.MailAddress mailAddress = new System.Net.Mail.MailAddress(email);

        // Create a new MailAddress with the same user and the new domain
        System.Net.Mail.MailAddress newMailAddress = new System.Net.Mail.MailAddress(mailAddress.User + "@" + newDomain);

        // Return the modified email address
        return newMailAddress.Address;
      }
      catch (FormatException)
      {
        // Handle the case where the original email is not a valid email address
        Console.WriteLine("Invalid email address format");
        return email;
      }
    }

    public static string RemoveFractionIfWhole(this string numberString)
    {
      // Parse the string to double
      if (double.TryParse(numberString, out double number))
      {
        // Check if the number is a whole number
        if (number % 1 == 0)
        {
          // Convert it to integer and get the string representation
          return ((int)number).ToString();
        }
      }

      // Return the original string if parsing fails or number is not whole
      return numberString;
    }
  }
}
