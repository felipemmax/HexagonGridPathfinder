using System;
using System.Collections.Generic;
using HexagonGridPathfinder.Pathfinder.Interfaces;
using UnityEngine;

namespace HexagonGridPathfinder.Pathfinder
{
    public class HexMap : IMap
    {
        private readonly Dictionary<Vector2Int, ICell> _cells;

        private readonly Vector2Int[] _evenColumnOffsets = { new Vector2Int(0, 1), new Vector2Int(-1, 0), new Vector2Int(-1, -1), new Vector2Int(0, -1), new Vector2Int(1, -1), new Vector2Int(1, 0) };
        private readonly Vector2Int[] _oddColumnOffsets = { new Vector2Int(0, 1), new Vector2Int(-1, 1), new Vector2Int(-1, 0), new Vector2Int(0, -1), new Vector2Int(1, 0), new Vector2Int(1, 1) };
        public HexMap(List<ICell> cells)
        {
            if (cells == null)
                throw new NullReferenceException("Trying to build a Hex map with a null cells collection");
            
            //Changing a list to dictionary for a quicker access
            _cells = new Dictionary<Vector2Int, ICell>();

            foreach (ICell cell in cells)
            {
                _cells.Add(cell.GridPosition, cell);
            }
        }

        public ICell GetCell(Vector2Int position)
        {
            _cells.TryGetValue(position, out ICell cell);
            return cell;
        }

        public IEnumerable<ICell> GetNeighbors(ICell cell)
        {
            IEnumerable<Vector2Int> neighborOffsets = GetNeighborOffset(cell.GridPosition);
            
            foreach (Vector2Int offset in neighborOffsets)
            {
                Vector2Int neighborPosition = cell.GridPosition + offset;

                if (_cells.TryGetValue(neighborPosition, out ICell cellNeighbor))
                {
                    yield return cellNeighbor;
                }
            }
        }
        private IEnumerable<Vector2Int> GetNeighborOffset(Vector2Int cellCoordinate)
        {
            return (cellCoordinate.x % 2 == 0) ? _evenColumnOffsets : _oddColumnOffsets;
        }  
    }
}