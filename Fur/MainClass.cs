namespace Fur
{
    public class InputHelpers
    {
        /// <summary>
        /// Displays a prompt, reads console input, and attempts to convert it to type <typeparamref name="T"/>.
        /// Retries until valid input is given.
        /// </summary>
        /// <typeparam name="T">The target type to convert the user input into (e.g., int, double, bool).</typeparam>
        /// <param name="prompt">The message displayed to the user before reading input.</param>
        /// <returns>The user's input safely converted to type <typeparamref name="T"/>.</returns>
        /// <example>
        /// <code>
        /// int age = InputHelpers.GetInput&lt;int&gt;("Enter your age: ");
        /// </code>
        /// </example>
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
