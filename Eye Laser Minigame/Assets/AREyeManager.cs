using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARFace))]
public class AREyeManager : MonoBehaviour
{

    [SerializeField] private GameObject leftEyePrefabs;

    [SerializeField] private GameObject rightEyePrefabs;

    private ARFace arFace;


    private XRFaceSubsystem xRFaceSubsystem;

    private GameObject leftEye, rightEye;
    // Start is called before the first frame update
    void Awake()
    {
        arFace = GetComponent<ARFace>();
    }

    void OnEnable()
    {
        ARFaceManager arFaceManager = FindObjectOfType<ARFaceManager>();

        if (arFaceManager != null && arFaceManager.subsystem != null && arFaceManager.subsystem.subsystemDescriptor.supportsEyeTracking)
        {
            // bind to event
            arFace.updated += ArFace_updated;
            Debug.Log("Eye tracking is supported.");
        } else
        {
            Debug.LogError("Eye tracking is not supported on this device.");
        }
    }
    private void ArFace_updated(ARFaceUpdatedEventArgs obj)
    {
        if (arFace.leftEye!= null && leftEye == null) {
            leftEye = Instantiate(leftEyePrefabs, arFace.leftEye);
            leftEye.name = "LeftEye";
            leftEye.SetActive(false);
        }

        if (arFace.rightEye != null && rightEye == null) {
            rightEye = Instantiate(rightEyePrefabs, arFace.rightEye);
            rightEye.name = "RightEye";
            rightEye.SetActive(false);
        }

        // Don't show eye before ARSession is ready
        if (arFace.trackingState == TrackingState.Tracking && (ARSession.state > ARSessionState.Ready))
        {
            if (leftEye != null) { leftEye.SetActive(true); }
            if (rightEye != null) { rightEye.SetActive(true); }
        }
    }

    private void OnDisable()
    {
        arFace.updated -= ArFace_updated;
        leftEye.SetActive(false);
        rightEye.SetActive(false);
    }
}
