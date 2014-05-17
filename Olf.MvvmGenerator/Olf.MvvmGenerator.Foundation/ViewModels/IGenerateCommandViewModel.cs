using System.Windows.Input;

namespace Olf.MvvmGenerator.Foundation.ViewModels
{
    public interface IGenerateCommandViewModel
    {
        string Command { get; set; }
        ICommand GenerateCommand { get; }
    }
}