using System;
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

        public static Action<ICell> OnCellChosen;
        public static Action<IList<ICell>> OnPathDefined;

        private void Start()
        {
            OnCellChosen += CellChosen;
            _uiManager = FindObjectOfType<UIManager>();
        }

        private void OnDisable()
        {
            OnCellChosen = null;
        }

        public void SetupMap(List<ICell> cells)
        {
            _hexMap = new HexMap(cells);
            _pathFinder = new AStar();
        }
        
        private void CellChosen(ICell cell)
        {
            if (_startCell == null)
            {
                _startCell = cell;
                _uiManager.UpdateStartCoordinates(_startCell.GridPosition);
            }
            else if (_endCell == null)
            {
                _endCell = cell;
                _uiManager.UpdateEndCoordinates(_endCell.GridPosition);
        
                // Find path from start cell to end cell
                IList<ICell> path = _pathFinder.FindPathOnMap(_startCell, _endCell, _hexMap);
                // update UI with the path length
                _uiManager.UpdatePathLength(path.Count);
                OnPathDefined?.Invoke(path);
            }
            else
            {
                // start a new selection, clear start and end cell
                _startCell = cell;
                _endCell = null;
                _uiManager.UpdateStartCoordinates(_startCell.GridPosition);
                _uiManager.UpdateEndCoordinates(default);
                _uiManager.UpdatePathLength(0);
            }
        }
    }
}