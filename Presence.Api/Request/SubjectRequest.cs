using Data.DAO;

namespace Presence.Api.Request
{
    public class SubjectRequest
    {
        public Subjects Id { get; set; }
        public int Semestr { get; set; }
    }
}
