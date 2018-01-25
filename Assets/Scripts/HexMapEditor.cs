using UnityEngine;
using UnityEngine.EventSystems;

public class HexMapEditor : MonoBehaviour {

	public Color[] colors;
	
	public HexGrid hexGrid;

	private Color activeColor;
    private int activeElevation;
	private bool isEnabled = true;

	void Awake () {
		SelectColor(-1);
	}

	void Update () {
		if (
			Input.GetMouseButton(0) &&
			!EventSystem.current.IsPointerOverGameObject() &&
            isEnabled
		) {
			HandleInput();
		}
	}

	void HandleInput () {
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			EditCell(hexGrid.GetCell(hit.point));
		}
	}
	void EditCell (HexCell cell) {
		cell.SetType(activeColor, GetIndex(activeColor));
		cell.Elevation = activeElevation;
		hexGrid.Refresh();
	}
	public void SelectColor (int index) {
        if (index == -1)
        {
            isEnabled = false;
            return;
        }
        isEnabled = true;
		activeColor = colors[index];
	}

	public void SetElevation (float elevation) {
		activeElevation = (int)elevation;
	}
	public int GetIndex(Color color) {
		return System.Array.IndexOf(colors, color);
	}
}