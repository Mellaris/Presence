namespace Presence.Api.Response
{
    public class SubjectResponse
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public IEnumerable<GroupSubjectResponse> groupSubjects { get; set; }

    }
}
