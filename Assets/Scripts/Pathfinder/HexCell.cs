using HexagonGridPathfinder.Pathfinder.Interfaces;
using UnityEngine;

namespace HexagonGridPathfinder.Pathfinder
{
    public class HexCell : ICell
    {
        public Vector2Int GridPosition { get; private set; }
        public bool IsWalkable { get; private set; }

        public HexCell(Vector2Int position, bool isWalkable)
        {
            GridPosition = position;
            IsWalkable = isWalkable;
        }
    }
}