using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject2 : MonoBehaviour
{
    public string sceneName;
    public float interactionDistance = 1f;
    public SpriteRenderer spriteRenderer;
    public GameObject interactionMessage;

    private Transform player;
    private bool isInRange = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer.enabled = false;
        interactionMessage.SetActive(false);
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            LoadScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            spriteRenderer.enabled = true;
            interactionMessage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            spriteRenderer.enabled = false;
            interactionMessage.SetActive(false);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
