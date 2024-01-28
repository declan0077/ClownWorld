using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogQuit : MonoBehaviour
{
    public UnityEvent m_MyEvent;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_MyEvent.Invoke();
        }
    }
}
