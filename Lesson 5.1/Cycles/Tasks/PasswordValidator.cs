namespace Cycles.Tasks
{
    public class PasswordValidator
    {
        public static void Run()
        {
        start:
            System.Console.WriteLine("Enter your password: ");
            string password = System.Console.ReadLine();

            if (password == null)
            {
                System.Console.WriteLine("Password cannot be null. Try again.");
                goto start;
            }

            if (password.Length < 8)
            {
                System.Console.WriteLine("Password must be at least 8 characters long. Try again.");
                goto start;
            }

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;
            string specialChars = "!@#$%^&*()-_=+[]{}|;:'\",.<>?/`~";

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (specialChars.Contains(c)) hasSpecial = true;
            }

            if (!hasUpper)
            {
                System.Console.WriteLine("Password must contain at least one uppercase letter. Try again.");
                goto start;
            }

            if (!hasLower)
            {
                System.Console.WriteLine("Password must contain at least one lowercase letter. Try again.");
                goto start;
            }

            if (!hasDigit)
            {
                System.Console.WriteLine("Password must contain at least one digit. Try again.");
                goto start;
            }

            if (!hasSpecial)
            {
                System.Console.WriteLine("Password must contain at least one special character. Try again.");
                goto start;
            }

        end:
            System.Console.WriteLine("Password is valid.");
        }
    }
}
