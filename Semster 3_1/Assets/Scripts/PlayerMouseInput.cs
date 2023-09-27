using UnityEngine;

public class PlayerMouseInput : MonoBehaviour
{
    [SerializeField] private Pawn pawn;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pawn.MoveToPosition(mouseWorldPosition);
        }

        if (Input.GetMouseButton(1))
        {
            pawn.CancelMovement();
        }
    }
}
