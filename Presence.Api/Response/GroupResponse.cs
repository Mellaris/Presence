namespace Presence.Api.Response
{
    public class GroupResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<StudentResponse>? Students { get; set; } = null;
    }
}
