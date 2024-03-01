using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Лист персоны.
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Список персон.
        /// </summary>
        private List<Person> _people = new List<Person>();

        /// <summary>
        /// Добавление элемента.
        /// </summary>
        /// <param name="people">список персон.</param>
        public void Add(Person person)
        {
            _people.Add(person);
        }

        /// <summary>
        /// Удаление всего списка.
        /// </summary>
        /// <param name="people">список персон.</param>
        public void DeleteAll()
        {
            _people.Clear();
        }

        /// <summary>
        /// Удалять элементы по индексу.
        /// </summary>
        /// <param name="people">список персон.</param>
        /// <param name="index">индекс персоны для удалеия.</param>
        public void DeleteByIndex(int index)
        {
            _people.RemoveAt(index);
        }
        /// <summary>
        /// Удалить выбранный элемент списка.
        /// По фамилии.
        /// </summary>
        /// <param name="people">список персон.</param>
        /// <returns>количество удаленных записей. </returns>
        public int DeleteBySurname(string surname)
        {
            int count = _people.RemoveAll(s => s.Surname == surname);
            return count;
        }
        /// <summary>
        /// Искать элемент по указанному индексу.
        /// </summary>
        /// <param name="people">заданный список.</param>
        /// <param name="index">искомый индекс.</param>
        public Person FindByIndex(int index)
        {
            int countIndex = _people.Count - 1;

            if (countIndex < index)
            {
               throw new IndexOutOfRangeException("Элемента с индексом " +
                    "{index} нет в списке");
            }
            else
            {
                return _people[index];
            }
        }

        /// <summary>
        /// Вернуть индекс элемента (по фамилии) при
        /// наличии его в списке.
        /// </summary>
        /// <param name="people">заданный список.</param>
        /// <param name="surname">заданная фамилия для поиска.</param>
        /// <returns>индекс по заданной фамилии.</returns>
        public int FindIndex(string surname)
        {
            int index = _people.FindIndex(s => s.Surname == surname);
            return index;
        }

        /// <summary>
        /// Колличество элементов в списке.
        /// </summary>
        /// <param name="people">заданный список.</param>
        /// <returns>колическтозаписей.</returns>
        public int CountElementsList()
        {
            return _people.Count;
        }
    }
}
