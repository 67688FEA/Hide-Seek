using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class TransferGizmo {

    static GUIStyle sceneNote;

    static TransferGizmo()
    {
        sceneNote = new GUIStyle("box");
        sceneNote.fontStyle = FontStyle.Bold;
        sceneNote.normal.textColor = Color.white;
        sceneNote.margin = sceneNote.overflow = sceneNote.padding = new RectOffset(3, 3, 3, 3);
        sceneNote.richText = true;
        sceneNote.alignment = TextAnchor.MiddleCenter;
    }

    static void DrawNote(Vector3 position,string text,string warning="",float distance=10)
    {
        if (!string.IsNullOrEmpty(warning))
        {
            text = text + "<color=red>" + warning + "</color>";
        }
        if ((Camera.current.transform.position - position).magnitude <= distance)
        {
            Handles.Label(position, text, sceneNote);
        }
    }

    [DrawGizmo(GizmoType.InSelectionHierarchy|GizmoType.NotInSelectionHierarchy,typeof(TransferController))]
    static void DrawTransferGizmos(TransferController transfer,GizmoType gizmoType)
    {
        if (transfer.destination)
        {
            DrawNote(transfer.transform.position, "Transfer Enter");
            Handles.color = Color.green * 0.5f;
            Handles.DrawDottedLine(transfer.transform.position, transfer.destination.position, 5);
            DrawNote(transfer.destination.position, "Teleport Exit");
        }
        else
        {
            DrawNote(transfer.transform.position, "Transfer Enter", "(No Destination!)");
        }
    }

}
