using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EasyPosition))]
public class EasyPos : Editor
{

    void OnSceneGUI()
    {
        if (Event.current.control)
        {
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
        }

        EasyPosition decal = (EasyPosition)target;
        if (Event.current.control && Event.current.type == EventType.MouseDown)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 50))
            {
                decal.transform.position = hit.point + new Vector3(decal.OffsetFromNormal.x * hit.normal.x, decal.OffsetFromNormal.y * hit.normal.y, decal.OffsetFromNormal.z * hit.normal.z);
                
                if (decal.EasyPosType == EasyPosType.Forward)
                    decal.transform.forward = -hit.normal;
                if (decal.EasyPosType == EasyPosType.Backward)
                    decal.transform.forward = hit.normal;
                if (decal.EasyPosType == EasyPosType.Up)
                    decal.transform.up = -hit.normal;
                if (decal.EasyPosType == EasyPosType.Down)
                    decal.transform.up = hit.normal;
                if (decal.EasyPosType == EasyPosType.Right)
                    decal.transform.right = -hit.normal;
                if (decal.EasyPosType == EasyPosType.Left)
                    decal.transform.right = hit.normal;
            }
        }
    }
}
