using System;
using System.Runtime.ConstrainedExecution;

namespace part2 {
	class CircularBuffer{
		private int repeatedPoints;
		private int index;
		private int[][] buffer;

		public CircularBuffer()
		{
			repeatedPoints = 0;
			index = 0;
			repeatedPoints = 0;
			buffer = new int[4][];
			for(int iter = 0; iter < 4; iter++)
				buffer[iter] = new int[2];
		}

		public void AddPoint(int y, int x)
		{
			if (index == 4)
				index = 0;
			// Console.WriteLine($"adding [{y}][{x}] to buffer at {index}");
			if (buffer[index][0] == y && buffer[index][1] == x)
				repeatedPoints += 1;
			buffer[index][0] = y;
			buffer[index][1] = x;
			index++;
		}

		public bool IsInLoop(){
			return repeatedPoints == 4;
		}
		
		public void ResetBuffer(){
			index = 0;
			repeatedPoints = 0;
		}
	}

	class Guard_Gallivant_P2 {
		
		public static int TurnsNumber = 0;
		public static bool LockCount = false;
		static char SetGuardPointOfView(char CurrentPointOfView)
		{
			string reference = "<>^v";
			string results = "^v><";
			for(int i = 0; i < 4;i++)
				if (CurrentPointOfView == reference[i])
					return results[i];
			return CurrentPointOfView;
		}

		static void SetPointModifiers(char GuardCharacter, ref int xModifier, ref int yModifier)
		{
			if (GuardCharacter == 'v')
				yModifier = 1;
			else if (GuardCharacter == '^')
				yModifier = -1;
			else if (GuardCharacter == '>')
				xModifier = 1;
			else if (GuardCharacter == '<')
				xModifier = -1;
		}

		static bool IsInRange(char[][] Lines, int y, int x)
		{
			if (y < 0 || y >= Lines.Length)
				return false;
			if (x < 0 || x >= Lines[y].Length)
				return false;
			return true;
		}

		static int IsGuardStuckInLoop(char[][] lines, int x, int y, CircularBuffer GuardTurns)
		{
			int localTurnsNumber = 0;
			int xModifier = 0;
			int yModifier = 0;
			int TempX = x;
			int TempY = y;
			SetPointModifiers(lines[y][x], ref xModifier, ref yModifier);
			char tmp = lines[y][x];
			while (IsInRange(lines, y, x))
			{
				if (GuardTurns.IsInLoop() || (LockCount && localTurnsNumber > TurnsNumber))
				{
					Console.WriteLine($"loop ");
					return 1;
				}
				if (IsInRange(lines, y + yModifier, x + xModifier) && lines[y + yModifier][x + xModifier] == '#')
				{
					GuardTurns.AddPoint(y, x);
					lines[y][x] = SetGuardPointOfView(lines[y][x]);
					SetPointModifiers(lines[y][x], ref xModifier, ref yModifier);
					localTurnsNumber += 1;
					if (!LockCount)
						TurnsNumber += 1;
				}
				lines[y][x] = '.';
				y += yModifier;
				x += xModifier;
				if (IsInRange(lines, y, x))
					lines[y][x] = tmp;
			}
			LockCount = true;
			Console.WriteLine(TurnsNumber);
			return 0;
		}

		static int CountPatrolLoops(char [][]lines, int GuardX, int GuardY, char GuardCharacter)
		{
			CircularBuffer GuardTurns = new ();
			int result = 0;
			int x;
			int y = 0;
			int tmp ;
			while (y < lines.Length)
			{
				x = 0;
				while (x < lines[y].Length)
				{
					if (lines[y][x] == '.')
					{
						lines[y][x] = '#';
						if (!LockCount)
							TurnsNumber = 0;
						tmp = IsGuardStuckInLoop(lines, GuardX, GuardY, GuardTurns);
						return 1;
						// if (tmp == 1)
						// 	foreach(var elm in lines)
						// 		Console.WriteLine(elm);
						// result += tmp;
						// lines[y][x] = '.';
						// lines[GuardY][GuardX] = GuardCharacter;
						// GuardTurns.ResetBuffer();
					}
					x++;
				}
				y++;
			}
			return result;
		}

		static int Main()
		{
			string fileName = "test.txt";
			if (!File.Exists(fileName))
				return 1;
			string[] text = File.ReadAllLines(fileName);
			char[][] lines = new char[text.Length][];
			for (int iter = 0; iter < lines.Length;iter++)
			{
				lines[iter] = new char[text[iter].Length];
				for(int i = 0; i < text[iter].Length;i++)
					lines[iter][i] = text[iter][i];
			}
			int GuardX = 0;
			int GuardY = 0;
			char GuardCharacter = '^';
			for (int j = 0; j < lines.Length;j++)
			{
				for (int i = 0;i < lines[j].Length;i++)
				{
					if ("<>^v".Contains(lines[j][i]))
					{
						GuardX = i;
						GuardY = j;
						GuardCharacter = '^';
					}
				}
			}
			int res = CountPatrolLoops(lines, GuardX, GuardY, GuardCharacter);
			// Console.WriteLine(res);
			return 0;
		}
	}	
}	