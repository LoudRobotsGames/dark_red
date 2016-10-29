using UnityEngine;

[ExecuteInEditMode]
public class OrderinLayerSpriteSorting : MonoBehaviour 
{
	
	public int multiplier = 100;
	public float offset = 0.0f;
	void Update ()
	{
		GetComponent<Renderer>().sortingOrder = (int)(transform.localPosition.y * - multiplier - offset);
	}
}