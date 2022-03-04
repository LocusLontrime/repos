Console.WriteLine("");
Console.WriteLine("________________________________________________________");
Console.WriteLine("24. Найти кубы чисел от 1 до N");
Console.WriteLine("________________________________________________________");
Console.WriteLine("");
Console.Write("Введите N (от 1 до 255): ");
byte N = Convert.ToByte(Console.ReadLine());
Console.WriteLine("");

for (int i = 1; i <= N; ++i)
{
    string text = "--------+----------\n";
    text += "   " + i + " \t| " + i * i * i;
    Console.WriteLine(text);
}
Console.WriteLine("--------+----------");