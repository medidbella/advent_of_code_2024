class Red_Nosed_Reports_P1
{
	static int Main(string[] Args)
	{
		string FileName = "input.txt";
		if (!File.Exists(FileName))
			return 1;
		string[] Lines = File.ReadAllLines(FileName);
		
	}
}
