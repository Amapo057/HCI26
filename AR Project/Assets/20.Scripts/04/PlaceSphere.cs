using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlaceSphere : MonoBehaviour
{
    public GameObject spherePrefab;
    public Camera arCamera;
    public Transform parentTransform;

    void Update()
    {
        // 구버전 인풋 시스템 용
        // int touchCount = Input.touchCount;
        // if(touchCount < 1) return;

        // Touch touch = Input.GetTouch(0);

        // Vector3 touchPosition = arCamera.ScreenToWorldPoint(
        //     new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0.5f));
        
        // // 터치 시작인지 판단
        // if(touch.phase == TouchPhase.Began)
        // {
        //     GameObject go = Instantiate(spherePrefab, touchPosition, transform.rotation);
        //     go.transform.parent = parentTransform;
        //     go.transform.position = touchPosition;
        // }

        if(EventSystem.current.currentSelectedGameObject) return;

        // 새 인풋 시스템용
        var touchScreen = Touchscreen.current;
        if(touchScreen == null) return;

        if(!touchScreen.primaryTouch.press.wasPressedThisFrame) return;

        Vector2 screenPos = touchScreen.primaryTouch.position.ReadValue();

        Vector3 worldPos = arCamera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0.5f));
        GameObject go = Instantiate(spherePrefab, worldPos, Quaternion.identity);
        go.transform.parent = parentTransform;
        GameManager.instance.ShowMessage("Sphere generated.");
    }
}
