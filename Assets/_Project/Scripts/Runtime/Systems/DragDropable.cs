using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragDropable : MonoBehaviour
{
    [SerializeField] private InputAction press, screenPos;

    private Vector3 curScreenPos;

    private Camera mainCamera;
    private bool isDragging;

    private Vector3 WorldPos
    {
        get
        {
            return mainCamera.ScreenToWorldPoint(curScreenPos);
        }
    }
    private bool isClickedOn
    {
        get
        {
            var hits = Physics2D.RaycastAll(WorldPos, Vector2.zero, float.MaxValue);

       
            if (hits != null && hits.Length > 0)
            {
                RaycastHit2D hit = hits.OrderByDescending(h => h.collider.gameObject).First();
                return hit.collider.gameObject == transform.gameObject;
            }
            return false;
        }
    }
    private void Awake()
    {
        mainCamera = Camera.main;
        screenPos.Enable();
        press.Enable();

        screenPos.performed += context => { curScreenPos = context.ReadValue<Vector2>(); };
        press.performed += _ => { if (isClickedOn) StartCoroutine(Drag()); };
        press.canceled += _ => { isDragging = false; };

    }

    private IEnumerator Drag()
    {
        isDragging = true;
        Vector3 offset = transform.position - WorldPos;
        // grab
      
        while (isDragging)
        {
            // dragging
            transform.position = WorldPos + offset;
            yield return null;
        }
        // drop
      
    }
}
