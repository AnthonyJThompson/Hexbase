using UnityEngine;

public class Structure : MonoBehaviour
{
    public System.Collections.Generic.List<CellType> ValidCellTypes;
    public virtual void StructureUpdate() {}
    internal void SetActive(bool v)
    {
        var renderer = GetComponent<MeshRenderer>();
        renderer.enabled = v;
    }
}
