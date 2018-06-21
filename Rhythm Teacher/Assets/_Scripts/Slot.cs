using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {

    public GameObject item

    {
        get
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }

            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(!item)
        {
            GameObject replacement = Instantiate(DragHandler.itemBeingDragged);

            replacement.transform.Find("Panel").gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            replacement.transform.Find("Panel").gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);


            replacement.transform.SetParent(transform);

            if(replacement.transform.parent.name == "Left Outer")
            {
                MeasureScript.Count1 = replacement;
            }
            else if(replacement.transform.parent.name == "Left Middle")
            {
                MeasureScript.Count2 = replacement;
            }
            else if (replacement.transform.parent.name == "Right Middle")
            {
                MeasureScript.Count3 = replacement;
            }
            else if (replacement.transform.parent.name == "Right Outer")
            {
                MeasureScript.Count4 = replacement;
            }

        }
    }
}
