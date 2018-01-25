using UnityEngine;

[CreateAssetMenu()]
public class ResourceTracker : ScriptableObject {
    
    public float Food;
    public float Wood;

    public void AddResource(ResourceType type, float amount) {
        if (type == ResourceType.Food) {
            Food += amount;
        }
        else if (type == ResourceType.Wood){
            Wood += amount;
        }    
    }
}
public enum ResourceType {
    Food, Wood
}    