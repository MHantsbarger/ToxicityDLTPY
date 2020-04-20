using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandClick : MonoBehaviour
{
    public float mouseSensitivity = 10f;
    float xRotation = 0f;
    float yRotation = 0f;
    float cursorSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
   void Update ()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        Debug.Log("X:" + mouseX + " Y:" + mouseY);
        // xRotation -= mouseY;
        // xRotation = Mathf.Clamp(xRotation,-5f,5f);
        // yRotation -= mouseX;
        // yRotation = Mathf.Clamp(yRotation,-5f,5f);
        transform.Translate(mouseX,-1.0f* mouseY,0f);
        var pos = transform.position;
        pos.x =  Mathf.Clamp(transform.position.x, -4.0f, 4.0f);
        pos.y = Mathf.Clamp(transform.position.y, -4.0f, 4.0f);
        pos.z = 2.2f;
        if (Input.GetButton("Fire1")){
            pos.z = 2.5f;
        }
        if (Input.GetButtonDown("Fire1")){
            GetComponent<AudioSource>().Play();
        }
        transform.position = pos;

    }

}
