using System.Data.Common;
using System.Text.RegularExpressions;

class Ceres_Search_P1
{
	static bool IsInRange(String[] Lines, int Index1, int Index2)
	{
		if (Index1 < 0 || Index1 >= Lines.Length)
			return false;
		if (Index2 < 0 || Index2 >= Lines[Index1].Length)
			return false;
		return true;
	}

	static int WordSearcher(string[] Lines, int Index1, int Index2)
	{
		int Result = 0;
		int Index1Modifier = -1;
		int Index2Modifier = -1;
		int tmp1 = Index1;
		int tmp2 = Index2;
		int iter;
		string Word = "XMAS";
		while (Index1Modifier < 2)
		{
			Index2Modifier = -1;
			while (Index2Modifier < 2)
			{
				Index1 = tmp1;
				Index2 = tmp2;
				iter = 0;
				while (iter < Word.Length)
				{
					if (!IsInRange(Lines, Index1, Index2))
						break ;
					if (Lines[Index1][Index2] != Word[iter])
						break ;
					iter++;
					Index1 += Index1Modifier;
					Index2 += Index2Modifier;
					if (iter == Word.Length)
						Result+=1;
				}
				Index2Modifier++;
			}
			Index1Modifier++;
		}

		return Result;
	}

	static int Main()
	{
		string FileName = "input.txt";
		if (!File.Exists(FileName))
			return 0;
		int Result = 0;
		string[] Lines = File.ReadAllLines(FileName);
		for (int Index1 = 0; Index1 < Lines.Length; Index1++)
		{
			for (int Index2 = 0; Index2 < Lines[Index1].Length; Index2++)
			{
				if (Lines[Index1][Index2] == 'X')
					Result += WordSearcher(Lines, Index1, Index2);
			}
		}
		Console.WriteLine(Result);
		return 0;
	}
}