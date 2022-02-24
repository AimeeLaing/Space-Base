using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerlook : MonoBehaviour
{

    public float mouseX;
    public float mouseY;

    public Transform playerBody;
    public float lookSensitivity = 200f;
    // Start is called before the first frame update

    float xRotate = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;

        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);

        playerBody.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);

    }
}
