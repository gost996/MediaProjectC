using Invector;
using Invector.vCamera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvertCameraView : MonoBehaviour
{
    [Header("QuarterView Camera")]
    public vThirdPersonCamera QuarterViewViewCam;
    public float QV_Distance;
    public float QV_Height;

    private vThirdPersonCameraState camStates;

    [Header("ShoulderView Camera")]
    public Camera ShoulderViewViewCam;
    public float SV_x;
    public float SV_y;
    public float SV_z;

    private bool isQuarterView = true;

    Text currentModeText;

    private void Start()
    {
        camStates = QuarterViewViewCam.CameraStateList.tpCameraStates.Find(delegate (vThirdPersonCameraState obj) { return obj.Name.Equals("Default");});
        camStates.defaultDistance = QV_Distance;
        camStates.height = QV_Height;

        ShoulderViewViewCam.transform.position = new Vector3(SV_x, SV_y, SV_z);

        currentModeText = GetComponentInChildren<Text>();

        QuarterViewViewCam.gameObject.SetActive(isQuarterView);
        ShoulderViewViewCam.gameObject.SetActive(!isQuarterView);

        currentModeText.text = "Quarter View";
    }
    public void ConvertCameraMode()
    {
        isQuarterView = !isQuarterView;

        if(isQuarterView) currentModeText.text = "Quarter View";
        else currentModeText.text = "Shoulder View";

        QuarterViewViewCam.gameObject.SetActive(isQuarterView);
        ShoulderViewViewCam.gameObject.SetActive(!isQuarterView);
    }
}
