class Guard_Gallivant_P1 {

	static int Main()
	{
		string fileName = "test.txt";
		int result;
		if (!File.Exists(fileName))
			return 1;
		string[] lines = File.ReadAllLines(fileName);
		for (int y = 0; y < lines.Length;y++)
			for (int x = 0;x < lines[y].Length;x++)
				if (lines[y][x] == '^')
		
	}
}
