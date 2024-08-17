using Lesson_2_Part_2.Classes.Descriptive;
using Lesson_2_Part_2.Interfaces;

namespace Lesson_2_Part_2.Classes.Action
{
    public class Input_output : IInputOutput
    {
        public event Action<string> onMessageReceived;

        public void ReceiveMessage(string message)
        {
            onMessageReceived?.Invoke(message);
        }
        public void ShowOneTank(IReadOnlyCollection<Factories> factories, IReadOnlyCollection<Units> units, IReadOnlyCollection<Tanks> tanks)
        {
            Console.WriteLine("Enter the name of the tank or 'q' to quit: ");
            while (true)
            {
                var desiredTank = new List<Tanks>();

                var enter = Console.ReadLine();
                if (enter == "q") break;

                var foundTank = tanks.FirstOrDefault(x => x.Name.Equals(enter, StringComparison.OrdinalIgnoreCase));
                if (foundTank != null)
                {
                    desiredTank.Add(foundTank);
                    ShowTanksInfo(factories, units, desiredTank);
                }
                else
                {
                    Console.WriteLine($"Tank with name '{enter}' not found.");
                }
            }
        }

        public void ShowTanksInfo(IReadOnlyCollection<Factories> factories, IReadOnlyCollection<Units> units, IReadOnlyCollection<Tanks> tanks)
        {
            var tanksInfo = tanks.Select(tank =>
            {
                var unit = units.FirstOrDefault(x => x.Id == tank.UnitId);
                var factory = factories.FirstOrDefault(x => x.Id == unit?.FactoryId);

                return $"Id: {tank.Id}, Tank name: {tank.Name}, Description: {tank.Description}," +
                    $" Volume: {tank.Volume}, Max volume: {tank.MaxVolume}, unit: {unit?.Name ?? "Unit not found"}" +
                    $" ({unit?.Description ?? "Unit not found"}), factory: {factory?.Name ?? "Factory not found"}" +
                    $" ({factory?.Description ?? "Unit not found"})";
            }).ToList();

            foreach (var tank in tanksInfo)
            {
                Console.WriteLine(tank + "\n");
            }
        }
    }
}
