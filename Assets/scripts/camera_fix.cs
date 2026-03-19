using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public float baseOrthographicSize = 5f; // reference size (portrait)

    void Start()
    {
        AdjustCamera();
    }

    void Update()
    {
        AdjustCamera(); // handles rotation live
    }

    void AdjustCamera()
    {
        float targetAspect = 9f / 16f; // portrait reference
        float currentAspect = (float)Screen.width / Screen.height;

        if (currentAspect > targetAspect)
        {
            // Landscape → zoom out
            Camera.main.orthographicSize = baseOrthographicSize * (currentAspect / targetAspect);
        }
        else
        {
            // Portrait → normal
            Camera.main.orthographicSize = baseOrthographicSize;
        }
    }
}