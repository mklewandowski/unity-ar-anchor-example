using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class ARManager : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera = null;
    [SerializeField]
    private ARAnchorManager anchorManager = null;
    [SerializeField]
    private TextMeshProUGUI DebugText;
    [SerializeField]
    private bool AddOnTouch;
    [SerializeField]
    GameObject ObjectToPlace;

    private ARPlaneManager arPlaneManager = null;

    private bool Initialized { get; set; }

    private float distanceFromCamera = .3f;

    private List<GameObject> placedPlanets = new List<GameObject>();

    void Awake()
    {
        arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += PlanesChanged;
    }

    void Update ()
    {
        DrawOnTouch();
	}

    void DrawOnTouch()
    {
        if (!Initialized || !AddOnTouch) return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = arCamera.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, distanceFromCamera));
            ARAnchor anchor = anchorManager.AddAnchor(new Pose(touchPosition, Quaternion.identity));

            GameObject go = GameObject.Instantiate(ObjectToPlace);
            go.transform.localScale = new Vector3(.00025f, .00025f, .00025f);
            go.transform.parent = anchor.transform;
            go.transform.position = touchPosition;
            placedPlanets.Add(go);
        }
    }

    void PlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (!Initialized)
        {
            Activate();
        }
    }

    private void Activate()
    {
        DebugText.text = "tap screen to place planet";
        Initialized = true;
        arPlaneManager.enabled = false;
    }

    public void Reset()
    {
        DebugText.text = "move camera to detect planes";
        Initialized = false;
        arPlaneManager.enabled = true;
        for (int x = 0; x < placedPlanets.Count; x++)
        {
            Destroy(placedPlanets[x]);
        }
        placedPlanets.Clear();
    }
}
