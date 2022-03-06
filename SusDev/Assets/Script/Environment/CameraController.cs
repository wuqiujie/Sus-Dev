using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector3 zoomAmount;
    public float zoomTime;

    public float movementSpeed;
    public float movementTime;

    public Vector3 newPos;
    public Vector3 newZoom;
    // Start is called before the first frame update
    void Start()
    {
        newPos = transform.position;
        newZoom = cameraTransform.localPosition;
        zoomAmount = new Vector3(0f,1f,-1f);
        movementSpeed = 0.2f;
        zoomTime = 2f;
        movementTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
    }

    public void HandleMovementInput()
    {
        //translate
        if (Input.GetKey(KeyCode.W))
        {
            newPos += (transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPos += (transform.forward * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPos += (transform.right * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPos += (transform.right * movementSpeed);
        }
        //zoom
        if(Input.GetAxis("Mouse ScrollWheel") > 0 && cameraTransform.localPosition.y < 100)
        {
            newZoom += zoomAmount;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && cameraTransform.localPosition.y > 0)
        {
            newZoom -= zoomAmount;
        }
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * zoomTime);
    }
}
