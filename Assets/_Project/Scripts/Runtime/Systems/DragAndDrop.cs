using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 _curScreenPos;
    private Camera _mainCamera;
    private bool _isDragging;

    [SerializeField] private InputActionAsset _inputActions;
    [SerializeField] private LayerMask _playerCards;

    public GameObject _clickedObject;
    private IInteractiveObject interactiveObject;

    private Vector3 WorldPos
    {
        get
        {
            return _mainCamera.ScreenToWorldPoint(_curScreenPos);
        }
    }

    private bool IsClickedOn
    {
        get
        {
            var hits = Physics2D.RaycastAll(WorldPos, Vector2.zero, float.MaxValue, _playerCards);

            if (hits != null && hits.Length > 0)
            {
                _clickedObject = hits[0].collider.gameObject;
                interactiveObject = _clickedObject.GetComponent<IInteractiveObject>();
                return true;

            }
            return false;
        }
    }


    private void Awake()
    {
        _mainCamera = Camera.main;
        _inputActions.FindAction("Point").performed += context => { _curScreenPos = context.ReadValue<Vector2>(); };
        _inputActions.FindAction("Click").performed += _ => { if (IsClickedOn) StartCoroutine(Drag()); };
        _inputActions.FindAction("Click").canceled += _ => { _isDragging = false; };
    }

    private void OnDisable()
    {
        _inputActions.FindAction("Point").performed -= context => { _curScreenPos = context.ReadValue<Vector2>(); };
        _inputActions.FindAction("Click").performed -= _ => { if (IsClickedOn) StartCoroutine(Drag()); };
        _inputActions.FindAction("Click").canceled -= _ => { _isDragging = false; };
    }

    private IEnumerator Drag()
    {
        _isDragging = true;
        Vector3 offset = _clickedObject.transform.position - WorldPos;
        // grab

        while (_isDragging)
        {
            // dragging
            _clickedObject.transform.position = WorldPos + offset;
            yield return null;
        }
        // drop

        interactiveObject?.Drop(WorldPos);
    }

   
}
