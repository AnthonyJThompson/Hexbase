using UnityEngine;

public class ResourceStructure : Structure {
    public int Level = 1;
    public ResourceType ResourceType;
    public ResourceTracker ResourceTracker;

    public override void StructureUpdate() {
        ResourceTracker.AddResource(ResourceType, Level);
    }
}