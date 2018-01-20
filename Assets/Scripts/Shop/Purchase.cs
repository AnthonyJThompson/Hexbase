using UnityEngine;
using UnityEngine.EventSystems;

public class Purchase : MonoBehaviour {

	public HexGrid hexGrid;
	public GameObject FarmPrefab;
	GameObject selectedObject;

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
					Debug.Log(cell.transform.position);
					snapped = true;
				}
			}
			if (!snapped) {
				selectedObject.SetActive(false);
			}
		}
		if (Input.GetMouseButton(0) && cell != null) {
			selectedObject = null;
		}
	}

	public void SelectFarm () {
		Destroy(selectedObject);
		selectedObject = Instantiate<GameObject>(FarmPrefab);
		selectedObject.SetActive(false);
	}
}
