using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 curScreenPos;
    private Camera mainCamera;
    private bool isDragging;

    [SerializeField] private InputActionAsset inputActions;

    public GameObject clickedObject;
    public Vector3 startPosition;

    private Vector3 WorldPos
    {
        get
        {
            return mainCamera.ScreenToWorldPoint(curScreenPos);
        }
    }

    private bool IsClickedOn
    {
        get
        {
            var hits = Physics2D.RaycastAll(WorldPos, Vector2.zero, float.MaxValue);

            if (hits != null && hits.Length > 0)
            {
                RaycastHit2D hit = hits.OrderByDescending(h => h.collider.gameObject).First();
                clickedObject = hit.collider.gameObject;
                startPosition = clickedObject.transform.position;
                return true;

            }
            return false;
        }
    }

    private void Awake()
    {
        mainCamera = Camera.main;
        inputActions.FindAction("Point").performed += context => { curScreenPos = context.ReadValue<Vector2>(); };
        inputActions.FindAction("Click").performed += _ => { if (IsClickedOn) StartCoroutine(Drag()); };
        inputActions.FindAction("Click").canceled += _ => { isDragging = false; };
    }

    private IEnumerator Drag()
    {
        isDragging = true;
        Vector3 offset = clickedObject.transform.position - WorldPos;
        // grab
      
        while (isDragging)
        {
            // dragging
            clickedObject.transform.position = WorldPos + offset;
            yield return null;
        }
        // drop

        clickedObject.transform.position = startPosition;
        clickedObject = null;
        startPosition = Vector3.zero;
    }
}
