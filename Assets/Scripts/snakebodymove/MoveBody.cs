using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class MoveBody : MonoBehaviour {

    private CharacterController _controller;

    public float targetDistance;

    private float startPositionX = -2.5f;
    private float startPositionZ = 80.0f;
    
    private int currentRotation = 0;

    public void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    public void Update()
    {
        if (SingletonGame.Instance.AllPointsList == null)
            return;
        else
        {
            currentRotation = SingletonGame.Instance.AllPointsList[0].rotation;
            startPositionX = SingletonGame.Instance.AllPointsList[0].startPositionX;
            startPositionZ = SingletonGame.Instance.AllPointsList[0].startPositionZ;
        }

        MoveAndRotate();
    }

    public void MoveAndRotate()
    {
        if ((currentRotation == 0 && startPositionZ - 0.5f < transform.position.z) ||
           (currentRotation == 180 && startPositionZ + 0.5f > transform.position.z))
        {
            transform.position = new Vector3(startPositionX, -1, startPositionZ);
            transform.localEulerAngles = new Vector3(0, currentRotation, 0);
            Debug.Log("1");
        }
        else if ((currentRotation == 90 && startPositionX - 0.5f < transform.position.x) ||
                (currentRotation == 270 && startPositionX + 0.5f > transform.position.x))
        {
            transform.position = new Vector3(startPositionX, -1, startPositionZ);
            transform.localEulerAngles = new Vector3(0, currentRotation, 0);
            Debug.Log("2");
        }
        else
        {
            Debug.Log("3");
            _controller.Move(transform.forward * Game.Instance._currentSpeed * Time.deltaTime);
        }
            
    }

}
