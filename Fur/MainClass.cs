namespace Fur
{
    public class InputHelpers
    {
        /// Displays a prompt, reads console input, and attempts to convert it to type T.
        /// Retries until valid input is given.
        /// Usage example:
        /// int age = InputHelper.GetInput<int>("Enter your age: ");
        public static T GetInput<T>(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                try
                {
                    // Convert the input string to the generic type T
                    return (T)Convert.ChangeType(input, typeof(T));
                }
                catch (FormatException)
                {
                    Console.WriteLine($"[Error] Invalid format. Expected type: {typeof(T).Name}. Please try again.");
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine($"[Error] Conversion to {typeof(T).Name} is not supported.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error] {ex.Message}.");
                }
            }
        }
    }
}
