using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс персоны.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// введенный возраст.
        /// </summary>
        private int _age;
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
        public int Age
        { get
            {
                return _age;
            }
            set
            {
                if (CheckAge(value))
                {
                    _age = value;
                }
            } 
        }
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
            _age = age;
            Gender = gender;
        }
        /// <summary>
        /// проверка возраста на входимость в пределы
        /// </summary>
        /// <param name="age"> возраст</param>
        /// <returns> входит или нет</returns>
        public static bool CheckAge(int age)
        {
            bool flag = false;
            try
            {
                if (age > 0 & age < 120)
                {
                    flag = true;
                    return flag;
                }
                else
                {
                    throw new Exception("Значение возраста должно быть в диапазоне от 0 до 120");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return flag;


            }
        }
        /// <summary>
        /// Проверка на правильность впианных символов
        /// </summary>
        /// <param name="name_surname">проверяеый элемент</param>
        /// <returns>возврощает имя</returns>
        public static bool ChecknamesSurenames(string name_surname)
        {
            bool flag = false;
                    Regex regex = new Regex(@"[А-я,A-z-]+");
                    if (!regex.IsMatch(name_surname))
                    {
                    
                Console.WriteLine("Имя и фамилия должны содержать " +
                            "толко русские или английскик буквы");
                        return flag;
                    }
                    else
                    {
                        flag = true;
                        return flag;
                    }
        }
        /// <summary>
        /// Проверка регистра
        /// </summary>
        /// <param name="namesurename"></param>
        /// <returns></returns>
        //public static string CheckRegister(string namesurename)
        //{
        //    Regex checkregex = new Regex(@"(\w)");
        //    MatchCollection match = checkregex.Matches(namesurename);
        //    foreach (Match i in match)
        //    {
        //        Console.WriteLine(i);
        //        return i.Value;
        //    }
        //    return namesurename;
        //}
    }
}

