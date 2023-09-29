using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private float XMin;
    [SerializeField] private float XMax;
    [SerializeField] private float YMin;
    [SerializeField] private float YMax;
    [SerializeField] private float ZoomMin = 2f;
    [SerializeField] private float ZoomMax = 7f;

    private Vector3 initPos;
    private Vector2 zoomTarget;
    private bool lastFramePinch = false;
    private float initOrtho = 6;  // var for calculation [used in Pinching()]
    private bool _initTouch = false; // if init touch is on UI element


    /// <summary> 
    /// Draw camera boundaries on editor
    /// </summary>
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(XMin, YMin), new Vector3(XMin, YMax));
        Gizmos.DrawLine(new Vector3(XMin, YMax), new Vector3(XMax, YMax));
        Gizmos.DrawLine(new Vector3(XMax, YMax), new Vector3(XMax, YMin));
        Gizmos.DrawLine(new Vector3(XMax, YMin), new Vector3(XMin, YMin));
    }
#endif

    private void Update()
    {
        CheckIfUiHasBeenTouched();

        if (Input.touchCount < 1)
        {
            _initTouch = true;
        }

        if (_initTouch == false)
        {
            Panning();
            Pinching();
        }
        else
        {
            MinOrthoAchievedAnimation();
        }
    }


    /// <summary>
    /// Checks if one of the touches have started on a UI element 
    /// </summary>
    private void CheckIfUiHasBeenTouched()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            bool check = false;

            for (int i = 0; i < Input.touchCount; i++)
            {
                if (EventSystem.current.IsPointerOverGameObject(i)) // implementation for the old input system!!
                {
                    if (EventSystem.current.currentSelectedGameObject != null)
                    {
                        check = true;
                        break;
                    }
                }
            }

            if (check == false)
            {
                _initTouch = false;
            }
        }
    }


    /// <summary>
    /// Panning that is used to move the camera (ignores UI elements)
    /// </summary>
    private void Panning()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            PanningFunction(touchDeltaPosition);
        }
    }


    /// <summary>
    /// Pinching that is used for zooming with 2 or more fingers
    /// </summary>
    private void Pinching()
    {
        if (Input.touchCount > 1)
        {
            //panVelocity = Vector2.zero;

            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            if (!lastFramePinch)
            {
                zoomTarget = MainCamera.ScreenToWorldPoint((touchZero.position + touchOne.position) / 2);
                initPos = MainCamera.transform.position;
                initOrtho = MainCamera.orthographicSize;
            }

            if (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
            {
                float prevDist = Vector2.Distance(touchZero.position - touchZero.deltaPosition, touchOne.position - touchOne.deltaPosition);
                float dist = Vector2.Distance(touchZero.position, touchOne.position);

                PanningFunction((touchZero.deltaPosition + touchOne.deltaPosition) / 40);

                MainCamera.orthographicSize = Mathf.Clamp(MainCamera.orthographicSize * (prevDist / dist), ZoomMin, ZoomMax);

                float t;
                float x = MainCamera.orthographicSize;

                if (initOrtho != ZoomMin)
                {
                    float a = -(1 / ((initOrtho - ZoomMin)));
                    float b = 1 + (ZoomMin / ((initOrtho - ZoomMin)));
                    t = Mathf.Clamp(a * x + b, 0f, 1f);

                    MainCamera.transform.position = Vector3.Lerp(initPos, new Vector3(zoomTarget.x, zoomTarget.y, MainCamera.transform.position.z), t);

                    LimitCameraMovement();
                }
            }

            lastFramePinch = true;
            Vector3 prevTarg = ((touchZero.position - touchZero.deltaPosition) + (touchOne.position - touchOne.deltaPosition)) / 2;
            Vector3 targ = (touchZero.position + touchOne.position) / 2;

            zoomTarget = MainCamera.ScreenToWorldPoint(MainCamera.WorldToScreenPoint(zoomTarget) - (targ - prevTarg));
            initPos = MainCamera.ScreenToWorldPoint(MainCamera.WorldToScreenPoint(initPos) - (targ - prevTarg));
        }
        else
        {
            lastFramePinch = false;
        }
    }


    /// <summary>
    ///  The method for panning the camera with one input deltaPosition
    ///  Has a little bit of lag from transform.Translate;
    /// </summary>
    /// <param name="touchDeltaPosition"> the delta position for movement </param>
    private void PanningFunction(Vector2 touchDeltaPosition)
    {
        Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 1f);
        Vector3 screenTouch = screenCenter + new Vector3(touchDeltaPosition.x, touchDeltaPosition.y, 0f);
        Vector3 worldCenterPosition = MainCamera.ScreenToWorldPoint(screenCenter);
        Vector3 worldTouchPosition = MainCamera.ScreenToWorldPoint(screenTouch);
        Vector3 worldDeltaPosition = worldTouchPosition - worldCenterPosition;
        transform.Translate(-worldDeltaPosition);

        LimitCameraMovement();
    }

    /// <summary>
    /// Camera feedback when achieving minimum ortho
    /// </summary>
    private void MinOrthoAchievedAnimation()
    {
        if (MainCamera.orthographicSize < ZoomMin + 0.6f)
        {
            MainCamera.orthographicSize = ZoomMin + 0.6f;
            MainCamera.orthographicSize = Mathf.Round(MainCamera.orthographicSize * 1000.0f) * 0.001f;
            LimitCameraMovement();
        }
    }

    /// <summary>
    /// Limits Camera Movement into boundaries
    /// </summary>
    private void LimitCameraMovement()
    {
        float xCord = Mathf.Clamp(MainCamera.transform.position.x, XMin + (MainCamera.orthographicSize * MainCamera.aspect), XMax - (MainCamera.orthographicSize * MainCamera.aspect));
        float yCord = Mathf.Clamp(MainCamera.transform.position.y, YMin + MainCamera.orthographicSize, YMax - MainCamera.orthographicSize);

        transform.position = new Vector3(xCord, yCord, -10f);
    }
}
