using System;
using HexagonGridPathfinder.Pathfinder.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HexagonGridPathfinder.Sample
{
    public class HexCellButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private GameObject notWalkableIcon;
        [SerializeField] private GameObject characterIcon;

        private Vector2Int _coordinate;
        private Image _image;
        private Color _previousColor;
        
        private void Start()
        {
            _image = GetComponent<Image>();
        }

        public void SetupCell(Vector2Int coordinate)
        {
            _coordinate = coordinate;
        }
        
        public void Reset()
        {
            _image.color = Color.white;
            _previousColor = Color.white;
            characterIcon.SetActive(false);
        }

        private void ToggleWalkable()
        {
            MapController.OnCellWalkableToggled?.Invoke(_coordinate);
            notWalkableIcon.gameObject.SetActive(!notWalkableIcon.gameObject.activeInHierarchy);
        }

        public void ShowHero()
        {
            characterIcon.SetActive(true);
        }

        public void HighlightColor()
        {
            _image.color = Color.yellow;
            _previousColor = Color.yellow;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    if (!notWalkableIcon.activeInHierarchy)
                        MapController.OnCellChosen?.Invoke(_coordinate);
                    break;
                case PointerEventData.InputButton.Right:
                    ToggleWalkable();
                    MapController.OnPathReset?.Invoke();
                break;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _previousColor = _image.color;
            _image.color = Color.gray;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _image.color = _previousColor;
        }
    }
}
