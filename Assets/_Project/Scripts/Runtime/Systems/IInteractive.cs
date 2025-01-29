using UnityEngine;

public interface IInteractiveObject
{
    void MoveToPosition(Vector3 pointClick);

    void Drop(Vector2 pointClick);

}
