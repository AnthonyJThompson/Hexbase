using UnityEngine;
using UnityEngine.UI;

public class ResourceText : MonoBehaviour {
    public Text FoodText;
    public Text WoodText;
    public ResourceTracker ResTracker;

	// Update is called once per frame
	void Update () {
        FoodText = "Food: " + ResTracker.Food;
        FoodText = "Wood: " + ResTracker.Wood;
    }
}
