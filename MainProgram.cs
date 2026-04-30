namespace Assignment;

public static class MainProgram
{
	public static void Main()
	{
		int index;
		do
		{
			Console.Write("Input what exercise you want to execute (invalid index to exit): ");
			index = Convert.ToInt32(Console.ReadLine());

			switch (index)
			{
				case 1: Exercise_1.Program.EntryPoint(); break;
				case 2: Exercise_2.Program.EntryPoint(); break;
				case 3: Exercise_3.Program.EntryPoint(); break;
				case 4: Exercise_4.Program.EntryPoint(); break;
				case 5: Exercise_5.Program.EntryPoint(); break;
				default: Console.Write("Exiting..."); break;
			}
		} while (index is > 0 and <= 5);
	}
}