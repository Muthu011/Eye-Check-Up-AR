using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class SceneController : MonoBehaviour
{
    public static SceneController sceneController;
    public static UserController userController;

    public GameObject appcontroller;
    public GameObject directionArrow;
    public GameObject standPosition;
    public GameObject input;

    public Camera firstPersonCamera;
    public GameObject Room;
    public List<GameObject> RoomStoredForReference=new List<GameObject>();
    public int number;
    TrackableHit hit;
    TrackableHitFlags trackableHitFlags;
    RaycastHit rayHit;


    void Start ()
    {
        sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
        userController = GameObject.Find("AppController").GetComponent<UserController>();
        appcontroller = GameObject.Find("AppController");
        standPosition = Room.transform.GetChild(0).transform.GetChild(4).gameObject; ;
        directionArrow = firstPersonCamera.transform.GetChild(0).gameObject;
        StartCoroutine(PlayerSpawnCheck());
        OnQuitingConnectionErros();

    }
	
	void Update ()
    {
        if (Session.Status != SessionStatus.Tracking)
        {
            int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
            return;
        }
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        ProcessTouches();
        Test();
    }

    public void OnQuitingConnectionErros()
    {
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            StartCoroutine(CodelabUtils.ToastAndExit("Permission needed for openning the app", 5));
        }
        else if (Session.Status.IsError())
        {
            StartCoroutine(CodelabUtils.ToastAndExit("Try ReConnecting", 5));

        }
    }

    void ProcessTouches()
    {
        Touch touch;
        if (Input.touchCount != 1 ||
            (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        TrackableHitFlags raycastFilter =
            TrackableHitFlags.PlaneWithinBounds |
            TrackableHitFlags.PlaneWithinPolygon;

        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            SetSelectedPlane(hit.Trackable as DetectedPlane);
            SpawnObject();
        }
    }

    void SetSelectedPlane(DetectedPlane selectedPlane)
    {
        Debug.Log("Selected plane centered at " + selectedPlane.CenterPose.position);
    }

    public void SpawnObject()
    {

        if (number==0)
        {
            var temp = Instantiate(Room.transform, hit.Pose.position, hit.Pose.rotation);
            temp.transform.Rotate(0, 0, 0, Space.Self);
            var anchor = hit.Trackable.CreateAnchor(hit.Pose);
            temp.transform.parent = anchor.transform;
            RoomStoredForReference.Add(temp.gameObject);
            number++;
        }

    }

    public IEnumerator PlayerSpawnCheck()
    {
        yield return new WaitForSeconds(3f);

        if (RoomStoredForReference != null)
        {
            float dist = Vector3.Distance(firstPersonCamera.transform.position,standPosition.transform.position);
            if (dist < 5)
            {
                appcontroller.SetActive(true);

            }
            else
            {
               /// appcontroller.SetActive(false);
            }
        }
        StartCoroutine(PlayerSpawnCheck());

    }

    public void Test()
    {
        //if (Frame.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out hit, 3f, trackableHitFlags))
        //{
            if (Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out rayHit, 3f))
            {
                Debug.DrawRay(firstPersonCamera.transform.position, firstPersonCamera.transform.forward*rayHit.distance,Color.blue);
                if (rayHit.collider.tag == "PlayerPosition")
                {
                    userController.inputController.DrawMenu();
                userController.MessageDisplay.text = "rAY HITTING DISPLAYING" ;
                }
            }

        //}

    }

    public void OnPlayerStand()
    {


    }

}
