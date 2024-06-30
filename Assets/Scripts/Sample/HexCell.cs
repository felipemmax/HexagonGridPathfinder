using HexagonGridPathfinder.Pathfinder.Interfaces;
using UnityEngine;

namespace HexagonGridPathfinder.Sample
{
    [System.Serializable]
    public class HexCell : ICell
    {
        public Vector2Int GridPosition { get; }
        public bool IsWalkable { get; }
        
        public HexCell(Vector2Int gridPosition, bool isWalkable)
        {
            GridPosition = gridPosition;
            IsWalkable = isWalkable;
        }
    }
}
