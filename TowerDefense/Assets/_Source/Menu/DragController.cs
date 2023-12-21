using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour
{
    public Draggable LastDragged => lastDragged;
    private bool isDragActive = false;
    private Vector2 screenPosition;
    private Vector3 worldPosition;
    private Draggable lastDragged;
    private void Awake()
    {
        DragController[] controllers = FindObjectsOfType<DragController>();
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (isDragActive && (Input.GetMouseButtonUp(0)))
        {
            Drop();
            return;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else
        {
            return;
        }
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        if (isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    lastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }
    private void InitDrag()
    {
         UpdateDragStatus(true);
    }
    private void Drag()
    {
        lastDragged.transform.position = new Vector2(worldPosition.x,worldPosition.y);
    }
    private void Drop()
    {
        UpdateDragStatus(false);
    }
    void UpdateDragStatus(bool isDragging){
        isDragActive = lastDragged.IsDragging = isDragging;
        lastDragged.gameObject.layer = isDragging ? Layer.Dragging : Layer.Default;
    }
}
