using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public Transform cameraTransform;       // Reference to the camera transform
    public float parallaxSpeed = 0.5f;      // Speed multiplier for this layer (0=static, 1=follow camera)

    private Vector3 initialPosition;        // Starting position of the layer
    private Vector3 previousCameraPosition; // Camera position in previous frame

    void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform; // Automatically assign main camera if none assigned

        initialPosition = transform.position;
        previousCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - previousCameraPosition;

        // Move the layer by the delta movement times the parallax speed
        transform.position += new Vector3(deltaMovement.x * parallaxSpeed, 0, 0);

        previousCameraPosition = cameraTransform.position;
    }
}
