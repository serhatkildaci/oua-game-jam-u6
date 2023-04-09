using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectedObjectsCounter : MonoBehaviour
{
    public static int numObjects = 0; // Static variable to keep track of the number of objects collected

    public TextMeshProUGUI countertext; // Reference to the UI Text component that displays the counter

    void Update()
    {
        countertext.text = "Objects Collected: " + numObjects.ToString(); // Update the counter text
    }

    // Method to increase the number of collected objects
    public static void IncreaseCounter()
    {
        numObjects++;
    }
}
