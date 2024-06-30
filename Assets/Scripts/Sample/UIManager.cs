using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HexagonGridPathfinder.Game
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI startCoordinatesText;
        public TextMeshProUGUI endCoordinatesText;
        public TextMeshProUGUI pathLengthText;
        public Button reloadButton;
        
        public void UpdateStartCoordinates(Vector2Int coordinates)
        {
            startCoordinatesText.text = $"Start: {coordinates}";
        }

        public void UpdateEndCoordinates(Vector2Int coordinates)
        {
            endCoordinatesText.text = $"End: {coordinates}";
        }

        public void UpdatePathLength(int length)
        {
            pathLengthText.text = $"Path Length: {length}";
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}