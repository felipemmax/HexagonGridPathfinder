using System.Collections.Generic;
using UnityEngine;

namespace HexagonGridPathfinder.Pathfinder.Interfaces
{
    public interface IMap
    {
        ICell GetCell(Vector2Int position);
        IEnumerable<ICell> GetNeighbors(ICell cell);
    }
}