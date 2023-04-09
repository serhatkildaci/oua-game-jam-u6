using System.Collections;
using UnityEngine;
using Invector.vCharacterController;


public class SpeedCapsuleScript : MonoBehaviour {

    public float speedBoostDuration = 2f;
    public float speedBoostMultiplier = 2f;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            // Get the player's vThirdPersonController component
            vThirdPersonController playerController = other.GetComponent<vThirdPersonController>();
            
            // Apply the speed boost
            playerController.moveSpeed *= speedBoostMultiplier;
            
            // Start the coroutine to reset the speed after the duration
            StartCoroutine(ResetSpeed(playerController));
            
            // Destroy the SpeedCapsule object
            Destroy(gameObject);
        }
    }
    
    private IEnumerator ResetSpeed(vThirdPersonController playerController) {
        yield return new WaitForSeconds(speedBoostDuration);
        playerController.moveSpeed /= speedBoostMultiplier;
    }
}




