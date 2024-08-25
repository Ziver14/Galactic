using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Galactic.Spaceship;

namespace Galactic
{
    public class Fleet:IFleetOperations
    {
        public List<SpaceShip> spaceShips = new List<SpaceShip>();
        public Dictionary<int, List<Mission>> missions = new Dictionary<int, List<Mission>>();

        public void AddSpaceShip(SpaceShip spaceShip)
        {
            spaceShips.Add(spaceShip);
        }
        public void RemoveSpaceShip(int spaceShipId)
        {
            spaceShips.RemoveAll(s => s.ID == spaceShipId);
            missions.Remove(spaceShipId);
        }
        public void AssignMission(int spaceShipId, Mission mission)
        {
            if (!missions.ContainsKey(spaceShipId))
            {
                missions[spaceShipId] = new List<Mission>();
            }
            missions[spaceShipId].Add(mission);
        }
        public List<SpaceShip> SearchSpaceShips(string model = null, decimal? minCost = null, decimal? maxCost = null)
        {
            return spaceShips.Where(s =>
            (model == null || s.Model == model) &&
            (!minCost.HasValue || s.Cost >= minCost.Value) &&
            (!maxCost.HasValue || s.Cost <= maxCost.Value)).ToList();
        }
        public List<Mission> GetMissions(int spaceShipId)
        {
            if (missions.ContainsKey(spaceShipId))
            {
                return missions[spaceShipId];
            }
            return new List<Mission>();
        }
        public static string SerializeSpaceShips(List<SpaceShip> spaceShips)
        {
            return JsonSerializer.Serialize(spaceShips);
        }
        public static List<SpaceShip> DeserializeSpaceShips(string json)
        {
            return JsonSerializer.Deserialize<List<SpaceShip>>(json);
        }
        public static string SerializeMissins(Dictionary<int, List<Mission>> missions)

        {
            return JsonSerializer.Serialize(missions);
        }
        public static Dictionary<int, List<Mission>> DeserializeMissions(string json)
        {
            return JsonSerializer.Deserialize<Dictionary<int, List<Mission>>>(json);
        }
    }

}

