using static Libraries.GetValidateLog;
using static Libraries.Funnies;
using static Libraries.TaskSpecific;
using static Libraries.ListActions;

namespace EnigmaMachine
{
    class Program
    {
        private static string Cipher(string message, int shift, byte task)
        {
            char[] text = message.ToCharArray();
            switch (task)
            {
                case 1:
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (char.IsLetter(text[i]))
                        {
                            char baseChar = char.IsUpper(text[i]) ? 'A' : 'a';
                            text[i] = (char)(((text[i] - baseChar + shift) % 26 + 26) % 26 + baseChar);
                        }
                    }

                    break;

                case 2:
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (char.IsLetter(text[i]))
                        {
                            char baseChar = char.IsUpper(text[i]) ? 'A' : 'a';
                            text[i] = (char)(((text[i] - baseChar - shift) % 26 + 26) % 26 + baseChar);
                        }
                    }

                    break;

                default:
                    throw new ApplicationException("No such task index");
            }

            return new string(text);
        }

        private static string Sequence(string message, byte task)
        {
            string text = "";
            switch (task)
            {
                case 1:
                    for (byte i = 1; i < 4; i++)
                    {
                        text = Cipher(message, i * 2 + 4, 1);
                    }

                    break;

                case 2:
                    for (byte i = 1; i < 4; i++)
                    {
                        text = Cipher(message, i * 2 + 4, 2);
                    }

                    break;
            }


            return text;
        }

        static void Main(string[] args)
        {
            LogLine("Enigma Machine v 0.1 is running.\n");
            byte choice = Convert.ToByte(Ask("Choose what you want to do:\n1. Encrypt\n2. Decrypt"));
            

            switch (choice)
            {
                case 1:
                    string text1 = Ask("Enter the text you need to encode: ");
                    string encoded = Sequence(text1, 1);
                    LogLine($"Your message: {encoded}");
                    break;

                case 2:
                    string text2 = Ask("Enter the text you need to encode: ");
                    string decoded = Sequence(text2, 2);
                    LogLine($"Your message: {decoded}");
                    break;
                
                default:
                    throw new ApplicationException("No such choice");
            }
        }
    }
}