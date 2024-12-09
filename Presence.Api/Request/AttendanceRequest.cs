namespace Presence.Api.Request
{
    public class AttendanceRequest
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int LessonN {  get; set; }
    }
}
