using HexagonGridPathfinder.Pathfinder.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HexagonGridPathfinder.Sample
{
    public class HexCellButton : Button
    {
        public HexCell Cell { get; private set; }

        public void SetupCell(ICell cell)
        {
            Cell = new HexCell(cell.GridPosition, cell.IsWalkable);
        }
        
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    Debug.Log("Left OnPointerClick called.");
                    break;
                case PointerEventData.InputButton.Right:
                    Debug.Log("Right OnPointerClick called.");
                    break;
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    Debug.Log("Left OnPointerDownDelegate called.");
                    break;
                case PointerEventData.InputButton.Right:
                    Debug.Log("Right OnPointerDownDelegate called.");
                    break;
            }
        }
    }
}
