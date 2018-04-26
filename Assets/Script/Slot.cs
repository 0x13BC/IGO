using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
				//Debug.Log("Mon Cul");
                return transform.GetChild(0).gameObject;
				
            }
            return null;
        }
    }

    #region IDropHandler implementation
    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
			//Debug.Log("CHild: "+transform.childCount);
            Drag.itemBeingDragged.transform.SetParent(transform);
			ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null,(x,y) => x.HasChanged());
            
        }
    }
    #endregion




}