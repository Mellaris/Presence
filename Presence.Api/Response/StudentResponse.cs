namespace Presence.Api.Response
{
    public class StudentResponse
    {
        public int Guid { get; set; }
        public string Name { get; set; }
        public GroupResponse Group { get; set; }
    }
}
