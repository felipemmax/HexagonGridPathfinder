using System.Collections.Generic;
using HexagonGridPathfinder.Game;
using HexagonGridPathfinder.Pathfinder;
using HexagonGridPathfinder.Pathfinder.Interfaces;
using UnityEngine;

namespace HexagonGridPathfinder.Sample
{
    public class MapController : MonoBehaviour
    {
        private HexMap _hexMap;
        private AStar _pathFinder;
        private UIManager _uiManager;
        private ICell _startCell;
        private ICell _endCell;

        public void SetupMap()
        {
            Dictionary<Vector2Int, ICell> cells = new Dictionary<Vector2Int, ICell>();
            _hexMap = new HexMap(cells);
            _pathFinder = new AStar();
        }
    }
}