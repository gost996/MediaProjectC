using Invector;
using Invector.vCamera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvertCameraView : MonoBehaviour
{
    public vThirdPersonCamera vCam;
    public vThirdPersonCameraState vCamStates;

    public float FDDistance;
    public float FDHeight;
    public float FADistance;
    public float FAHeight;

    Text currentModeText;

    private void Start()
    {
        vCamStates = vCam.CameraStateList.tpCameraStates.Find(delegate (vThirdPersonCameraState obj) { return obj.Name.Equals("Default");});
        currentModeText = GetComponentInChildren<Text>();
    }
    public void ConvertCameraMode()
    {
        if(vCamStates.cameraMode == TPCameraMode.FixedAngle)
        {
            vCamStates.cameraMode = TPCameraMode.FreeDirectional;
            vCamStates.defaultDistance = FDDistance;
            vCamStates.height = FDHeight;
            currentModeText.text = vCamStates.cameraMode.ToString();
        }
        else if(vCamStates.cameraMode == TPCameraMode.FreeDirectional)
        {
            vCamStates.cameraMode = TPCameraMode.FixedAngle;
            vCamStates.defaultDistance = FADistance;
            vCamStates.height = FAHeight;
            currentModeText.text = vCamStates.cameraMode.ToString();
        }
    }
}
