using UnityEngine;

public class Interact : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject ovenui;
    public GameObject allmenuui;
    
    [Header("Settings")]
    public GameObject oven;
    
    private bool canInteract = false; // Tracks if player is in range
    private bool isInMenu = false;

    void Update()
    {
        // Check for 'E' press every frame
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInMenu)
            {
                CloseMenu();
            }
            else if (canInteract)
            {
                OpenMenu();
            }
        }
    }

    void OpenMenu()
    {
        PlayerController.isPaused = true;
        ovenui.SetActive(true);
        allmenuui.SetActive(true);
        foreach (Transform child in allmenuui.transform)
        {
            child.gameObject.SetActive(true);
        }
        isInMenu = true;
    }

    void CloseMenu()
    {
        PlayerController.isPaused = false;
        isInMenu = false;
        
        // Hide all menu children
        foreach (Transform child in allmenuui.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    // Detect when player is near the oven
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == oven)
        {
            canInteract = true;
            Debug.Log("In range of Oven. Press E to interact.");
        }
    }

    // Detect when player walks away
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == oven)
        {
            canInteract = false;
            if (isInMenu) CloseMenu(); // Auto-close if they walk away
        }
    }
}