namespace Libraries;

public class EnigmaMachine
{
    public static string Cipher(string message, int shift, byte task)
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
    
    public static string Sequence(string message, byte task, byte shift)
    {
        string text = "";
        switch (task)
        {
            case 1:
                for (byte i = 1; i < 4; i++)
                {
                    text = Cipher(message, shift * 2 + 4, 1);
                }

                break;

            case 2:
                for (byte i = 1; i < 4; i++)
                {
                    text = Cipher(message, shift * 2 + 4, 2);
                }

                break;
        }


        return text;
    }
}