using UnityEngine;
using UnityEngine.InputSystem;

public class Highlighter : MonoBehaviour
{
    public Camera Camera;

    public float NoHightlightThickness;
    public float HighlightThickness;

    private Vector2 _mousePos;

    private SpriteRenderer _lastHit;
    

    void Update() {
        var ray = Camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        Debug.Log(_lastHit?.material.shader.GetPropertyName(2));
        if (hit.collider != null) {
            if (_lastHit != null) {
                if (_lastHit.gameObject != hit.collider.gameObject) {
                    _lastHit.material.SetFloat("_OutlineThickness", NoHightlightThickness);
                }
            }

            _lastHit = hit.collider.gameObject.GetComponent<SpriteRenderer>();
            _lastHit.material.SetFloat("_OutlineThickness", HighlightThickness);

        } else if (_lastHit != null) {
            _lastHit.material.SetFloat("_OutlineThickness", NoHightlightThickness);
            _lastHit = null;
        }
    }
}