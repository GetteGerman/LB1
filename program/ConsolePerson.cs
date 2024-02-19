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
        /// Добавление персоны через консоль.
        /// </summary>
        /// <returns>Новая персона.</returns>
        public static Person AddPersonConsole()
        {

            {
                Person newperson = new Person();

                var actionList = new List<Action>
            {
                (new Action(() =>
                {
                    Console.Write($"\nВведите имя человека: ");
                    string name = Console.ReadLine();
                    if ( Person.Checktype(name))
                    {
                        newperson.Name =Person.ConvertFirstlatterToup(name) ;

                    }

                })),
                (new Action(() =>
                {
                    Console.Write($"Введите фамилию человека: ");
                    string surname = Console.ReadLine();
                    if ( Person.Checktype(surname))
                    {
                        newperson.Surname =Person.ConvertFirstlatterToup(surname) ;

                    }
                })),
                (new Action(() =>
                {
                    Console.Write($"Введите возраст человека:");
                    bool result = ushort.TryParse(Console.ReadLine(),
                        out ushort age);
                    if(result != true)
                    {
                        throw new ArgumentException("Возраст должен быть" +
                            " положительным, введите ещё раз!");
                    }
                    if ( Person.CheckAge(age))
                    {
                        newperson.Age =age ;

                    }
                })),
                (new Action(() =>
                {
                    Console.Write($"Введите пол человека:");
                    string gender1 = Console.ReadLine();
                    if (gender1 == "ж" || gender1 == "w")
                    {
                        newperson.Gender = Gender.Female;
                    }
                    else if (gender1 == "м" || gender1 == "m")
                    {
                        newperson.Gender = Gender.Male;
                    }
                    else
                    {
                        throw new ArgumentException("Введён некорректный" +
                            " пол, введите м(m) или ж(w)!");
                    }
                }))
            };

                foreach (var action in actionList)
                {
                    ActionHandler(action);
                }

                return newperson;
            }

        }

        
        public static void Print(PersonList people)
        {
            int count = people.CountElementsList();

            for (int i = 0; i < count; i++)
            {
                Person pers = people.FindByIndex(i);
                Console.WriteLine(pers.GetInfo());
            }
        }

        private static void ActionHandler(Action action)
        {
            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    
                }
                catch (ArgumentException exception)
                {

                }
            }
        }


    }
}
