using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Camera Camera;
    public Player Avatar;
    public Bloodbank Bloodbank;

    public int QueueSize;

    private Queue<Command> CommandQueue;

    private InputMaster _inputMaster;

    private Command _currentCommand;

    void Awake() {
        _inputMaster = new InputMaster();

        _inputMaster.Core.Select.performed += context => {
            Select(Mouse.current.position.ReadValue());
        };

        CommandQueue = new Queue<Command>(QueueSize);
    }

    void Update() {
        if (_currentCommand != null) {
            if (_currentCommand.IsDone) {
                _currentCommand = null;
            }
        } else {
            if (CommandQueue.Count > 0) {
                _currentCommand = CommandQueue.Dequeue();
                this.StartCoroutine(_currentCommand.ExecuteCommand(Avatar));
            }
        }
    }

    public void Select(Vector2 screenPos) {
        var ray = Camera.ScreenPointToRay(screenPos);
        var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider != null) {
            var item = hit.collider.gameObject.GetComponent<Item>();
            if (item != null) {
                Debug.Log("Hit item");
                if (CommandQueue.Count < QueueSize) {
                    CommandQueue.Enqueue(new TakeItemCommand(item));
                }
            }

            var patient = hit.collider.gameObject.GetComponent<Patient>();
            if (patient != null) {
                Debug.Log("Hit patient");
                if (CommandQueue.Count < QueueSize) {
                    CommandQueue.Enqueue(new GiveItemCommand(patient));
                }
            }

            var bloodBank = hit.collider.gameObject.GetComponent<Bloodbank>();
            if (bloodBank != null) {
                Debug.Log("Hit bloodbank");
                if (CommandQueue.Count < QueueSize) {
                    CommandQueue.Enqueue(new FillBloodBagCommand(Bloodbank));
                }
            }
        }
    }

    private void OnEnable() {
        _inputMaster.Enable();
    }

    private void OnDisable() {
        _inputMaster.Disable();
    }
}