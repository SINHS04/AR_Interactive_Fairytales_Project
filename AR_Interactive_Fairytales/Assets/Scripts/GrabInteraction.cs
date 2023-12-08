using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabInteraction : MonoBehaviour
{
    [SerializeField] private GameObject handPointer;
    private float skeletonConfience = 0.0001f;


    // Update is called once per frame
    void Update()
    {
        bool hasConfience = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.skeleton.confidence > skeletonConfience;

        if (hasConfience)
        {
            var palmCenter = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.palm_center;

            var depthEstimation = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.depth_estimation;

            Vector3 positionPointer = ManoUtils.Instance.CalculateNewPositionDepth(palmCenter, depthEstimation*25);

            handPointer.transform.position = positionPointer;
            handPointer.SetActive(true);
        }

        else
        {
            handPointer.transform.DetachChildren();
            handPointer.SetActive(false);


        }
    }
}
