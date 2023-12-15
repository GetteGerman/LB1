using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Model;

namespace Lr1
{

    /// <summary>
    /// Класс для добавления персоны через консоль и вывода в консоль.
    /// </summary>
    public static class ConsolePerson
    {
        /// <summary>
        /// Добавление персоны через консоль.
        /// </summary>
        /// <returns>Новая персона.</returns>
        public static Person AddPersonConsole()
        {

            Console.Write($"Введите имя персоны: ");
            string name = Console.ReadLine();
            while (true)
            {

                if (Person.ChecknamesSurenames(name))
                {
                    break;
                }
                else
                {
                    Console.Write($"Введите корректно имя персоны: ");
                    name = Console.ReadLine();
                }
            }

            Console.Write($"Введите фамилию персоны: ");
            string surname = Console.ReadLine();
            while(true)
            {
                
                if (Person.ChecknamesSurenames(surname))
                {
                    break;
                }
                else
                {
                    Console.Write($"Введите корректно фамилию персоны: ");
                    surname = Console.ReadLine();
                }
            }
            int age = 0;
            while (true)
            {
                Console.Write($"Введите возраст персоны: ");
                if (!int.TryParse(Console.ReadLine(), out age))
                {
                    Console.WriteLine("Возраст должен быть числом");
                    continue;
                }
                else if (!Person.CheckAge(age))
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            Console.Write($"Введите пол человека (1 - Мужской или 2 - Женский): ");
            int pregen = Convert.ToInt32(Console.ReadLine());
            Gender gen = Gender.Male;
            switch (pregen)

            {
                case 1:
                    gen = Gender.Male;
                    break;
                case 2:
                    gen = Gender.Female;
                    break;

            }
            return new Person(name, surname, age, gen);

        }

        /// <summary>
        /// Вывод списка персон.
        /// </summary>
        /// <param name="personsList">Список персон.</param>
        public static void Print(PersonList people)
        {
            int count = people.CountElementsList();

            for (int i = 0; i < count; i++)
            {
                Person pers = people.FindByIndex(i);
                Console.WriteLine(pers.GetInfo());
            }
        }
    }
}
