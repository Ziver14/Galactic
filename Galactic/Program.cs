using static Galactic.Spaceship;
using System.Text.Json;

namespace Galactic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Cоздаем флот и командующего
            var fleet = new CommandFleet("Стуков", "Адмирал", 34);
            // Добавляем корабли
            fleet.AddSpaceShip(new SpaceShip(1, "Дюк", "Крейсер", 15000));
            fleet.AddSpaceShip(new SpaceShip(2, "Корсар", "Истребитель", 10000));

            //Создание миссии
            fleet.AssignMission(2, new Mission(1, "Завоевание", "Марс", DateTime.Now));

            //Поиск краблей
            var searchResult = fleet.SearchSpaceShips(model: "Корсар");

            // Вывод Json
            string jsonSpaceShips = Fleet.SerializeSpaceShips(searchResult);
            string jsonMissions =   Fleet.SerializeMissins(fleet.missions);

            // Десериализация из json
            var deserializedShips = Fleet.DeserializeSpaceShips(jsonSpaceShips);
            var deserializedMissions = Fleet.DeserializeMissions(jsonMissions);

        }
    }
}
