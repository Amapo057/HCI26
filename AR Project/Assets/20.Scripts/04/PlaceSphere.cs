using Unity.VisualScripting;
using UnityEngine;

public class PlaceSphere : MonoBehaviour
{
    public GameObject spherePrefab;
    public Camera arCamera;
    public Transform parentTransform;

    void Update()
    {
        int touchCount = Input.touchCount;
        if(touchCount < 1) return;

        Touch touch = Input.GetTouch(0);

        Vector3 touchPosition = arCamera.ScreenToWorldPoint(
            new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0.5f));
        
        // 터치 시작인지 판단
        if(touch.phase == TouchPhase.Began)
        {
            GameObject go = Instantiate(spherePrefab, touchPosition, transform.rotation);
            go.transform.parent = parentTransform;
            go.transform.position = touchPosition;
        }
    }
}
