using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using lab9.MVVMTransferData_Miftiev_.Models;    
using lab9.MVVMTransferData_Miftiev_.Views; 

namespace lab9.MVVMTransferData_Miftiev_.ViewModels
{
    [QueryProperty(nameof(OutputLesson), nameof(OutputLesson))]
    public partial class FirstViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _classroomName;

        [ObservableProperty]
        private string _teatcherName;

        [ObservableProperty]
        private string _subjectName;

        [ObservableProperty]
        private TimeSpan _startAt;

        [ObservableProperty]
        private TimeSpan _endAt;

        [ObservableProperty]
        private Lesson _outputLesson;

        [RelayCommand]
        private async Task GoToSecondViewAsync()
        {
            bool isClassroomNameEmpty = string.IsNullOrWhiteSpace(ClassroomName);
            if (isClassroomNameEmpty)
            {
                await AppShell.Current.DisplayAlert("Ошибка", "Название аудитории не может быть пустым!", "ОК");
                return;
            }
            bool isTeacherNameEmpty = string.IsNullOrWhiteSpace(TeatcherName);
            if (isTeacherNameEmpty)
            {
                await AppShell.Current.DisplayAlert("Ошибка", "ФИО преподавателя не может быть пустым!", "ОК");
                return;
            }
            bool isSubjectNameEmpty = string.IsNullOrWhiteSpace(SubjectName);
            if (isSubjectNameEmpty)
            {
                await AppShell.Current.DisplayAlert("Ошибка", "Название дисциплин не может быть пустым!", "ОК");
                return;
            }

            Lesson lesson = new Lesson(ClassroomName, TeatcherName, SubjectName, StartAt, EndAt);
            await AppShell.Current.GoToAsync(nameof(SecondPage), new Dictionary<string, object>
            {
                { nameof(SecondViewModel.InputLesson), lesson }
            });
        }
    }
}
