using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class MoveBody : MonoBehaviour {

    public Transform target;
    private CharacterController _controller;

    public float targetDistance;

    private float startPositionZ;
    private float startPositionX;

    private float lastStartPositionZ;
    private float lastStartPositionX;

    private int currentRotation = 0;

    public void Start()
    {
        _controller = GetComponent<CharacterController>();
        startPositionX = target.transform.position.x;
        startPositionZ = target.transform.position.z;
    }

    public void Update()
    {
        currentRotation = Mathf.RoundToInt(target.localEulerAngles.y);



        //if (startPositionX != lastStartPositionX) ;
       // if (startPositionZ != lastStartPositionZ) ;

        MoveAndRotate();
    }

    public void MoveAndRotate()
    {
        if ((currentRotation == 0 && startPositionZ - 0.5f < transform.position.z) ||
           (currentRotation == 180 && startPositionZ + 0.5f > transform.position.z))
        {
            transform.position = new Vector3(startPositionX, -1, startPositionZ);
            transform.localEulerAngles = new Vector3(0, currentRotation, 0);
        }
        else if ((currentRotation == 90 && startPositionX - 0.5f < transform.position.x) ||
                (currentRotation == 270 && startPositionX + 0.5f > transform.position.x))
        {
            transform.position = new Vector3(startPositionX, -1, startPositionZ);
            transform.localEulerAngles = new Vector3(0, currentRotation, 0);
        }

        _controller.Move(transform.forward * Game.Instance._currentSpeed * Time.deltaTime);
    }

}
