using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

[Tiled2Unity.CustomTiledImporter]
class PrefabReplacementImporter : Tiled2Unity.ICustomTiledImporter
{
    public void HandleCustomProperties(UnityEngine.GameObject gameObject,
       IDictionary<string, string> props)
    {
        if (props.ContainsKey("prefab"))
        {
            string prefab = props["prefab"];
            string path = "Assets/Prefabs/" + prefab + ".prefab";
            UnityEngine.Object asset = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
            if (asset != null && asset is GameObject)
            {
                RemoveChildren(gameObject.transform);
                GameObject go = GameObject.Instantiate<GameObject>(asset as GameObject);
                go.name = prefab;
                go.transform.parent = gameObject.transform;
                go.transform.localPosition = new Vector3(0, 1, 0);
            }
        }
    }

    public void CustomizePrefab(GameObject prefab)
    {
    }

    void RemoveChildren(Transform transform)
    {
        int childCount = transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            Transform child = transform.GetChild(i);
            GameObject.DestroyImmediate(child.gameObject);
        }
    }
}
