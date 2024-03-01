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

        /// <summary>
        /// максимальный возраст.
        /// </summary>
        private const int maxage=120;

        /// <summary>
        /// мнимальный возраст.
        /// </summary>
        private const int minage = 0;

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
                if (Checktype(value))
                {
                    _name = ConvertFirstlatterToup(value);
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
                if (Checktype(value))
                {
                    _surname = ConvertFirstlatterToup(value);
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
            _name = name;
            _surname = surname;
            _age = age;
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
            if (age > minage & age < maxage)
            {
                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Значение возраста должно быть в диапазоне от 0 до 120");
            }
        }

        /// <summary>
        /// Проверка на правильность впианных символов.
        /// </summary>
        /// <param name="name_surname">проверяеый элемент.</param>
        /// <returns>правильный ли тип введенной информации.</returns>
        public static bool Checktype(string name_surname)
        {
            Regex tir = new Regex(@"[-]");
            Regex regex = new Regex(@"[А-я,A-z,-]+");
            Regex rus = new Regex(@"[А-я]+");
            Regex eng = new Regex(@"[A-z]+");
            if (!regex.IsMatch(name_surname))
            {
                throw new ArgumentException("Имя и фамилия должны содержать " +
                            "только русские или английскик буквы");
            }
            else if (tir.IsMatch(name_surname))
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
        /// <summary>
        /// изменения регистра первой буквы.
        /// </summary>
        /// <param name="word">изначальное слово.</param>
        /// <returns>Измененный регистр слова.</returns>
        public static string ConvertFirstlatterToup(string word)
        {
            word = word[0].ToString().ToUpper() + word.Substring(1).ToLower();

            Regex regex1 = new Regex(@"[-]");
            if (regex1.IsMatch(word))
            {
                string[] words = word.Split(new char[] { '-' });
                string word1 = words[0];
                string word2 = words[1];
                word1 = word1[0].ToString().ToUpper() + word1.Substring(1).ToLower();
                word2 = word2[0].ToString().ToUpper() + word2.Substring(1).ToLower();
                word = word1 + "-" + word2;
            }

            return word;
        }
    }
}