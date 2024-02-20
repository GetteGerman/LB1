using Lr1;
using System;
using System.Xml.Linq;
using Model;

namespace Demo
{
    /// <summary>
    /// основная программа.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// основная программа.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Для отображения списков нажмите любую клавишу.\n");
            Console.ReadKey();
            // a.Создайте программно
            // два списка персон, в каждом из которых
            // будет по три человека.
            // b.Выведите содержимое каждого списка на экран с
            //соответствующими подписями списков.
            PersonList list1 = new PersonList();
            var list2 = new PersonList();
            Console.WriteLine("\t\t\tСписок 1.\n");
            for (int i = 0; i < 3; i++)
            {
                list1.Add(RandomPerson.GetRandomPerson());
                list2.Add(RandomPerson.GetRandomPerson());
                
            }

            ConsolePerson.Print(list1);
             Console.WriteLine();
            Console.WriteLine("\t\t\tСписок 2.\n");
             ConsolePerson.Print(list2);
            Console.WriteLine();
            // c.Добавьте нового человека в первый список.
            Console.WriteLine("Добавим персону в 1-ый список. " +
                "Для продолжениянажмите любую клавишу.");
            Console.ReadKey();
            Console.WriteLine();
            list1.Add(ConsolePerson.AddPersonConsole());

            Console.WriteLine("\n\t\t\tСписок 1.\n");
            ConsolePerson.Print(list1);
            Console.WriteLine();
            // d.Скопируйте второго человека из первого списка
            // в конец второго списка.
            // Покажите, что один и тот же человек
            // находится в обоих списках.
            Console.WriteLine();
            Console.WriteLine("\n\t\tКопирование 2-ого человека из" +
                " первого списка в конец второго списка.");
            Console.ReadKey();

            list2.Add(list1.FindByIndex(2));
            

            Console.WriteLine("\nСписок №1:");
            ConsolePerson.Print(list1);

            Console.WriteLine("\nСписок №2:");
            ConsolePerson.Print(list2);

            // e.Удалите второго человека из первого списка. Покажите, что
            // удаление человека из первого списка
            // не привело к уничтожениютэтого же человека во втором списке.
            Console.WriteLine("\n\t\tУдаление второго человека" +
                " из первого списка.");
            Console.ReadKey();

            list1.DeleteByIndex(1);

            Console.WriteLine("\nСписок №1:");
            ConsolePerson.Print(list1);

            Console.WriteLine("\nСписок №2:");
            ConsolePerson.Print(list2);

            // f.Очистите второй список.
            Console.WriteLine("\n\t\tОчищение второго списка.");
            Console.ReadKey();
            list2.DeleteAll();

            Console.WriteLine("\nСписок №1:");
            ConsolePerson.Print(list1);

            Console.WriteLine("\nСписок №2:");
            ConsolePerson.Print(list2);

            Console.ReadKey();

        }

    }
}




