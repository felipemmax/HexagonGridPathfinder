using System.Collections.Generic;
using HexagonGridPathfinder.Pathfinder.Interfaces;
using UnityEngine;

namespace HexagonGridPathfinder.Pathfinder
{
    public class HexMap : IMap
    {
        private readonly Dictionary<Vector2Int, ICell> _cells;
        
        private readonly Vector2Int[] _neighborOffsets = 
        {
            new Vector2Int(1, -1), new Vector2Int(1, 0), new Vector2Int(0, 1),
            new Vector2Int(-1, 1), new Vector2Int(-1, 0), new Vector2Int(0, -1)
        };

        public HexMap(Dictionary<Vector2Int, ICell> cells)
        {
            _cells = cells;
        }

        public ICell GetCell(Vector2Int position)
        {
            _cells.TryGetValue(position, out ICell cell);
            return cell;
        }

        public IEnumerable<ICell> GetNeighbors(ICell cell)
        {
            foreach (Vector2Int offset in _neighborOffsets)
            {
                Vector2Int neighborPosition = cell.GridPosition + offset;
                
                if (_cells.TryGetValue(neighborPosition, out ICell cellNeighbor))
                    yield return cellNeighbor;
            }
        }
    }
}