using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;


public class Inventory : MonoBehaviour, IHasChanged {
	[SerializeField] Transform slots;
	
	public List <string> order;

	// Use this for initialization
	void Start () {
		HasChanged ();
	}
    public void reset()
    {
        GameObject instance = Instantiate(Resources.Load("Panel/Toutch", typeof(GameObject))) as GameObject;
    }

    #region IHasChanged implementation
    public void HasChanged ()
	{
		System.Text.StringBuilder builder = new System.Text.StringBuilder();
		builder.Append (" - ");
		order.Clear();
		foreach (Transform slotTransform in slots){
			GameObject item = slotTransform.GetComponent<Slot>().item;
			if (item){
				order.Add(item.name);
			}
			
		}
	}
	#endregion

  
}


namespace UnityEngine.EventSystems {
	public interface IHasChanged : IEventSystemHandler {
		void HasChanged();
	}
}
