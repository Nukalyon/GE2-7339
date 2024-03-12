using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WaypointGizmo))]
public class WaypointInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        WaypointGizmo waypointGizmo = (WaypointGizmo)target;

        if (GUILayout.Button("Set waypoint a sol"))
        {
            Ray ray = new Ray(waypointGizmo.transform.position, Vector3.down);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                waypointGizmo.transform.position = hit.point + Vector3.up;
            }
        }
    }
}
