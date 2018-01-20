using UnityEngine;
using UnityEngine.EventSystems;

public class Purchase : MonoBehaviour {

	public HexGrid hexGrid;
	public Structure FarmPrefab;
    public Structure WoodPrefab;
    Structure selectedObject;

	void Awake () {
		
	}

	void Update () {
		HandleInput();
	}

	void HandleInput () {
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		HexCell cell = null;
		if (selectedObject != null) {
			bool snapped = false;
			if (Physics.Raycast(inputRay, out hit)) {
				cell = hexGrid.GetCellFromPosition(hit.point);
				if (cell != null) {
					selectedObject.SetActive(true);
					selectedObject.transform.position = cell.transform.position;
					snapped = true;
				}
			}
			if (!snapped) {
				selectedObject.SetActive(false);
			}
		}
		if (Input.GetMouseButton(0) && cell != null) {
            cell.Structure = selectedObject;
			selectedObject = null;
		}
	}

    void ResetSelection ()
    {
        if (selectedObject != null)
        {
            Destroy(selectedObject.gameObject);
        }
    }

	public void SelectFarm ()
    {
        ResetSelection();
        selectedObject = Instantiate<Structure>(FarmPrefab);
		selectedObject.SetActive(false);
	}

    public void SelectWoodCutter()
    {
        ResetSelection();
        selectedObject = Instantiate<Structure>(WoodPrefab);
        selectedObject.SetActive(false);
    }
}
