using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnTouch : MonoBehaviour {

    public LayerMask touchInputMask;

    private Camera mainCamera;
    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;
    private RaycastHit hit;

    private void Start ()
    {
        mainCamera = GetComponent<Camera>();
	}

    private void Update ()
    {
        ScreenToMouseRay();
	}


    private void ScreenToMouseRay()
    {
    #if UNITY_EDITOR
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) //Check if a UI object was clicked
            {
                Debug.Log("Clicked on the UI");
                return;
            }

            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100, touchInputMask))
            {
                GameObject recipient = hit.transform.gameObject;
                touchList.Add(recipient);

                if (Input.GetMouseButtonDown(0))
                {
                    recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                }

                if (Input.GetMouseButton(0))
                {
                    recipient.SendMessage("OnTouchStationary", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }

            foreach (GameObject o in touchesOld)
            {
                if (!touchList.Contains(o))
                {
                    o.SendMessage("OnTouchCanceled", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        return;
#endif

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                //Check if the mouse hit a UI object
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    Debug.Log("Touched the UI");
                    return;
                }
            }

            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            //Will need to add stuff to prevent menus opening after dragging, solved for mouse

            foreach (Touch touch in Input.touches)
            {
                Ray ray = mainCamera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit, 100, touchInputMask))
                {
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);

                    if (touch.phase == TouchPhase.Began)
                    {
                        recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                    }

                    if (touch.phase == TouchPhase.Ended)
                    {
                        recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                    }

                    if (touch.phase == TouchPhase.Stationary)
                    {
                        recipient.SendMessage("OnTouchStationary", hit.point, SendMessageOptions.DontRequireReceiver);
                    }

                    if (touch.phase == TouchPhase.Moved)
                    {
                        recipient.SendMessage("OnTouchMoved", hit.point, SendMessageOptions.DontRequireReceiver);
                    }

                    if (touch.phase == TouchPhase.Canceled)
                    {
                        recipient.SendMessage("OnTouchCanceled", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }

            foreach (GameObject o in touchesOld)
            {
                if (!touchList.Contains(o))
                {
                    o.SendMessage("OnTouchCanceled", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
