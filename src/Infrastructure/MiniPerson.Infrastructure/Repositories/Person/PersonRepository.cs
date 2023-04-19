using Microsoft.EntityFrameworkCore;
using MiniPerson.Contract.Person.Queries;
using MiniPerson.Domain.DTO;
using MiniPerson.Infrastructure.Base;
using MiniPerson.Infrastructure.Common;
using MiniPerson.Infrastructure.DataBase.Context;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Globalization;

namespace MiniPerson.Infrastructure.Repositories.Person
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _context;

        public PersonRepository(PersonDbContext context)
        {
            _context = context;
        }
        public async Task<List<PersonAllDto>> GetAllAsync()
        {
            PersianCalendar pDate = new PersianCalendar();
            List<PersonAllDto> personDto = new List<PersonAllDto>();
            //personDto.ListRecordViewModel = new List<RecordViewModel>();

            var min = _context.Persons.Min(s => s.Time);
            var max = _context.Persons.Max(s => s.Time);

            foreach (var item in _context.Persons)
            {
                personDto.Add(new PersonAllDto
                {
                    Id = item.Id,
                    FullName = item.FullName,
                    Date = item.Date,
                    Time = item.Time
                });
            }

            var result = JsonConvert.SerializeObject(personDto);
            string title = Guid.NewGuid().ToString().Replace("-", "");
            string FilePath = @"E:\";
            File.WriteAllText(FilePath + "\\" + ""+"AllPerson-"+title + ".txt", result, Encoding.UTF8);

            return personDto.ToList();
        }
        public async Task<PersonDto> GetByPersonAsync(string fullName, string dateTime)
        {
            PersianCalendar pDate = new PersianCalendar();

            //format string Time 08:30:00
            //format string date 2023-04-19
            dateTime = dateTime.ToString().Replace("/", "-");

            PersonDto personDto = new PersonDto();
            personDto.ListRecordViewModel = new List<Domain.DTO.PersonDto.RecordViewModel>();

            var person = _context.Persons.Where(s => s.FullName == fullName && s.Date == dateTime);

            if (!person.Any())
                return null;

            DateTime Date = DateTime.Parse(person.FirstOrDefault().Date);
            //فرد بودن
            if (person.Count() % 2 == 1)
                return null;

            //اولین ورود
            var min = DateTime.Parse(person.Min(s => s.Time));

            //آخرین خروج
            var max = DateTime.Parse(person.Max(s => s.Time));

            personDto.Row = 1;
            personDto.FullName = person.FirstOrDefault().FullName;
            personDto.DateCurrent = pDate.GetYear(Date) + "/" +
                       pDate.GetMonth(Date) + "/" +
                       pDate.GetDayOfMonth(Date);

            personDto.FirstTime = pDate.GetHour(min) + ":" + pDate.GetMinute(min) + ":" + pDate.GetSecond(min);
            personDto.LastTime = pDate.GetHour(max) + ":" + pDate.GetMinute(max) + ":" + pDate.GetSecond(max);
            personDto.DayWeek = DataTimeEx.GetDayShamsi(pDate.GetDayOfWeek(Date).ToString());
            personDto.Type = "عادی";

            DateTime startTime = DateTime.Parse(personDto.FirstTime);
            DateTime endTime = DateTime.Parse(personDto.LastTime);
            TimeSpan ts = endTime.Subtract(startTime);

            foreach (var item in person)
            {
                personDto.ListRecordViewModel.Add(new Domain.DTO.PersonDto.RecordViewModel
                {
                    time = item.Time
                });
            }
            if (personDto.ListRecordViewModel.Any(s => DateTime.Parse(s.time) >= DateTime.Parse("08:30:00") || DateTime.Parse(s.time) <= DateTime.Parse("17:15:00")))
            {
                if (ts >= TimeSpan.Parse("08:30"))
                {
                    personDto.TimeWork = "8:30";
                }
            }
            if (personDto.ListRecordViewModel.Any((s => DateTime.Parse(s.time) >= DateTime.Parse("08:30:00") && DateTime.Parse(s.time) <= DateTime.Parse("08:45:00")
                || (DateTime.Parse(s.time) >= DateTime.Parse("17:00:00") && DateTime.Parse(s.time) <= DateTime.Parse("17:15:00")))))
            {
                if (ts >= TimeSpan.Parse("08:30"))
                {
                    personDto.TimeWork = "8:30";
                }
            }
            if (personDto.ListRecordViewModel.Any(s => (DateTime.Parse(s.time) > DateTime.Parse("08:45:00") || DateTime.Parse(s.time) <= DateTime.Parse("17:00:00")) && person.Count() < 3))
            {
                if (ts < TimeSpan.Parse("08:30"))
                {
                    personDto.Type = "تاخیر زمانی";
                }
            }

            if (ts < TimeSpan.Parse("08:30") && person.Count() > 2)
            {
                personDto.Type = "مرخصی ساعتی";
            }
            if (!person.Any() && _context.Persons.Any(s => s.Date == dateTime))
            {
                personDto.Type = "مرخصی روزانه";
            }

            var result = JsonConvert.SerializeObject(personDto);
            string title = Guid.NewGuid().ToString().Replace("-", "");
            string FilePath = @"E:\";
            File.WriteAllText(FilePath + "\\" + personDto.FullName + "-" + title + ".csv", result, Encoding.UTF8);
            File.WriteAllText(FilePath + "\\" + personDto.FullName + "-" + title + ".txt", result, Encoding.UTF8);

            return personDto;
        }
       
        public async Task<long> InsertAsync(Domain.Entities.Person person)
        {
            await _context.AddAsync(person);
            return person.Id;
        }
    }
}
