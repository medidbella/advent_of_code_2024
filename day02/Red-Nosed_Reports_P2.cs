using System;

class Red_Nosed_Reports_P2
{
	static bool CheckerHelper(int[] Arr, ref int Index, ref int ToleratedLevels, int ChangeRate, string Line)
	{
		if (ChangeRate == -1)
		{
			if (Arr[Index] - Arr[Index - 1] <= -1 && Arr[Index] - Arr[Index - 1] >= -3)
				return true;
			if (Index == Arr.Length - 1 && ToleratedLevels == 0)
				return true;
			if (Index != Arr.Length - 1 && Arr[Index + 1] - Arr[Index - 1] <= -1 && Arr[Index + 1] - Arr[Index - 1] >= -3)
			{
				ToleratedLevels += 1;
				Index += 1;
				return ToleratedLevels == 1;
			}
		}
		else 
		{
			if (Arr[Index] - Arr[Index - 1] <= 3 && Arr[Index] - Arr[Index - 1] >= 1)
				return true;
			if (Index == Arr.Length -1 && ToleratedLevels == 0)
				return true;
			if (Index != Arr.Length - 1 && Arr[Index + 1] - Arr[Index - 1] <= 3 && Arr[Index + 1] - Arr[Index - 1] >= 1)
			{
				ToleratedLevels += 1;
				Index += 1;
				return ToleratedLevels == 1;
			}
		}
		return false;
	}

	static void GetChangeRate(int[] Arr, ref int ChangeRate) 
	{
		int[] checks = new int[4];
		for(int i= 0;i<4;i++)
			checks[i] = 1;
		for (int j = 0; j<4 ;j++)
		{
			if (Arr[j + 1] - Arr[j] < 0)
				checks[j] = -1;
			else if (Arr[j + 1] - Arr[j] == 0)
				checks[j] = 0;
		}
		int decrements = Array.FindAll(checks, elm => elm == -1).Length;
		int increments = Array.FindAll(checks, elm => elm == 1).Length;
		int stable = Array.FindAll(checks, elm => elm == 0).Length;
		if ((decrements != 0 && increments != 0 && stable != 0) || stable > 1)
			ChangeRate = 0;
		if (decrements == increments)
			ChangeRate = 0;
		if (decrements > increments)
			ChangeRate = -1;
	}

	static int CheckReportSafety(string Line)
	{
		int ToleratedLevels = 0;
		int ChangeRate = 1;
		int Index = 0;
		string[] Splitted = Line.Split(" ");
		int[] Levels = new int[Splitted.Length];
		foreach(string Element in Splitted)
			Levels[Index] = Convert.ToInt32(Splitted[Index++]);
		GetChangeRate(Levels, ref ChangeRate);
		if (ChangeRate == 0)
			return 0;
		Index = 1;
		while(Index < Levels.Length)
		{
			if (!CheckerHelper(Levels, ref Index, ref ToleratedLevels, ChangeRate, Line))
				return 0;
			Index++;
		}
		return 1;
	}
	
	static int Main(string[] Args)
	{
		int Result = 0;

		string FileName = "input.txt";
		if (!File.Exists(FileName))
			return 1;
		string[] Lines = File.ReadAllLines(FileName);
		foreach(var Element in Lines)
		{
			if (CheckReportSafety(Element) == 1)
				Console.WriteLine(Element + " : is safe");
			else
				Console.WriteLine(Element + " : is unsafe");
			Result += CheckReportSafety(Element);
		}
		Console.WriteLine(Result);
		return 0;
	}
}
