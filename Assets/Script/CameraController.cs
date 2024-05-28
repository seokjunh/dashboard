using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = -1.0f;
    [SerializeField]
    private float dragSpeed = -1f;
    [SerializeField]
    private float scrollSpeed = 300f;

    // Update is called once per frame
    void Update()
    {
        CameraRotate();
        CameraDrag();
        CameraZoom();
    }

    public void CameraRotate()
    {
        if (Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            Vector3 rotateValue = new Vector3(y, x * -1, 0);
            transform.eulerAngles = transform.eulerAngles - rotateValue;
            transform.eulerAngles += rotateValue * rotateSpeed;
        }
    }
    
    public void CameraDrag()
    {
        if (Input.GetMouseButton(0))
        {
            float posX = Input.GetAxis("Mouse X");
            float posZ = Input.GetAxis("Mouse Y");

            Quaternion v3Rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
            transform.position += v3Rotation * new Vector3(posX * dragSpeed, 0, posZ * dragSpeed);
        }
    }

    public void CameraZoom()
    {
        float scroollWheel = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

        Vector3 cameraDirection = transform.localRotation * Vector3.forward;

        transform.position += scrollSpeed * scroollWheel * Time.deltaTime * cameraDirection;

    }
}
