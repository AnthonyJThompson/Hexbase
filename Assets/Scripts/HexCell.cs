using UnityEngine;

public class HexCell : MonoBehaviour {
	public HexCoordinates coordinates;
    public Vector3 Position {
		get {
			return transform.localPosition;
		}
	}
    public int Elevation {
		get {
			return elevation;
		}
		set {
			elevation = value;
            Vector3 position = transform.localPosition;
			position.y = value * HexMetrics.elevationStep;
            position.y +=
				(HexMetrics.SampleNoise(position).y * 2f - 1f) *
				HexMetrics.elevationPerturbStrength;
			transform.localPosition = position;
		}
	}
	private int elevation;
    public Color Color;
    public CellType CellType;
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
                Structure.StructureUpdate();
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

    public void SetType(Color color, int cellType){
        Color = color;
        CellType = (CellType)cellType;
    }
}

public enum CellType {
    Grass, Forest, Water, NONE
}