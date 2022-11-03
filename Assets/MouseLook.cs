using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sense = 100f;

    public Transform playerBody;

    float xRot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * sense * Time.deltaTime;

        float y = Input.GetAxis("Mouse Y") * sense * Time.deltaTime;

        xRot -= y;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0, 0);

        playerBody.Rotate(Vector3.up * x);
        
    }
}
