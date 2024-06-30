using System.Collections.Generic;

namespace HexagonGridPathfinder.Pathfinder.Interfaces
{
    public interface IPathFinder
    {
        IList<ICell> FindPathOnMap(ICell cellStart, ICell cellEnd, IMap map);
    }
}