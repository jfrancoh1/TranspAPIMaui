using TransApiMaui.Models.Enums;

namespace TransApiMaui.Models
{
    public class UserInfo
    {
        public int id { get; set; }
        public string document { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string? phoneNumber { get; set; }
        public DateTime? createDate { get; set; }
        public DateTime? updateDate { get; set; }
        public TypeUser? typeUser { get; set; }
    }
}
