using static Libraries.GetValidateLog;
using static Libraries.Funnies;
using static Libraries.TaskSpecific;
using static Libraries.ListActions;
using static Libraries.EnigmaMachine;

namespace EnigmaMachine
{
    class Program
    {
        private static void Main()
        {
            LogLine("Enigma Machine v 0.2 is running.\n");
            byte choice = Convert.ToByte(Ask("Choose what you want to do:\n1. Encrypt\n2. Decrypt\n0. Exit"));
            byte key;
            
            switch (choice)
            {
                case 1:
                    string text1 = Ask("Enter the text you need to encode: ");
                    key = Convert.ToByte(Ask("Enter key for encrypting: "));
                    string encoded = Sequence(text1, 1, key);
                    LogLine("Your message: " + encoded);
                    RepeatFunctionBlock("Back to menu? (Y)");
                    break;

                case 2:
                    string text2 = Ask("Enter the text you need to encode: ");
                    key = Convert.ToByte(Ask("Enter key for decrypting: "));
                    string decoded = Sequence(text2, 2, key);
                    LogLine($"Decrypted text: {decoded}");
                    RepeatFunctionBlock("Back to menu? (Y)");
                    break;
                
                case 0: 
                    break;
                
                default:
                    throw new ApplicationException("No such choice");
            }

             Log("Closing");
            for (int i = 0; i < 3; i++)
            {
                Log(".");
                Thread.Sleep(500);
            }
            SaveLog(0);
        }
    }
}