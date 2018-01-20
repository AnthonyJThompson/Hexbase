using UnityEngine;

public class WoodCutter : Structure {
    public int Level = 1;

    public override void AddResource()
    {
        ResTracker.Wood += Level;
    }
}
