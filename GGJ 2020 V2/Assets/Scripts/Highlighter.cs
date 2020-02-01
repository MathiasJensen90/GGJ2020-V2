using UnityEngine;

public class Highlighter : MonoBehaviour
{
    public Camera Camera;

    private Vector2 _mousePos;

    private SpriteRenderer _lastHit;
    

    void Update() {
        var ray = Camera.ScreenPointToRay(Mouse.current.position.ReadValue(), Vector2.zero);
        var hit = Physics2D.Raycast(ray.direction, Vector2.zero);

        if (hit.collider != null) {
            if (_lastHit != null) {
                if (_lastHit.gameObject != hit.collider.gameObject) {

                }
            }
        }
    }
}