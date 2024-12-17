using System;

class NumberData {

	public int number;
	private LinkedList<int> data;

	public number_data(int number) {
		this.number = number;
		this.data = new LinkedList<int>();
	}

	public void append(int numberToAdd) {
		this.data.AddLast(numberToAdd);
	}

	public bool isInlist(int numberToCheck)
	{
		foreach (var item in this.data)
		{
			if (item == numberToCheck)
				return true;
		}
		return false;
	}
}

class Print_Queue_P1 {

	static int main()
	{
		string fileName = "input.txt";
		if (!File.Exists(fileName))
			return 1;
		string[] lines = File.ReadAllLines(fileName);
		LinkedList<NumberData> uniqueNumbersList = new();
	}
}