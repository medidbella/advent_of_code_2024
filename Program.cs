using System;

class Program
{

    static int Main(String[] Args)
    {
		if (Args.Length != 1)
			return 1;
        Console.WriteLine(Args[0]);
		return 0;
    }

}
