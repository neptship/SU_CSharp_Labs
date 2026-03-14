using System;

namespace Lab06;

public class StringLab
{
    private string str;

    public StringLab()
    {
        str = "";
    }

    public StringLab(string s)
    {
        str = s;
    }

    public string STR
    {
        get { return str; }
        set { str = value; }
    }
    
    public string CountSymbols()
    {
        int letters = 0;
        int symbols = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsLetter(str[i]))
            {
                letters++;
            }
            else if (!char.IsWhiteSpace(str[i]))
            {
                symbols++;
            }
        }

        return "Букв: " + letters + ", символов: " + symbols;
    }

    public double CountAverage()
    {
        string[] words = str.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
        
        if (words.Length == 0)
        {
            return 0;
        }

        int totalLength = 0;
        for (int i = 0; i < words.Length; i++)
        {
            totalLength += words[i].Length;
        }

        return (double)totalLength / words.Length;
    }

    public void ReplaceWord(string oldWord, string newWord)
    {
        string[] words = str.Split(' ');
        
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].ToLower() == oldWord.ToLower())
            {
                words[i] = newWord;
            }
        }

        str = string.Join(" ", words);
    }

    public int CountSubStr(string substring)
    {
        int count = 0;
        int index = 0;

        while ((index = str.IndexOf(substring, index)) != -1)
        {
            count++;
            index += substring.Length;
        }

        return count;
    }

    public bool CheckIsPalindrom()
    {
        string cleaned = "";
    
        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsLetter(str[i]))
            {
                cleaned += char.ToLower(str[i]);
            }
        }
    
        for (int i = 0; i < cleaned.Length / 2; i++)
        {
            if (cleaned[i] != cleaned[cleaned.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }

    public bool CheckIsDate()
    {
        string[] parts = str.Split('.');
        
        if (parts.Length != 3)
        {
            return false;
        }

        if (parts[0].Length != 2 || parts[1].Length != 2)
        {
            return false;
        }

        if (parts[2].Length != 2 && parts[2].Length != 4)
        {
            return false;
        }

        int day, month, year;
        
        if (!int.TryParse(parts[0], out day) || !int.TryParse(parts[1], out month) || !int.TryParse(parts[2], out year))
        {
            return false;
        }

        if (day < 1 || day > 31 || month < 1 || month > 12)
        {
            return false;
        }

        return true;
    }
}
