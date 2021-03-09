using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AtlasManager : CSingleton<AtlasManager>
{
    private Dictionary<string, SpriteAtlas> mDicAtlas = new Dictionary<string, SpriteAtlas>();

    public void LoadAtlas(string aAtlasDir, string aAtlasName)
    {
        if (this.mDicAtlas.ContainsKey(aAtlasName) == true)
        {
            Debug.LogError("Load the same atlas!!");
            return;
        }
        SpriteAtlas atlas = Resources.Load<SpriteAtlas>(aAtlasDir + aAtlasName);
        this.mDicAtlas.Add(aAtlasName, atlas);
    }

    public Sprite GetSprite(string aAtlasName, string aSpriteName)
    {
        if (this.mDicAtlas.ContainsKey(aAtlasName) == false)
        {
            return null;
        }
        SpriteAtlas atlas = this.mDicAtlas[aAtlasName];
        return atlas.GetSprite(aSpriteName);
    }
}
