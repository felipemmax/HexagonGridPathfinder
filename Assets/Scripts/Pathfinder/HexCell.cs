using HexagonGridPathfinder.Pathfinder.Interfaces;
using UnityEngine;

namespace HexagonGridPathfinder.Pathfinder
{
    [System.Serializable]
    public class HexCell : ICell
    {
        public Vector2Int GridPosition { get; private set; }
        public bool IsWalkable { get; set; }
        
        public HexCell(Vector2Int gridPosition, bool isWalkable)
        {
            GridPosition = gridPosition;
            IsWalkable = isWalkable;
        }

        public void SetWalkable(bool isWalkable)
        {
            IsWalkable = isWalkable;
        }
    }
}