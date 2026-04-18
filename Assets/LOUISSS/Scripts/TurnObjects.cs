using UnityEngine;

public class TurnObjects : MonoBehaviour
{

    public Transform detector;    // Drag your child "InteractionPoint" here
    public float offset = 1.0f;   // Distance from player center
    

    void Update()
    {
        if(!PlayerController.isPaused){
            // 1. Get raw input (-1, 0, or 1) for instant snapping
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Vector2 inputDir = new Vector2(h, v);

            // 2. Only move the detector if we are actually pressing a key
            if (inputDir.sqrMagnitude > 0)
            {
                // Set the local position relative to the player
                // .normalized ensures diagonals aren't longer than cardinals
                detector.localPosition = inputDir.normalized * offset;
            }
        }
    }

    

    // Draws a little bubble in the Scene view so you can see where it is
    private void OnDrawGizmos()
    {
        if (detector != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(detector.position, 0.2f);
        }
    }
}
