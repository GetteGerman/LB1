using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Model;

namespace Lr1
{

    /// <summary>
    /// Класс для добавления персоны через консоль и вывода в консоль.
    /// </summary>
    public static class ConsolePerson
    {
       /// <summary>
       /// Добавление новой персоны.
       /// </summary>
       /// <returns>Вводит новую персону в лист.</returns>
       /// <exception cref="ArgumentOutOfRangeException">введен не положительное число.</exception>
       /// <exception cref="ArgumentException">введено не м(m) или ж(f)</exception>
        public static Person AddPersonConsole()
        {
            {
                Person newperson = new Person();

                var actionList = new List<Action>
                {
                    new Action(() =>
                    {
                        Console.Write($"\nВведите имя человека: ");
                        string name = Person.CheckEmptorNull(Console.ReadLine());
                        if (Person.Checktype(name))
                        {
                            newperson.Name = Person.ConvertFirstLetterToUp(name) ;

                        }

                    }),
                    new Action(() =>
                    {
                        Console.Write($"Введите фамилию человека: ");
                        string surname = Person.CheckEmptorNull(Console.ReadLine());
                        if (Person.Checktype(surname))
                        {
                            newperson.Surname =Person.ConvertFirstLetterToUp(surname) ;
                        }
                    }),
                    new Action(() =>
                    {
                        Console.Write($"Введите возраст человека:");
                        //TODO: RSDN+
                        bool parsedCorrectly = 
                            ushort.TryParse(Person.CheckEmptorNull(Console.ReadLine()),out ushort age);
                        if (!parsedCorrectly)
                        {
                            throw new ArgumentOutOfRangeException("Возраст должен быть" +
                                " положительным числом, введите ещё раз!");
                        }

                        if (Person.CheckAge(age))
                        {
                            newperson.Age = age;
                        }
                    }),
                    new Action(() =>
                    {
                        Console.Write($"Введите пол человека:");
                        string gender = Person.CheckEmptorNull(Console.ReadLine());
                        //TODO: switch-case+
                        switch(gender)
                        {
                            case "ж":
                            case "w":
                            {
                                newperson.Gender = Gender.Female;
                                break;
                            }
                            case "м":
                            case "m":
                            {
                                newperson.Gender = Gender.Female;
                                break;
                            }
                            default:
                            {
                                throw new ArgumentException("Введён некорректный" +
                                    " пол, введите м(m) или ж(w)!");
                            }
                        }
                    }),
                };

                foreach (var action in actionList)
                {
                    ActionHandler(action);
                }

                return newperson;
            }

        }

        /// <summary>
        /// Вывод всех персон входящих в лист.
        /// </summary>
        /// <param name="people">лист для вывода.</param>
        public static void Print(PersonList people)
        {
            int count = people.CountElementsList();

            for (int i = 0; i < count; i++)
            {
                Person pers = people.FindByIndex(i);
                Console.WriteLine(pers.GetInfo());
            }
        }

        /// <summary>
        /// запуск действий для ввода пользователем.
        /// </summary>
        /// <param name="action">действие ввода.</param>
        private static void ActionHandler(Action action)
        {
            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception exception)
                {
                    var ex = exception.GetType();
                    if (ex == typeof(ArgumentOutOfRangeException) ||
                        ex == typeof(ArgumentException))
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }
        }
    }
}
