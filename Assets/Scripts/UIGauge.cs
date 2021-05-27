using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGauge : MonoBehaviour
{
   public GameObject Axis;
     public void ResetGaugeRot()
    {
        Axis.GetComponent<RectTransform>().Rotate(0,0,-Axis.GetComponent<RectTransform>().eulerAngles.z);
    }

}
