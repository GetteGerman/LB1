using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс персоны.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// имя персоны.
        /// </summary>
        public string Name;
        /// <summary>
        /// фамилия персоны.
        /// </summary>
        public string Surname;
        /// <summary>
        /// возраст персоны.
        /// </summary>
        public int Age;
        /// <summary>
        /// Пол персоны.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Метод возвращает информацию о человеке в виде строки.
        /// </summary>
        /// <returns>информация о персоне.</returns>
        public string GetInfo()
        {
            return $"Имя: {Name}, Фамилия: {Surname}, Возраст: {Age}, Пол: {Gender}.";
        }
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="name">имя персоны.</param>
        /// <param name="surname">Фамилия персоны.</param>
        /// <param name="age">Возраст персоны.</param>
        /// <param name="gender">Гендер персоны.</param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }
    }
}

