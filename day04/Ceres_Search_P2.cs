using System;

class Ceres_Search_P2{

    static bool IndexesValidator(int charIter, int lineIter, string[] lines)
    {
        if (lineIter < 0 || lineIter >= lines.Length)
            return false;
        else if (charIter < 0 || charIter >= lines[lineIter].Length)
            return false;
        return true;
    }

    static bool Syntax_checker_validator(int charIter, int lineIter, string[] lines, int flag)
    {
        string word = "MAS";
        int index = 0;
        charIter += 2 * flag;
        if (!IndexesValidator(charIter, lineIter, lines))
            return false;
        if (lines[lineIter][charIter] == 'S')
            word = "SAM";
        while (index < 3)
        {
            if (!IndexesValidator(charIter, lineIter, lines) || lines[lineIter][charIter] != word[index])
                return false;
            lineIter -= 1;
            charIter += flag * -1;
            index++;
        }
        return true;
    }

    static int Syntax_checker(int charIter, int lineIter, string[] lines)
    {
        int initiaLineIndex = lineIter;
        int initiaCharIndex = charIter;
        string word = "MAS";
        if (lines[lineIter][charIter] == 'S')
            word = "SAM";
        int index = 0;
        while (index < word.Length)
        {
            if (!IndexesValidator(charIter, lineIter, lines) || word[index] != lines[lineIter][charIter])
                break;
            index++;
            if (index == word.Length && Syntax_checker_validator(charIter, lineIter, lines, -1))
                return 1;
            charIter++;
            lineIter++;
        }
        charIter = initiaCharIndex;
        lineIter = initiaLineIndex;
        index = 0;
        while (index < word.Length)
        {
            if (!IndexesValidator(charIter, lineIter, lines) || word[index] != lines[lineIter][charIter])
                break;
            charIter--;
            lineIter++;
            index++;
            if (index == word.Length && Syntax_checker_validator(charIter, lineIter, lines, 1))
                return 1;
        }
        return 0;
    }

    static int Main()
    {
        int charIter;
        int lineIter = 0;
        int result = 0;
        string fileName = "input.txt";
        if (!File.Exists(fileName))
            return 1;
        string[] lines = File.ReadAllLines(fileName);
        while (lineIter < lines.Length)
        {
            charIter = 0;
            while (charIter < lines[lineIter].Length)
            {
                if (lines[lineIter][charIter] == 'M' || lines[lineIter][charIter] == 'S')
                    result += Syntax_checker(charIter, lineIter, lines);
                charIter++;
            }
            lineIter++;
        }
        Console.WriteLine(result);
        return 0;
    }
}
