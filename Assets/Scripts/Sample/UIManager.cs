using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HexagonGridPathfinder.Sample
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI startCoordinatesText;
        public TextMeshProUGUI endCoordinatesText;
        public TextMeshProUGUI pathLengthText;
        
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

        public void ShowPathNotFound()
        {
            pathLengthText.text = $"No path found";
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}