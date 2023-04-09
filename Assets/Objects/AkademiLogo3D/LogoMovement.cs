using System.Collections;
using UnityEngine;

public class LogoMovement : MonoBehaviour
{
    public float moveSpeed = 1f; // set a speed for the movement
    public GameObject[] logoPrefabs; // array of logo prefabs to spawn
    public Vector3[] spawnPositions; // array of spawn positions for the logos
    public float zmove;
    private bool isMoving = false; // flag to check if the objects are already moving

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isMoving) // check if the "e" key is pressed and objects are not already moving
        {
            StartCoroutine(MoveLogo()); // start the coroutine to move the logos
        }
    }

    IEnumerator MoveLogo()
    {
        Debug.Log("MoveLogo started");
        isMoving = true; // set the flag to true to avoid multiple movements at the same time

        // spawn the logos at their designated positions
        for (int i = 0; i < logoPrefabs.Length; i++)
        {
            GameObject logo = Instantiate(logoPrefabs[i], spawnPositions[i], Quaternion.identity);
            logo.transform.parent = transform;
        }

        // move the logos to their new positions
        Vector3 targetPosition = transform.position + new Vector3(0f, 0f, zmove); // set the target position for the movement
        while (transform.position != targetPosition) // move the logos while the target position is not reached yet
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime); // move the objects towards the target position
            yield return null; // wait for the next frame
        }

        isMoving = false; // set the flag back to false when the movement is finished
       
    }
}

