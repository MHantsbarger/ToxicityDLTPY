using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMvmt : MonoBehaviour
{
    public float mouseSensitivity = 10f;
    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
   void Update ()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-5f,5f);
        yRotation -= mouseX;
        yRotation = Mathf.Clamp(yRotation,-5f,5f);
        transform.localRotation = Quaternion.Euler(-1.0F*xRotation,yRotation,0f);
    }
}
