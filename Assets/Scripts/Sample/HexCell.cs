using HexagonGridPathfinder.Pathfinder.Interfaces;
using UnityEngine;

namespace HexagonGridPathfinder.Sample
{
    [System.Serializable]
    public class HexCell : ICell
    {
        public Vector2Int GridPosition { get; }
        public bool IsWalkable { get; private set; }
        
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
