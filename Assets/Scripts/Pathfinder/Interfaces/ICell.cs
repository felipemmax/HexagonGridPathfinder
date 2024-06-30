using UnityEngine;

namespace HexagonGridPathfinder.Pathfinder.Interfaces
{
    public interface ICell
    {
        Vector2Int GridPosition { get; }
        bool IsWalkable { get; }
    }
}