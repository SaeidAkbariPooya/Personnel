using MiniPerson.Domain.Common;

namespace MiniPerson.Domain.Entities
{
    public class Person : BaseEntity
    {
        #region Props
        public string FullName { get; private set; }
        public string Date { get; private set; }
        public string Time { get; private set; }
        #endregion

        #region Ctor
        private Person() { }

        public Person(string fullName,
                      string date,
                      string time)
        {
            FullName = fullName;
            Date = date;
            Time = time;
        }

        public Person(long id,
                      string fullName,
                      string date,
                      string time)
        {
            Id = id;
            FullName = fullName;
            Date = date;
            Time = time;
        }
        #endregion

        #region Commands
        public static Person Create(string fulltName,
                                    string date,
                                    string time)
            => new(fulltName , date , time);

        public void Update(Person person)
        {
            FullName = person.FullName;
            Date = person.Date;
            Time = person.Time;
        }

        public static Person UpdateNew(long id,
                                    string fullName,
                                    string date,
                                    string time)
        {
            return new Person(id, fullName, date,time);
        }
        #endregion
    }
}