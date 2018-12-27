using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCameraScript : MonoBehaviour {

    public float panSpeed;
    private Vector3 dragOrigin;
    private Vector3 oldPos;

    public Transform cameraAnchor;

    private void FixedUpdate()
    {
    #if UNITY_EDITOR
        MoveCameraUnity();
        return;
    #endif
        MoveCameraMobile();
    }

    private void MoveCameraUnity()
    {
        //Reduce movement speed if camera is out of bounds, bounce it back on release
        float dist = Vector3.Distance(cameraAnchor.position, transform.position);

        if (dist > 20)
        {
            if (!Input.GetMouseButton(0))
            {
                transform.position = Vector3.Lerp(transform.position, cameraAnchor.position, Time.deltaTime);
                panSpeed = 20f;
                return;
            }

            if (panSpeed > 2f)
            {
                panSpeed -= (dist - 20f) * Time.deltaTime;
            }
        }

        //Move camera if button is held
        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse X") >= 0)
            {
                transform.localPosition -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * panSpeed, 0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * panSpeed);
            }

            if (Input.GetAxis("Mouse X") <= 0)
            {
                transform.localPosition -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * panSpeed, 0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * panSpeed);
            }

            //Bound the camera
            Vector3 clampedPosition = transform.position;
            clampedPosition.y = Mathf.Clamp(transform.position.y, 10f, 10f);
            transform.position = clampedPosition;
        }
    }


    private void MoveCameraMobile()
    {
        //Reduce movement speed if camera is out of bounds, bounce it back on release
        float dist = Vector3.Distance(cameraAnchor.position, transform.position);

        if (dist > 20)
        {
            if (Input.touchCount == 0)
            {
                transform.position = Vector3.Lerp(transform.position, cameraAnchor.position, Time.deltaTime);
                panSpeed = 1f;
                return;
            }

            if (panSpeed > 0.2f)
            {
                panSpeed -= (dist - 20f) * Time.deltaTime;
            }
        }

        //NOTE: Camera movement is very fast on mobile, find a way to reduce its speed
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //Where to moved the camera
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * panSpeed, -touchDeltaPosition.y * panSpeed, 0);

            //Bound the camera
            Vector3 clampedPosition = transform.position;
            clampedPosition.y = Mathf.Clamp(transform.position.y, 15f, 15f);
            transform.position = clampedPosition;
        }
    }
}
