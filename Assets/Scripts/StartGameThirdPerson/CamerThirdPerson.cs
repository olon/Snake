using UnityEngine;

public class CamerThirdPerson : MonoBehaviour {

    public GameObject target;
    public float smooth;
    public float yoffset;

    void LateUpdate()
    {

        SmoothFallow(target, yoffset);

        SmoothLookAt(target.transform.position, smooth);
    }

    void SmoothFallow(GameObject target, float yOffset)
    {
        Vector3 targetPosition = (new Vector3(target.transform.position.x, target.transform.position.y + yOffset, target.transform.position.z)) + (target.transform.forward * (-1f));

        float distance = Vector3.Distance(transform.position, targetPosition);

        if (distance > 0f)
        {
            float fallowSpeed;

            if (distance >= 1f) fallowSpeed = Mathf.Pow(distance, 2);
            else if (distance >= 0.5f) fallowSpeed = distance * 1.3f;
            else fallowSpeed = 0.7f;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * fallowSpeed);
        }
    }

    void SmoothLookAt(Vector3 target, float smooth)
    {
        Vector3 dir = target - transform.position;
        dir = new Vector3(dir.x, 0, dir.z);
        transform.forward = Vector3.Slerp(transform.forward, dir, Time.deltaTime * smooth);
    }
}
