namespace Presence.Api.Response
{
    public class AttendanceResponse
    {
        public int Id { get; set; }
        public virtual StudentResponse Student { get; set; }
        public virtual SubjectResponse Subject { get; set; }
        public virtual StatusResponse Status { get; set; }
        public DateOnly Date { get; set; }
        public int LessonN { get; set; }
        //public IEnumerable<AttendanceResponse> presences { get; set; }
    }
}
