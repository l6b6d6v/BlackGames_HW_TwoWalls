using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{
    public static GameObject selectedObject;
    private GameObject notClickable;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();
                // Bypass invisible wall
                if (hit.collider.gameObject.CompareTag("notClickable"))
                {
                    notClickable = hit.collider.gameObject;
                    notClickable.GetComponent<Collider>().enabled = false;
                    hit = CastRay();
                }
                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("redCube") && !hit.collider.CompareTag("blueCube"))
                    {
                        notClickable.GetComponent<Collider>().enabled = true;
                        return;
                    }

                    selectedObject = hit.collider.gameObject;
                    Cursor.visible = false;
                    selectedObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }

        if (selectedObject != null)
        {
            notClickable.GetComponent<Collider>().enabled = true;
            Vector3 position = new (
                Input.mousePosition.x, 
                Input.mousePosition.y, 
                Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);
        }

        if (Input.GetMouseButtonUp(0))
        {

            notClickable.GetComponent<Collider>().enabled = true;
            if (selectedObject != null)
            {
                selectedObject.GetComponent<Rigidbody>().useGravity = true;
            }
            selectedObject = null;
            Cursor.visible = true;
        }
    }


    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new(
                    Input.mousePosition.x,
                    Input.mousePosition.y,
                    Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}