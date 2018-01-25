using UnityEngine;
using UnityEngine.UI;

public class ResourceText : MonoBehaviour {
    public Text FoodText;
    public Text WoodText;
    public ResourceTracker ResTracker;

	// Update is called once per frame
	void Update () {
        FoodText.text = "Food: " + ResTracker.Food;
        WoodText.text = "Wood: " + ResTracker.Wood;
    }
}
