using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keypad : MonoBehaviour
{
    public GameObject objectToEnable;

    [Header("Keypad Settings")]
    public string curPassword = "1234";
    public string input;
    public Text displayText;
    public AudioSource audioData;

    private bool keypadScreen;
    private float btnClicked = 0;
    private float numOfGuesses;

    void Start()
    {
        btnClicked = 0;
        numOfGuesses = curPassword.Length; 
    }

    void Update()
    {

        if (btnClicked == numOfGuesses)
        {
            if (input == curPassword)
            {             
                input = "Correct Password!";
                displayText.text = input.ToString();
                btnClicked = 0;

                CollectedObjectsCounter.numObjects++;
            }
            else
            {
                input = "";
                displayText.text = input.ToString();
                audioData.Play();
                btnClicked = 0;
            }

        }

    }

    void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                var selection = hit.transform;

                if (selection.CompareTag("keypad"))
                {
                    keypadScreen = true;

                    var selectionRender = selection.GetComponent<Renderer>();
                    if (selectionRender != null)
                    {
                        keypadScreen = true;
                    }
                }

            }
        }

        if (keypadScreen)
        {
            objectToEnable.SetActive(true);
        }

    }

    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q":
                objectToEnable.SetActive(false);
                btnClicked = 0;
                keypadScreen = false;
                input = "";
                displayText.text = input.ToString();
                break;

            case "C":
                input = "";
                btnClicked = 0;
                displayText.text = input.ToString();
                break;

            default:
                btnClicked++;
                input += valueEntered;
                displayText.text = input.ToString();
                break;
        }


    }
}
