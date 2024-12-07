class Program
{
	static bool NotInList(int number, LinkedList<int[]> List, int index)
	{
		int iterator = 0;
		foreach(var elem in List)
		{
			if (iterator == index && elem[0] == number)
				return false;
			iterator++;
		}
		return true;
	}

	static void CreateListFromArray(int[] LeftArray, LinkedList<int[]> List)
	{
		List.AddLast(new int[] {LeftArray[0], Array.FindAll(LeftArray, elm => elm == LeftArray[0]).Length});
		for (int i = 0; i < LeftArray.Length; i++)
		{
			if (NotInList(LeftArray[i], List, i))
				List.AddLast(new int[] {LeftArray[i], Array.FindAll(LeftArray, elm => elm == LeftArray[i]).Length});
		}
	}

	static int GetRelevantVal(int ToFind, LinkedList<int[]> RightList)
	{
		foreach (var elm in RightList)
			if (ToFind == elm[0])
				return elm[1];
		return 0;
	}

	static void	CreateArrayFromString(string[] Lines, int[] LeftArray, int[] RightArray)
	{
		int i = 0;
		string[] Current;
		while (i < Lines.Length)
		{
			Current = Lines[i].Split("   ");
			if (Current.Length != 2)
				break ;
			LeftArray[i] = Convert.ToInt32(Current[0]);
			RightArray[i] = Convert.ToInt32(Current[1]);
			i++;
		}
		return;
	}

    static int Main(string[] Args)
    {
		long result = 0;
		string Text = "1   1\n4   4\n8   8\n5   8\n8   8\n1   1\n1   1\n8   8\n4   4\n";
		Console.Write(Text);
		string[] Lines = Text.Split('\n');
		int[] LeftArray = new int[Lines.Length - (Lines[Lines.Length - 1].Length == 0 ? 1 : 0)];
		int[] RightArray = new int[Lines.Length - (Lines[Lines.Length - 1].Length == 0 ? 1 : 0)];
		LinkedList<int[]> LeftOccurrenceList = new LinkedList<int[]>();
		LinkedList<int[]> RightOccurrenceList = new LinkedList<int[]>();
		CreateArrayFromString(Lines, LeftArray, RightArray);
		CreateListFromArray(LeftArray, LeftOccurrenceList);
		CreateListFromArray(LeftArray, RightOccurrenceList);
		foreach (var elm in LeftOccurrenceList)
			result += elm[0] * elm[1] * GetRelevantVal(elm[0], RightOccurrenceList); 
		Console.WriteLine(result);
		return 0;
	}
}