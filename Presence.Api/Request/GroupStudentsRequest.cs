namespace Presence.Api.Request
{
    public class GroupStudentsRequest
    {
        public string Name { get; set; }
        public List<StudentRequest> Students { get; set; }
    }
}
