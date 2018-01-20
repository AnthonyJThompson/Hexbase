using System;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public ResourceTracker ResTracker;

    public virtual void AddResource() {}
    internal void SetActive(bool v)
    {
        var renderer = GetComponent<MeshRenderer>();
        renderer.enabled = v;
    }
}
