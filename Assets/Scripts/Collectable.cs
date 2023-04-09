using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour {
 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectedObjectsCounter.numObjects++;
            Debug.Log("Collected Objects: " + CollectedObjectsCounter.numObjects);
            Destroy(gameObject);
        Debug.Log("Object Destroyed");
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
             Debug.Log("ontriggerexit = true");
           LoadAllObjectsScene();
        }
    }

    void LoadAllObjectsScene() {
        Debug.Log("scenechangevoid = true");
        SceneManager.LoadScene ("all_objects");
        
    }
}
