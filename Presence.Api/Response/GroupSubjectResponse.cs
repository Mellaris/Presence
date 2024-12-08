namespace Presence.Api.Response
{
    public class GroupSubjectResponse
    {
        public GroupResponse Group { get; set; }
        public SubjectResponse Subject { get; set; }
        public int Semestr { get; set; }
    }
}
