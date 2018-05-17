using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class ToolTip : MonoBehaviour
{
    public RectTransform toolTip;
    public Vector3 offSet;
    public RectTransform Canvas;
    public Camera cam;

    void Update()
    {
        PanelFollow();        
    }

    public void PanelFollow()
    {
        Vector3 pos = Input.mousePosition + offSet;
        pos.z = Canvas.position.z;
        toolTip.position = cam.ScreenToWorldPoint(pos);
    }
}

