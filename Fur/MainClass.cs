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
        /// int age = Fur.InputHelpers.GetInputAndConvertInto&lt;int&gt;("Enter your age: ");
        /// </code>
        /// </example>
        public static T GetInputAndConvertInto<T>(string prompt, bool CanBeNull = false)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) && CanBeNull == false)
                {
                    Console.WriteLine($"[Error] Input cannot be null or whitespace.");
                    continue;
                }
                try
                {
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
