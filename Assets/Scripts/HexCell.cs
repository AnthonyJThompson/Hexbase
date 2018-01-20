using UnityEngine;

public class HexCell : MonoBehaviour {

	public HexCoordinates coordinates;

	public Color color;

    public Structure Structure;

	[SerializeField]
	HexCell[] neighbors;

    public float updateInterval = 1.0f;
    private float nextUpdate = 0.0f;

    private void Update()
    {
        if (Time.time > nextUpdate)
        {
            nextUpdate += updateInterval;

            if (Structure != null)
            {
                Structure.AddResource();
                //Debug.Log("update");
            }

        }
    }

    public HexCell GetNeighbor (HexDirection direction) {
		return neighbors[(int)direction];
	}

	public void SetNeighbor (HexDirection direction, HexCell cell) {
		neighbors[(int)direction] = cell;
		cell.neighbors[(int)direction.Opposite()] = this;
	}

}