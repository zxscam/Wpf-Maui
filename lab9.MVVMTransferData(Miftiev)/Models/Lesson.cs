using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9.MVVMTransferData_Miftiev_.Models
{
    public class Lesson
    {
        public string ClassroomName { get; set; }
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
        public TimeSpan StartAt { get; set; }
        public TimeSpan EndAt { get; set; }
        public Lesson(string classroomName, string teacherName, string subjectName, TimeSpan startAt, TimeSpan endAt)
        {
            ClassroomName = classroomName;
            TeacherName = teacherName;
            SubjectName = subjectName;
            StartAt = startAt;
            EndAt = endAt;
        }
    }
}
