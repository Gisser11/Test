var difWithString = BitCountWithString(5, 10);
var difWithAssembly = BitCountWithAssembly(5, 10);

Console.WriteLine($"Строки - {difWithString}, \n Ассембли - {difWithAssembly}");

Int32 BitCountWithString(int number32, int x)
{
    //Конвертируем число в двоичное представление
    string binNumber32 = Convert.ToString(number32, 2).PadLeft(32, '0');
    string binX = Convert.ToString(x, 2).PadLeft(32, '0');
    
    Int32 count = 0;
    
    for (var i = 0; i < binNumber32.Length; i++)
    {
        if (binNumber32[i] != binX[i])
        {
            count++;
        }
    }

    return count;
}


Int32 BitCountWithAssembly(int number32, int x)
{
    // ^ - XOR, находим отличающиеся биты
    int xorResult = number32 ^ x;
    
    Int32 count = 0;
    
    while (xorResult != 0)
    {
        // единица - признак отличия в битах 
        count += xorResult & 1;
        
        // Сдвигаем число вправо на 1 бит
        xorResult >>= 1;
    }

    return count;
}