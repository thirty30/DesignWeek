using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPreLoadPool : CSingleton<TPreLoadPool>
{
    private Dictionary<string, GameObject> mDic = new Dictionary<string, GameObject>();

    public void LoadPrefabsToMemory(string a_strPath)
    {
        GameObject[] objs = Resources.LoadAll<GameObject>(a_strPath);
        for(int i = 0; i < objs.Length; i++)
        {
            this.mDic.Add(objs[i].name, objs[i]);
        }
    }

    public void LoadPrefabToMemory(string a_strPath)
    {
        GameObject obj = Resources.Load<GameObject>(a_strPath);
        if (obj == null)
        {
            return;
        }
        this.mDic.Add(obj.name, obj);
    }

    public GameObject InitializeGameObject(string a_strName)
    {
        if (this.mDic.ContainsKey(a_strName) == false)
        {
            this.LoadPrefabToMemory(a_strName);
        }
        if (this.mDic.ContainsKey(a_strName) == false)
        {
            return null;
        }
        return GameObject.Instantiate(this.mDic[a_strName]);
    }

    public GameObject InitializeEffect(string a_strName)
    {
        if (this.mDic.ContainsKey(a_strName) == false)
        {
            this.LoadPrefabToMemory(a_strName);
        }
        if (this.mDic.ContainsKey(a_strName) == false)
        {
            return null;
        }
        GameObject go = GameObject.Instantiate(this.mDic[a_strName]);
        go.AddComponent<ParticleAutoDestroy>();
        return go;
    }

    public void ClearPool()
    {
        this.mDic.Clear();
    }
}
