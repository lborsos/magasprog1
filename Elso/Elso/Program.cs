class Program
{
    static void Main(string[] args)
    {
        ushort a, b, c;
        DateTime cdata = DateTime.Now;
        DateTime ddata = new DateTime(2023,9,18);
        DateTime odata = new DateTime();
        Console.WriteLine("Hello!\nAdd meg a háromszög oldalainak hosszát!\nBarmikor kiléphetsz ha \'X\' et irsz!");
        Console.WriteLine(String.Format("Most: {0,8:yyyy.MM.dd} ora: {1,5:HH:mm}",cdata, cdata));

        odata.AddYears(2022);

        if (DateTime.TryParse("2023.08.15", out odata))
        {
            Console.WriteLine(odata);
        } else
        {
            Console.WriteLine("Nem parsolhato a data!");
        }

        Console.WriteLine();

        a = GetValidInput("a");
        b = GetValidInput("b");
        c = GetValidInput("c");

//        Console.WriteLine(VerifyTriangle(a, b, c) ? "A háromszög szerkeszthető!" : "Nem szerkeszthető a háromszög!");
        if (VerifyTriangleIsValid(a, b, c))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A háromszög szerkeszthető!");
            Console.ResetColor();
        } else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nem szerkeszthető a háromszög!");
            Console.ResetColor();

        }
    }

    static ushort GetValidInput(string variableName)
    {
        ushort value;
        while (true)
        {
            Console.Write($"{variableName}=");
            string input = Console.ReadLine().Trim(); // Beolvasás és whitespace eltávolítása

            if (input.ToUpper()  == "X")
            {
                Environment.Exit(0);
            }

            if (ushort.TryParse(input, out value))
            {
                return value; // Kilép a ciklusból, ha a helyes értéket adta meg
            }
            else
            {
                Console.WriteLine("Nem megfelelő formátum! Írd be újra!");
            }
        }
    }

    static bool VerifyTriangleIsValid(ushort a, ushort b, ushort c)
    {
        return !(a == 0 || b == 0 || c == 0 || a >= b + c || b >= a + c || c >= a + b);
    }
}
