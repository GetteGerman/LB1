using System;
using System.Collections.Generic;
using System.Data;
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
        /// введенное имя.
        /// </summary>
        private string _name;

        /// <summary>
        /// введенная фамилия.
        /// </summary>
        private string _surname;

        //TODO: RSDN+
        /// <summary>
        /// максимальный возраст.
        /// </summary>
        public const int Maxage = 120;

        //TODO: RSDN+
        /// <summary>
        /// мнимальный возраст.
        /// </summary>
        public const int Minage = 0;

        /// <summary>
        /// имя персоны.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                //BUG:
                if (Checktype(value))
                {
                    _name = ConvertFirstLetterToUp(value);
                }
            }
        }

        /// <summary>
        /// фамилия персоны.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                //BUG:+
                if (Checktype(value))
                {
                    _surname = ConvertFirstLetterToUp(value);
                }
            }
        }

        /// <summary>
        /// возраст персоны.
        /// </summary>
        public int Age
        {
            get
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
        /// Initializes a new instance of the <see cref="Person"/> class.
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

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// Конструктор по умолчанию.
        /// </summary>
        public Person()
            : this("Ivan", "Ivanov", 0, Gender.Male)
        {
        }

        /// <summary>
        /// проверка возраста на входимость в пределы.
        /// </summary>
        /// <param name="age"> возраст.</param>
        /// <returns> входит или нет.</returns>
        public static bool CheckAge(int age)
        {
            //TODO:+
            if (age > Minage & age < Maxage)
            {
                return true;
            }
            else
            {
                //TODO: RSDN+
                throw new ArgumentOutOfRangeException("Значение возраста" +
                    " должно быть в диапазоне от 0 до 120");
            }
        }

        /// <summary>
        /// Проверка на правильность впианных символов.
        /// </summary>
        /// <param name="name_surname">проверяеый элемент.</param>
        /// <returns>правильный ли тип введенной информации.</returns>
        public static bool Checktype(string name_surname)
        {
            //TODO: RSDN+
            Regex tire = new Regex(@"[-]");
            Regex checkletter = new Regex(@"[^А-яA-z-]+");
            Regex rus = new Regex(@"[А-я]+");
            Regex eng = new Regex(@"[A-z]+");
            if (checkletter.IsMatch(name_surname))
            {
                throw new ArgumentException("Имя и фамилия должны содержать " +
                            "только русские или английскик буквы");
            }
            else if (tire.IsMatch(name_surname))
            {
                string[] words = name_surname.Split(new char[] { '-' });
                string word1 = words[0];
                string word2 = words[1];
                if (!((rus.IsMatch(word1) && rus.IsMatch(word2)) ||
                    (eng.IsMatch(word1) && eng.IsMatch(word2))))
                {
                    throw new ArgumentException("Имя/фамилия должны состоять только из русских " +
                        "или только из английскийх букв");
                }

                return true;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Проверка на пустую строку.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <returns>Строку.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public static string CheckEmptorNull(string value)
        {
            if (value == null)
            {
                throw new ArgumentException("Введенный параметр не может быть null");
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Введенный параметр не может быть пустым");
            }

            return value;
        }

        //TODO: rename
        /// <summary>
        /// изменения регистра первой буквы.
        /// </summary>
        /// <param name="word">изначальное слово.</param>
        /// <returns>Измененный регистр слова.</returns>
        public static string ConvertFirstLetterToUp(string word)
        {
            //TODO: завести локальную переменную+
            string bufferword=word;
            bufferword=word[0].ToString().ToUpper() + word.Substring(1).ToLower();
            //TODO: RSDN+
            Regex tire = new Regex(@"[-]");
            if (tire.IsMatch(bufferword))
            {
                string[] bufferwords = bufferword.Split(new char[] { '-' });
                string firstword = bufferwords[0];
                string secondword = bufferwords[1];
                firstword = firstword[0].ToString().ToUpper() + firstword.Substring(1).ToLower();
                secondword = secondword[0].ToString().ToUpper() + secondword.Substring(1).ToLower();
                bufferword = firstword + "-" + secondword;
            }

            return bufferword;
        }
    }
}