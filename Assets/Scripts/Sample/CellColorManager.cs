using UnityEngine;
using UnityEngine.UI;

namespace HexagonGridPathfinder.Sample
{
    public class CellColorManager
    {
        private Image _image;
        private Color _previousColor;

        public CellColorManager(Image image)
        {
            _image = image;
            _previousColor = Color.white;
        }

        public void Reset()
        {
            _image.color = Color.white;
            _previousColor = Color.white;
        }

        public void HighlightColor()
        {
            _image.color = Color.yellow;
            _previousColor = Color.yellow;
        }

        public void OnPointerEnter()
        {
            _previousColor = _image.color;
            _image.color = Color.gray;
        }

        public void OnPointerExit()
        {
            _image.color = _previousColor;
        }
    }
}