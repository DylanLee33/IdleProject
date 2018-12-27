using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoldClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler {

    private bool pointerDown;
    private float pointerDownTimer;
    public float requiredHoldTime;
    public UnityEvent onLongClick;


    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        requiredHoldTime = Random.Range(1.00f, 10.00f);
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
        pointerDownTimer = 0f;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        pointerDown = false;
        pointerDownTimer = 0f;
    }


    private void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                if (onLongClick != null)
                    onLongClick.Invoke();

                pointerDownTimer = 0f;
                requiredHoldTime = Random.Range(1.00f, 10.00f);
            }
        }
    }
}
