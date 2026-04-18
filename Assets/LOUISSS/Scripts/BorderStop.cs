using UnityEngine;

public class BorderStop : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool iswall;
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("draggedobject")||other.gameObject.CompareTag("Draggable"))
        {
            Rigidbody rb = other.collider.GetComponent<Rigidbody>();
            Debug.Log("wall");
            rb.isKinematic = false;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity=Vector3.zero;

        }
    }
}
