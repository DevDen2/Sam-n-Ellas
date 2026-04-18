using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class Drag : MonoBehaviour
{
    public GameObject currentlyDraggedObject = null;
    private float savedZPosition = 0;
    public Camera cam;
  
    private Vector3 previousDragPosition;
    private Vector3 currentDragPosition;
  
    public void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Vector2 mousePosition = Input.mousePosition;
  
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("shot");
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.tag == "Draggable")
                {
                    Debug.Log("hit");
                    currentlyDraggedObject = hit.collider.gameObject;
                    savedZPosition = Mathf.Abs(cam.transform.position.z - currentlyDraggedObject.transform.position.z);
                    // currentlyDraggedObject.GetComponent<Rigidbody>().isKinematic = true;
                    currentDragPosition = currentlyDraggedObject.transform.position;
                }
            }
        }         
  
        if(currentlyDraggedObject != null)
        { 
            if(currentlyDraggedObject != null)
                { 
                    Rigidbody rb = currentlyDraggedObject.GetComponent<Rigidbody>();
                    
                    // 1. Calculate where the mouse wants the object to be
                    Vector3 targetPos = cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, savedZPosition));

                    // 2. IMPORTANT: Instead of setting transform.position, use MovePosition.
                    // This tells the physics engine to move there but STOP if it hits a wall.
                    rb.isKinematic = false; // Keep physics ON so it can't clip
                    rb.useGravity = false;  // Turn gravity OFF so it doesn't fall while holding it
                    rb.MovePosition(targetPos);

                    // 3. Track position for the throw (same as before)
                    previousDragPosition = currentDragPosition;
                    currentDragPosition = rb.position;

                    if(Input.GetMouseButtonUp(0))
                    {
                        rb.useGravity = true; // Turn gravity back on!
                        
                        // Calculate a sensible throw speed
                        Vector3 throwDirection = (currentDragPosition - previousDragPosition) / Time.deltaTime;
                        
                        // Clamp it so it doesn't teleport again
                        float maxSpeed = 10f; 
                        rb.linearVelocity = Vector3.ClampMagnitude(throwDirection, maxSpeed);
                        
                        currentlyDraggedObject = null;
                    }  
                }
        }
        
    }  

}