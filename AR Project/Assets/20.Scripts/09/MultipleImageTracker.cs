using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MultipleImageTracker : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;

    public TextMeshProUGUI debugText;
    ARTrackedImageManager imageManager;

    GameObject go1 = null;
    GameObject go2 = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        imageManager = GetComponent<ARTrackedImageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var image in imageManager.trackables)
        {
            debugText.text = $"Tracked : {image.referenceImage.name}";
            if(image.referenceImage.name == "myQR")
            {
                if(go1 == null)
                {
                    go1 = Instantiate(obj1, image.transform.position, image.transform.rotation);
                }
                else
                {
                    go1.transform.position = image.transform.position;
                    go1.transform.rotation = image.transform.rotation;
                }
            }
            else if(image.referenceImage.name == "nameCard")
            {
                if(go2 == null)
                {
                    go2 = Instantiate(obj2, image.transform.position, image.transform.rotation);
                }
                else
                {
                    go2.transform.position = image.transform.position;
                    go2.transform.rotation = image.transform.rotation;
                }
            }
        }
    }
}
