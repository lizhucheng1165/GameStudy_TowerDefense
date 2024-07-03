using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventTest : MonoBehaviour
{
    UnityEvent onNomalSelected = new UnityEvent();
    UnityEvent onSpeedSelected = new UnityEvent();
    UnityEvent onSniperSelected = new UnityEvent();

    private void Awake()
    {
        onNomalSelected.AddListener(OnSelectNomal);
        onSpeedSelected.AddListener(OnSelectSpeed);
        onSniperSelected.AddListener(OnSelectSniper);
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    onNomalSelected.Invoke();
        //}
        
    }

    public void OnSelectNomal()
    {
        print("노말선택됨");
    }
    public void OnSelectSpeed()
    {
        print("스피드선택됨");
    }
    public void OnSelectSniper()
    {
        print("스나이퍼선택됨");
    }
    public void OnNomalClicked()
    {
        onNomalSelected.Invoke();
    }

    public void OnSpeedClicked()
    {
        onSpeedSelected.Invoke();
    }
    public void OnSniperClicked()
    {
        onSniperSelected.Invoke();
    }
}
