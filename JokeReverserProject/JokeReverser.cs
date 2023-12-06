namespace JokeReverserProject;

public static class JokeReverser
{
    private static readonly String OutputFilePath = "ReversedJokes.txt";
    
    
    private static string ReverseEachWord(string sentence)
    {
        Stack<char> stack = new Stack<char>();
        string reversedSentence = "";

        foreach (char ch in sentence)
        {
            if (ch == ' ' || ch == '.' || ch == ',' || ch == '!' || ch == '?')
            {
                while (stack.Count > 0)
                {
                    reversedSentence += stack.Pop();
                }

                reversedSentence += ch;
            }
            else
            {
                stack.Push(ch);
            }
        }

        while (stack.Count > 0)
        {
            reversedSentence += stack.Pop();
        }

        return reversedSentence;
    }

    public static void ReverseTheJoke(List<String> jokes)
    {
        foreach (String st in jokes)
        {
            AddToFile(ReverseEachWord(st)  + "\n");
        }
    }

    private static void AddToFile(string reversedWord)
    {
        File.AppendAllText(OutputFilePath, reversedWord);
    }
}