using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MouseExample : MonoBehaviour
{
    void Update()
    {
        /* Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
       {
           Debug.Log("Clicked");
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        }*/
        if (Input.GetMouseButtonDown(0))
        {
            int layerMask = 1 << 8;
            layerMask = ~layerMask;

            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit, " + hit.distance);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
    }
}