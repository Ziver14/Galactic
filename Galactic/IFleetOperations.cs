using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Galactic.Spaceship;

namespace Galactic
{
    internal interface IFleetOperations
    {
        void AddSpaceShip(SpaceShip spaceShip);
        void RemoveSpaceShip(int spaceShip);
        void AssignMission(int spaceShipId, Mission mission);
        List<SpaceShip> SearchSpaceShips(string model = null, decimal? minCost = null, decimal? maxCost = null);
        List<Mission> GetMissions(int spaceShipId);
    }
}
