using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{
    public static GameObject SelectedObject;
    [SerializeField] private float _yMinPos = 0;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && SelectedObject == null)
            MouseButtonDownLogic();

        if (Input.GetMouseButtonUp(0))
            MouseButtonUpLogic();

        if (SelectedObject != null)
            TransformPositionLogic();
    }

    private void TransformPositionLogic()
    {
        Vector3 position = new(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.WorldToScreenPoint(SelectedObject.transform.position).z);
        Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(position);
        SelectedObject.GetComponent<Rigidbody>().MovePosition(new Vector3(
            worldPosition.x,
            (worldPosition.y < _yMinPos) ? worldPosition.y = _yMinPos + SelectedObject.transform.localScale.y / 2 : worldPosition.y,
            worldPosition.z));
    }

    private void MouseButtonDownLogic()
    {
        RaycastHit hit = CastRay();
        if (hit.collider != null)
        {
            if (!hit.collider.CompareTag("redCube") && !hit.collider.CompareTag("blueCube"))
                return;

            SelectedObject = hit.collider.gameObject;
            Cursor.visible = false;
            SelectedObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void MouseButtonUpLogic()
    {
        if (SelectedObject != null)
            SelectedObject.GetComponent<Rigidbody>().useGravity = true;

        SelectedObject = null;
        Cursor.visible = true;
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