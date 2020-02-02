using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Camera Camera;
    public Player Avatar;
    public Bloodbank Bloodbank;

    public ScoreManager ScoreManager;

    public GameEvent Clicked;


    public int QueueSize;
    private Patient _lastPatient;

    private Queue<Command> CommandQueue;

    private InputMaster _inputMaster;

    private Command _currentCommand;

    void Awake() {
        ScoreManager.ResetScore();
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
                _lastPatient = null;
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
        var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, LayerMask.GetMask("Clickable") | LayerMask.GetMask("Both"));

        if (hit.collider != null) {
            Clicked.Raise(this.gameObject);
            var traySpot= hit.collider.gameObject.GetComponent<TraySpot>();
            if (traySpot != null) {
                Debug.Log("Hit item");
                if (CommandQueue.Count < QueueSize) {
                    QueueCommand(new TakeItemCommand(traySpot));
                }
            }

            var patient = hit.collider.gameObject.GetComponent<Patient>();
            if (patient != null) {
                Debug.Log("Hit patient");
                if (CommandQueue.Count < QueueSize && patient != _lastPatient) {
                    _lastPatient = patient;
                    QueueCommand(new GiveItemCommand(patient));
                }
            }

            var bloodBank = hit.collider.gameObject.GetComponent<Bloodbank>();
            if (bloodBank != null) {
                Debug.Log("Hit bloodbank");
                if (CommandQueue.Count < QueueSize) {
                    QueueCommand(new FillBloodBagCommand(Bloodbank));
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

    private void QueueCommand(Command command)
    {
        /*if(CommandQueue.Count == 0 && command != _currentCommand)
        {
            CommandQueue.Enqueue(command);
            Debug.Log(command);
        }

        else if((command.GetType() != _currentCommand.GetType()) )
        {
            
        }*/
        CommandQueue.Enqueue(command);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameOver");
    }

    public void GoToGameOver() {
        StartCoroutine(GameOver());

        
        
    }


    
}