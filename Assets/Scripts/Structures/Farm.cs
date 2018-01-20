using UnityEngine;

public class Farm : Structure {
    public int Level = 1;

    public override void AddResource()
    {
        ResTracker.Food += Level;
    }
}
