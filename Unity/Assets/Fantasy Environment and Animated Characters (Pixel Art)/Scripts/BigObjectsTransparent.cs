using UnityEngine;
using System.Collections;

public class BigObjectsTransparent : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
    private MeshRenderer meshRenderer;
	private Color color;

	void Start ()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            meshRenderer = GetComponentInChildren<MeshRenderer>();
            if (meshRenderer != null)
            {
                if (meshRenderer.sharedMaterial != null)
                {
                    color = meshRenderer.sharedMaterial.GetColor("_Color");
                }
                else
                {
                    color = meshRenderer.material.GetColor("_Color");
                }
            }
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            color = spriteRenderer.color;
            color.a = 1f;
            spriteRenderer.color = color;
        }
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Player" && other.isTrigger == false)
			StartCoroutine ("FadeIn");
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player" && other.isTrigger == false)
			StartCoroutine ("FadeOut");
	}

	
	IEnumerator FadeIn()
	{
		for (float f = 1f; f >= 0.3f; f -= 0.1f) 
		{
            if (spriteRenderer != null)
            {
                spriteRenderer.color = new Color(color.r, color.g, color.b, f);
            }
            else
            {
                if (f != 1.0f && meshRenderer.material.HasProperty("_Color"))
                {
                    meshRenderer.material.SetColor("_Color", new Color(color.r, color.g, color.b, f));
                }
            }
			yield return null;
		}
	}

	IEnumerator FadeOut()
	{
		for (float f = 0.3f; f <= 1.1f; f += 0.1f) 
		{
            if (spriteRenderer != null)
            {
                spriteRenderer.color = new Color(color.r, color.g, color.b, f);
            }
            else
            {
                if (f != 1.0f && meshRenderer.material.HasProperty("_Color"))
                {
                    meshRenderer.material.SetColor("_Color", new Color(color.r, color.g, color.b, f));
                }
            }
            yield return null;
		}
	}
}