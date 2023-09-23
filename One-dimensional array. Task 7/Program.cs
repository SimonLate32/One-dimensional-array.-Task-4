using System;

class Program
{
    static void Main()
    {
        int[] array;
        do
        {
            // Ввод массива с консоли
            array = ConsoleReadArray<int>("A");

            // Проверка длины массива
            if (array.Length < 3)
            {
                Console.WriteLine("Массив слишком короткий. Пожалуйста, введите массив, содержащий как минимум 3 элемента.");
            }
        }
        while (array.Length < 3); // Повторять, пока длина массива меньше 3

        // Вызов функции для преобразования массива
        TransformArray(array);

        // Вывод преобразованного массива
        Console.Write("Преобразованный массив:\n  {0}", ArrayToStr(array));
    }

   //Проверка и на первое и последние число, которые нельзя изменять
    static void TransformArray(int[] array)
    {

        int lastElement = array[array.Length - 1];

        for (int i = 1; i < array.Length - 1; i++)
        {
            if (array[i] % 2 == 0)
            {
                array[i] += lastElement;
            }
        }
    }

    //Конвертирование массива 
    static T StrToValue<T>(string str)
    {
        return (T)Convert.ChangeType(str, typeof(T));
    }

    //Ввод значений массива
    static T ConsoleReadValue<T>(string varName)
    {
        while (true)
            try
            {
                Console.Write("Введите {0}: ", varName);
                return StrToValue<T>(Console.ReadLine());
            }
            catch { }
    }

    //Проверка на воод массива через запятую или пробел
    static T[] StrToArray<T>(string str)
    {
        return Array.ConvertAll(
            str.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries),
            (s) => StrToValue<T>(s)
        );
    }

    //Вывод чисел массива через запятую
    static string ArrayToStr<T>(T[] arr, string separator = ", ")
    {
        return arr == null ? "null" : string.Join(separator, arr);
    }

    //Функция для ввода чисел массива через запятую или пробел
    static T[] ConsoleReadArray<T>(string arrName)
    {
        while (true)
            try
            {
                Console.Write("Введите (через пробел или запятую) массив {0}: ", arrName);
                return StrToArray<T>(Console.ReadLine());
            }
            catch { }
    }
}