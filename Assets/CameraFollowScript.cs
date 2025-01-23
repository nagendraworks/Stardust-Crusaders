using System.Collections;
using UnityEngine;

public class CameraFloowScript : MonoBehaviour
{
    // Camera follow speed
    public float followSpeed = 2f;
    public float yOffset=1f;

    // Target for the camera to follow
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        // Calculate new camera position
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, transform.position.z);

        // Smoothly interpolate the camera's position to the target's position
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
