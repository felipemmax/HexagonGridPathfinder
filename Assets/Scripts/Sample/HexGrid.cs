using System.Collections.Generic;
using HexagonGridPathfinder.Pathfinder.Interfaces;
using UnityEngine;

namespace HexagonGridPathfinder.Sample
{
    public class HexGrid : MonoBehaviour
    {
        public GameObject hexPrefab; 
        public RectTransform parentPanel; 
        public int gridWidth = 10;
        public int gridHeight = 10;
        public float hexRadius = 50f; 

        private float _hexWidth;
        private float _hexHeight;
        private float _widthOffset;
        private float _heightOffset;

        private MapController _mapController;
        private Dictionary<Vector2Int, HexCellButton> _hexCellButtons;

        private void Start()
        {
            _mapController = FindObjectOfType<MapController>();
            _hexCellButtons = new Dictionary<Vector2Int, HexCellButton>();
            MapController.OnPathDefined += HighlightPath;
            MapController.OnPathReset += ResetPath;
            MapController.OnStartPositionDefined += StartPositionDefined;
            CalculateHexDimensions();
            SpawnHexGrid();
        }

        private void HighlightPath(IList<ICell> path)
        {
            foreach (ICell cell in path)
            {
                _hexCellButtons[cell.GridPosition].HighlightColor();
            }
        }

        private void StartPositionDefined(Vector2Int coordinate)
        {
            _hexCellButtons[coordinate].ShowHero();
        }

        private void ResetPath()
        {
            foreach (HexCellButton hexCellButton in _hexCellButtons.Values)
            {
                hexCellButton.Reset();
            }
        }

        private void CalculateHexDimensions()
        {
            _hexWidth = hexRadius * 2;
            _hexHeight = Mathf.Sqrt(3) * hexRadius;
            _widthOffset = _hexWidth * 0.75f;
            _heightOffset = _hexHeight;
        }
        
        private void SpawnHexGrid()
        {
            Vector2 panelSize = parentPanel.rect.size;
            Vector2 startPosition = new Vector2(-panelSize.x / 2, -panelSize.y / 2);
            List<ICell> hexCells = CreateCells(startPosition);
            _mapController.SetupMap(hexCells);
        }

        private List<ICell> CreateCells(Vector2 startPosition)
        {
            List<ICell> hexCells = new List<ICell>();
            
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    Vector2Int gridCoordinate = new Vector2Int(x, y);
                    Vector3 position = CalculateHexPosition(x, y, startPosition);
                    HexCellButton hexCellButton = CreateHexagon(position);
                    hexCellButton.gameObject.name = $"Hex {gridCoordinate}";
                    _hexCellButtons.Add(gridCoordinate, hexCellButton);
                    ICell cell = new HexCell(gridCoordinate, true);
                    hexCells.Add(cell);
                    hexCellButton.SetupCell(gridCoordinate);
                }
            }
           
            return hexCells;
        }

        private Vector3 CalculateHexPosition(int x, int y, Vector2 startPosition)
        {
            float xPosition = startPosition.x + x * _widthOffset;
            float yPosition = startPosition.y + y * _heightOffset;

            if (x % 2 == 1)
            {
                yPosition += _heightOffset / 2;
            }

            return new Vector3(xPosition, yPosition, 0);
        }

        private HexCellButton CreateHexagon(Vector3 position)
        {
            GameObject hex = Instantiate(hexPrefab, parentPanel);
            RectTransform hexRect = hex.GetComponent<RectTransform>();
            hexRect.anchoredPosition = position;
            hexRect.sizeDelta = new Vector2(_hexWidth, _hexHeight);
            return hex.GetComponent<HexCellButton>();
        }

        public Vector2 GetRequiredPanelSize()
        {
            CalculateHexDimensions();
            float panelWidth = gridWidth * _widthOffset + _hexWidth * 0.25f;
            float panelHeight = gridHeight * _heightOffset + _hexHeight * 0.5f;
            return new Vector2(panelWidth, panelHeight);
        }
    }
}
