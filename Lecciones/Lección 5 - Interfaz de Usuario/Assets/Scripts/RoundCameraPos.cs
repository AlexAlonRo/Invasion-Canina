using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class RoundCameraPos : CinemachineExtension
{
    public float PixelsPerUnit = 32;
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, 
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(stage == CinemachineCore.Stage.Body)
        {
            Vector3 pos = state.FinalPosition;
            Vector3 pos2 = new Vector3(Round(pos.x),Round(pos.y),pos.z);
            state.PositionCorrection += pos2 - pos;
        }
    }

    private float Round(float x)
    {
        return Mathf.Round(x*PixelsPerUnit)/PixelsPerUnit;
    }
}
