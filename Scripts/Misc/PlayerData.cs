using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class PlayerData
{
    private static int _score;

    public static int Score { get => _score; set => _score = value; }
    public static bool IsPointerOverLayer(string layer)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        foreach (RaycastResult raysastResult in raysastResults)
        {
            if (raysastResult.gameObject.layer == LayerMask.NameToLayer(layer))
            {
                return true;
            }
        }
        return false;
    }
}
