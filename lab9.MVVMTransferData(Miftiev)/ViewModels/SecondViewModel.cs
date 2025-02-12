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
    [QueryProperty(nameof(InputLesson), nameof(InputLesson))]
    public partial class SecondViewModel : ObservableObject
    {
        [ObservableProperty]
        private Lesson _inputLesson;

        [RelayCommand]
        private async Task GoToFirstViewAsync()
        {
            Lesson lesson = InputLesson;
            await AppShell.Current.GoToAsync(nameof(FirstPage), new Dictionary<string, object>
            {
                { nameof(FirstViewModel.OutputLesson), lesson }
            });
        }

    }
}
