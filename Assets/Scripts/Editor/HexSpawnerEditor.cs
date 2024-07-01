using HexagonGridPathfinder.Sample;
using UnityEditor;
using UnityEngine;

namespace HexagonGridPathfinder.Editor
{
    [CustomEditor(typeof(HexGrid))]
    public class HexSpawnerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            HexGrid hexGrid = (HexGrid)target;

            if (GUILayout.Button("Resize Parent Panel"))
            {
                ResizeParentPanel(hexGrid);
            }
        }

        private static void ResizeParentPanel(HexGrid hexGrid)
        {
            if (hexGrid.parentPanel != null)
            {
                Vector2 requiredSize = hexGrid.GetRequiredPanelSize();
                hexGrid.parentPanel.sizeDelta = requiredSize;
                EditorUtility.SetDirty(hexGrid.parentPanel);
            }
            else
            {
                Debug.LogError("Parent Panel is not assigned.");
            }
        }
    }
}