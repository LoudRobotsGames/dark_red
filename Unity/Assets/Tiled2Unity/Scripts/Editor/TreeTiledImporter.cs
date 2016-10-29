using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Tiled2Unity.CustomTiledImporter]
class TreeTiledImporter : Tiled2Unity.ICustomTiledImporter
{
    public void HandleCustomProperties(UnityEngine.GameObject gameObject,
       IDictionary<string, string> props)
    {
        // Simply add a component to our GameObject
        if (props.ContainsKey("isTree"))
        {
            Collider2D[] colliders = gameObject.GetComponentsInChildren<Collider2D>();

            // Find and convert a polygon collider to a box collider
            foreach(Collider2D collider in colliders)
            {
                if (collider is PolygonCollider2D)
                {
                    PolygonCollider2D poly = collider as PolygonCollider2D;
                    if( poly.pathCount == 1 )
                    {
                        Vector2[] path = poly.GetPath(0);
                        if (path.Length == 4)
                        {
                            GameObject go = poly.gameObject;
                            Bounds bounds = poly.bounds;
                            Vector2 offset = poly.offset;
                            GameObject.DestroyImmediate(poly);
                            BoxCollider2D box = go.AddComponent<BoxCollider2D>();
                            box.size = new Vector2(bounds.size.x, bounds.size.y);
                            box.offset = offset + new Vector2(bounds.extents.x, -bounds.extents.y);
                            box.isTrigger = true;

                            go.AddComponent<BigObjectsTransparent>();
                        }
                    }
                    break;
                }
            }
        }
    }

    public void CustomizePrefab(GameObject prefab)
    {
        // Do nothing
    }
}