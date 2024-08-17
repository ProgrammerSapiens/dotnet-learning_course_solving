using Lesson_2_Part_2.Classes.Descriptive;

namespace Lesson_2_Part_2.Interfaces
{
    public interface IInputOutput
    {
        public event Action<string> onMessageReceived;
        void ReceiveMessage(string message);
        void ShowOneTank(IReadOnlyCollection<Factories> factories, IReadOnlyCollection<Units> units, IReadOnlyCollection<Tanks> tanks);
        void ShowTanksInfo(IReadOnlyCollection<Factories> factories, IReadOnlyCollection<Units> units, IReadOnlyCollection<Tanks> tanks);
    }
}
