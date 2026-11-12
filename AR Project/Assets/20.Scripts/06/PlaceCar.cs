using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceCar : MonoBehaviour
{
    public GameObject marker;
    ARRaycastManager arRayManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arRayManager = GetComponent<ARRaycastManager>();
        marker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DetectGround();
    }

    void DetectGround()
    {
        Vector2 screenCenter = new Vector2(Screen.width/2, Screen.height/2);

        // ar plane에서 하나의 면으로 깔끔하게 나오지 않을 수 있기 때문에 중첩된 면을 처리하기위해 리스트로 충돌 처리
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if(arRayManager.Raycast(screenCenter, hits, TrackableType.Planes))
        {
            marker.SetActive(true);
            marker.transform.position = hits[0].pose.position;
        }
    }
}
