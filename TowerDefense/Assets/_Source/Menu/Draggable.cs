using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] private bool isSmall;
    [SerializeField] private bool isMedium;
    [SerializeField] GameObject pageBuff;

    public bool IsDragging;
    public Vector3 startPosition;
    private Collider2D _collider;
    private DragController dragController;

    const string SMALL = "Small";
    const string MEDIUM = "Medium";
    const string INSLOT = "InSlot";
    const string UNTAGGED = "Untagged";
    private string pageSize;
    private float movementTime = 15f;
    private System.Nullable<Vector3> movementDestination;
    void Start()
    {
        if (isSmall)
        {
            pageSize = "PageBuffSmall";
        }
        if (isMedium)
        {
            pageSize = "PageBuffMedium";
        }
        _collider = GetComponent<Collider2D>();
        dragController = FindObjectOfType<DragController>();
        startPosition = gameObject.transform.position;
    }
    void FixedUpdate()
    {
        if (movementDestination.HasValue)
        {
            if (IsDragging)
            {
                movementDestination = null;
                return;
            }

            if (transform.position == movementDestination)
            {
                gameObject.layer = Layer.Default;
                movementDestination = null;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, movementDestination.Value, movementTime * Time.fixedDeltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Draggable collidedDraggable = other.GetComponent<Draggable>();

        if (collidedDraggable != null && dragController.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = other.Distance(_collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position = startPosition;
        }


        if (other.CompareTag(SMALL) && isSmall)
        {
            movementDestination = other.transform.position;
            if (other.TryGetComponent<SlotTrigger>(out SlotTrigger slotTrigger))
            {
                gameObject.tag = INSLOT;
                slotTrigger.isOccupied = true;
                slotTrigger.Occupied();
                pageBuff.transform.parent = other.transform;
            }
        }
        else if (other.CompareTag(MEDIUM) && isSmall)
        {
            movementDestination = startPosition;
        }
        else if (other.CompareTag(MEDIUM) && isMedium)
        {
            movementDestination = other.transform.position;
            if (other.TryGetComponent<SlotTrigger>(out SlotTrigger slotTrigger))
            {
                gameObject.tag = INSLOT;
                slotTrigger.isOccupied = true;
                slotTrigger.Occupied();
                
            }
        }
        else if (other.CompareTag(SMALL) && isMedium)
        {
            movementDestination = startPosition;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<SlotTrigger>(out SlotTrigger slotTrigger) && gameObject.tag == INSLOT)
        {
            gameObject.tag = UNTAGGED;
            slotTrigger.UnOccupied();
            slotTrigger.isOccupied = false;
            other.transform.Find(pageSize).parent = transform;
        }
    }
}
