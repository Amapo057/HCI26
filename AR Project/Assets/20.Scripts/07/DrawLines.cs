using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DrawLines : MonoBehaviour
{
    public LineSettings lineSettings;
    public Camera arCam;

    ARPlaneManager aRPlaneManager;
    bool initialized = false;
    bool canDraw = false;
    bool isStarting = false;
    

    void Awake()
    {
        aRPlaneManager = GetComponent<ARPlaneManager>();
        aRPlaneManager.planesChanged += PlaneChanged;
        
    }

    void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if (!initialized)
        {
            initialized = true;
        }
    }

    public void AllowDraw(bool isAllow)
    {
        if(!initialized) return;
        canDraw = isAllow;
        if(canDraw) isStarting = true;
    }

    void Update()
    {
        DrawLine();
    }

    void DrawLine()
    {
        if(!canDraw) return;
    }
}
