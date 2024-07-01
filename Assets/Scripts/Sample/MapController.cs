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

        public static Action<Vector2Int> OnCellChosen;
        public static Action<IList<ICell>> OnPathDefined;
        public static Action OnPathReset;
        public static Action<Vector2Int> OnStartPositionDefined;
        public static Action<Vector2Int> OnCellWalkableToggled;

        private void Start()
        {
            OnCellChosen += CellChosen;
            OnCellWalkableToggled += OnCellWalkableToggle;
            _uiManager = FindObjectOfType<UIManager>();
        }

        private void OnCellWalkableToggle(Vector2Int coordinate)
        {
            ICell cell = _hexMap.GetCell(coordinate);
            cell.IsWalkable = !cell.IsWalkable;
        }

        private void OnDisable()
        {
            OnCellChosen = null;
            OnStartPositionDefined = null;
            OnPathReset = null;
            OnPathDefined = null;
            OnCellWalkableToggled = null;
        }
        
        public void SetupMap(List<ICell> cells)
        {
            _hexMap = new HexMap(cells);
            _pathFinder = new AStar();
        }

        private void CellChosen(Vector2Int coordinate)
        {
            ICell cell = _hexMap.GetCell(coordinate);
            
            if (_startCell == null)
            {
                _startCell = cell;
                _uiManager.UpdateStartCoordinates(_startCell.GridPosition);
                OnStartPositionDefined.Invoke(_startCell.GridPosition);
            }
            else if (_endCell == null)
            {
                _endCell = cell;
                _uiManager.UpdateEndCoordinates(_endCell.GridPosition);
        
                IList<ICell> path = _pathFinder.FindPathOnMap(_startCell, _endCell, _hexMap);

                if (path == null)
                {
                    _uiManager.ShowPathNotFound();
                    return;
                }
                
                _uiManager.UpdatePathLength(path.Count);
                OnPathDefined?.Invoke(path);
            }
            else
            {
                OnPathReset?.Invoke();
                _startCell = cell;
                _endCell = null;
                _uiManager.UpdateStartCoordinates(_startCell.GridPosition);
                _uiManager.UpdateEndCoordinates(default);
                _uiManager.UpdatePathLength(0);
                OnStartPositionDefined.Invoke(_startCell.GridPosition);
            }
        }
    }
}