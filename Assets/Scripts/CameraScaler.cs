using UnityEngine;

using UnityEngine;

[ExecuteAlways]
public class CameraScaler : MonoBehaviour
{
    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        AdjustCameraSize();
    }

    void Update()
    {
        // Optional: keep updating when resizing game window in editor
        if (Application.isEditor)
            AdjustCameraSize();
    }

    private void AdjustCameraSize()
    {

        float aspect = (float)Screen.width / Screen.height;

        //Debug.Log(Screen.width);
        //Debug.Log(aspect);

        /* Aspect Ratio Notes 
            1.77 => 8   //Typical Desktop
            0.75 => 10     //ipad
            0.56 => 11     //iphone se
            0.462 => 13     //iphone
            0.473 => 13   //Samsung Galaxy S10e
            0.36 => 15    //Samsung Galaxy Z Fold2
         */

        if (aspect <= 0.35)
        {
            cam.orthographicSize = 15f;
        }
        else if (aspect <= 0.5)
        {
            cam.orthographicSize = 13f;
        }
        else if (aspect <= 0.6)
        {
            cam.orthographicSize = 11f;
        }
        else if (aspect <= 0.76)
        {
            cam.orthographicSize = 10f;
        }
        else if (aspect <= 0.99)
        {
            cam.orthographicSize = 9f;
        }
        else
        {
            cam.orthographicSize = 8f;
        }

    }
}

