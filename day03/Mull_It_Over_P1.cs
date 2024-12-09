class Mull_it_Over_P1{
	static bool IsInstructionHead(string, int Index)
	{
		string Reference = "mul(";
		int RefIndex;
		while(RefIndex < Reference.Length)
		{
			RefIndex++;
		}
	}

	static int main()
	{
		string FileName = "input.txt";
		int Result = 0;
		if (!FileName.Exists(FileName))
			return 1;
		string Text = File.ReadAllText(FileName);
		for (int i = 0 ; i < Text.Length;i++)
		{
			if (IsInstructionHead(Text, i))
			i++;
		}
		return 0;
	}
}