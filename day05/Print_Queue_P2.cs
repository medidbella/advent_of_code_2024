using System;

namespace part2 {

class NumberData {

	public int number;
	public LinkedList<int> inferiorNumbers;

	public NumberData(int number) {
		this.number = number;
		this.inferiorNumbers = new LinkedList<int>();
	}

	public void Append(int numberToAdd) {
		this.inferiorNumbers.AddLast(numberToAdd);
	}

	public bool IsInList(int numberToCheck)
	{
		foreach (var item in this.inferiorNumbers)
		{
			if (item == numberToCheck)
				return true;
		}
		return false;
	}
}

class Print_Queue_P2 {

	static void AddToList(LinkedList<NumberData> list, int number1, int number2)
	{
		foreach(var node in list)
		{
			if (number1 == node.number)
			{
				node.Append(number2);
				return ;
			}
		}
		NumberData NewElm = new NumberData(number1);
		NewElm.Append(number2);
		list.AddLast(NewElm);
		return ;
	}

	static void InitializeNumbersList(LinkedList<NumberData> list, string[] lines, ref int Index)
	{
		int number1;
		int number2;
		while (Index < lines.Length)
		{
			if (String.IsNullOrEmpty(lines[Index]))
				break;
			number1 = Convert.ToInt32(lines[Index].Split("|")[0]);
			number2 = Convert.ToInt32(lines[Index].Split("|")[1]);
			AddToList(list, number1, number2);
			Index++;
		}
		return ;
	}

	static NumberData GetMatchingNode(int number, LinkedList <NumberData> uniqueNumbersList)
	{
		int i = 0;
		foreach(var elm in uniqueNumbersList)
		{
			if (number == elm.number)
				return elm;
			i++;
		}
		return new NumberData (0);
	}

	static void SwapNumbers(int[] numbers, int index1, int index2)
	{
		int tmp = numbers[index1];
		numbers[index1] = numbers[index2];
		numbers[index2] = tmp;
		return ;
	}
	
	static int CheckUpdateOrder(LinkedList<NumberData> uniqueNumbersList, string line)
	{
		string[] strings;
		bool Unsorted = false;
		bool swapped = true;
		strings = line.Split(',');
		int[] numbers = new int[strings.Length];
		int iter;
		NumberData currentNode;
		for (int i = 0; i < strings.Length ;i++)
			numbers[i] = Convert.ToInt32(strings[i]);

		while (swapped)
		{
			swapped = false;
			iter = 0;
			while (iter < numbers.Length - 1)
			{
				currentNode = GetMatchingNode(numbers[iter], uniqueNumbersList);
				if (!currentNode.IsInList(numbers[iter + 1]))
				{
					SwapNumbers(numbers, iter, iter+1);
					Unsorted = true;
					swapped = true;
				}
				iter++;
			}
		}
	
		if (Unsorted)
			return numbers[numbers.Length / 2];
		else
			return 0;
	}
	
	static int Main()
	{
		string fileName = "input.txt";
		if (!File.Exists(fileName))
			return 1;
		int result = 0;
		string[] lines = File.ReadAllLines(fileName);
		int Index = 0;
		LinkedList<NumberData> uniqueNumbersList = new();
		InitializeNumbersList(uniqueNumbersList, lines, ref Index);
		Index += 1;
		while (Index < lines.Length)
			result += CheckUpdateOrder(uniqueNumbersList, lines[Index++]);
		Console.WriteLine(result);
		return 0;
	}
}
}
