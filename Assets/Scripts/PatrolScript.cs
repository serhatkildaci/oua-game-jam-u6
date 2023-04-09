using UnityEngine;
using UnityEngine.SceneManagement;

public class PatrolScript : MonoBehaviour
{
    public float speed = 1.0f;              // Robot's speed
    public float turnSpeed = 90.0f;         // Robot's turning speed
    public AudioClip whistleSound;         // Whistle sound effect
    public string targetSceneName = "all_objects"; // Target scene name
    public string playerObjectName = "Main Camera"; // Player object name

    private bool isMovingForward = true;    // Robot's direction
    private AudioSource audioSource;        // Audio source component

    void Start()
    {
        // Get the audio source component attached to the robot
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Read input from the horizontal axis to determine the direction to turn
        float turnDirection = Input.GetAxis("Horizontal");

        // Rotate the robot around its Y-axis
        transform.Rotate(Vector3.up * turnDirection * turnSpeed * Time.deltaTime);
        
        
        // Move the robot forward or backward based on its direction
        if (isMovingForward)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If the robot detects an object, play the whistle sound effect and transfer the player object to the target scene
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(whistleSound);
            GameObject playerObject = GameObject.Find(playerObjectName);
            SceneManager.LoadScene(targetSceneName);
            DontDestroyOnLoad(playerObject);
            Debug.Log("collision alert player heyo");
        }

        // Reverse the robot's direction when it hits a trigger collider
        if (other.gameObject.CompareTag("durgecmekardesim"))
        {
            isMovingForward = !isMovingForward;
            Debug.Log("Dur geçme kardeşim");
        }
    }
}
