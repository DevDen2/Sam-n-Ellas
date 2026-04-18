using UnityEngine;
public class ConfineCursor : MonoBehaviour
{
    void Start()
    {
        // Confine the cursor to the boundaries of the game window
        Cursor.lockState = CursorLockMode.Confined;
        // Optionally, hide the default hardware cursor and use a custom one
        // Cursor.visible = false; 
    }

    // It's good practice to re-set the lock state when the application focus changes
    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}