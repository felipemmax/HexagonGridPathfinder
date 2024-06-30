using System;
using HexagonGridPathfinder.Pathfinder.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HexagonGridPathfinder.Sample
{
    public class HexCellButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public HexCell Cell { get; private set; }

        [SerializeField] private GameObject notWalkableIcon;
        [SerializeField] private GameObject characterIcon;

        public void SetupCell(ICell cell)
        {
            Cell = new HexCell(cell.GridPosition, cell.IsWalkable);
        }
        
        private void Reset()
        {
            notWalkableIcon.gameObject.SetActive(false);
            characterIcon.gameObject.SetActive(false);
            Cell.SetWalkable(true);
        }

        private void ToggleWalkable()
        {
            Cell.SetWalkable(!Cell.IsWalkable);
            notWalkableIcon.gameObject.SetActive(!Cell.IsWalkable);
        }

        public void ToggleHighlight()
        {
            GetComponent<Image>().color = Color.yellow;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    MapController.OnCellChosen?.Invoke(Cell);
                    break;
                case PointerEventData.InputButton.Right:
                    ToggleWalkable();
                break;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            GetComponent<Image>().color = Color.gray;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            GetComponent<Image>().color = Color.white;
        }
    }
}
