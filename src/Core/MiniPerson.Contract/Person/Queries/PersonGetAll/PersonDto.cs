using MiniPerson.Application.DTO;

namespace MiniPerson.Domain.DTO
{
    public class PersonDto : BaseEntityDto
    {
        #region Props
        public int Row { get; set; }
        public string FullName { get; set; }
        public string Type { get; set; }
        public string DayWeek { get; set; }
        public string TimeWork { get; set; }
        public string DateCurrent { get; set; }
        public string FirstTime { get; set; }
        public string LastTime { get; set; }
        public List<RecordViewModel> ListRecordViewModel { get; set; }
        #endregion

        public class RecordViewModel
        {
            public string time { get; set; }
        }
    }
}