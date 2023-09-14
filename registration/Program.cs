public class WrongLoginException : Exception
{
    public WrongLoginException() { }
    public WrongLoginException(string message) : base(message) { }
}

public class WrongPasswordException : Exception
{
    public WrongPasswordException() { }
    public WrongPasswordException(string message) : base(message) { }
}

public class Reg
{
    public static bool RegUser(string login, string password, string confirmPassword)
    {
        try
        {
            if (login.Length >= 20 || !NumAndSim(login))
            {
                throw new WrongLoginException("неподходящий формат логина");
            }

            if (password.Length >= 20 || !NumAndSim(password) || password != confirmPassword)
            {
                throw new WrongPasswordException("непоходящий формат пароля/пароли не совпадают");
            }

            return true;
        }
        catch (WrongLoginException ex)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"ошибка: {ex.Message}");
            return false;
        }
        catch (WrongPasswordException ex)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"ошибка: {ex.Message}");
            return false;
        }
    }

    private static bool NumAndSim(string str)
    {
        foreach (char c in str)
        {
            if (!char.IsLetterOrDigit(c) && c != '_')
            {
                return false;
            }
        }
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string login = "ooo";
        string password = "111";
        string confirmPassword = "112";

        if (Reg.RegUser(login, password, confirmPassword))
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("регистрация завершена");
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("регистрация не удалась");
        }
    }
}