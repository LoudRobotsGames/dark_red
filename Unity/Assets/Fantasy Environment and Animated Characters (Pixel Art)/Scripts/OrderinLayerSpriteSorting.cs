using UnityEngine;

[ExecuteInEditMode]
public class OrderinLayerSpriteSorting : MonoBehaviour
{

    public int multiplier = 100;
    public float offset = 0.0f;
    void Update()
    {
        GetComponent<Renderer>().sortingOrder = (int)(transform.position.y * -multiplier - offset);
    }

    public void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos.x -= GetComponent<Renderer>().bounds.extents.x;
        pos.y += offset / multiplier;
        Gizmos.DrawWireSphere(pos, 0.1f);
    }
}