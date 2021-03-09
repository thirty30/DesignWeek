using UnityEngine;
using System;
using System.Collections.Generic;

public class GlobalEvent
{
    public delegate void Callback(params object[] args);
    private class ZEventData
    {
        public Callback m_callback;
        public bool m_bOnce = false;
    }
    private static Dictionary<Enum, List<ZEventData>> dicGlobalEvent = new Dictionary<Enum, List<ZEventData>>();

    private static void AddEvent(Enum _em, ZEventData _zed)
    {
        if (dicGlobalEvent.ContainsKey(_em))
            dicGlobalEvent[_em].Add(_zed);
        else
        {
            List<ZEventData> list = new List<ZEventData>();
            list.Add(_zed);
            dicGlobalEvent.Add(_em, list);
        }
    }

    public static void Add(Enum _em, Callback _cb)
    {
        ZEventData zed = new ZEventData();
        zed.m_callback += _cb;
        zed.m_bOnce = false;
        AddEvent(_em, zed);
    }

    public static void AddOneShot(Enum _em, Callback _cb)
    {
        ZEventData zed = new ZEventData();
        zed.m_callback += _cb;
        zed.m_bOnce = true;
        AddEvent(_em, zed);
    }

    public static void RemoveEvent(Enum _em)
    {
        if (dicGlobalEvent.ContainsKey(_em))
        {
            dicGlobalEvent[_em].Clear();
            dicGlobalEvent.Remove(_em);
        }
    }

    public static void RemoveEvent(Enum _em, Callback _cb)
    {
        if (dicGlobalEvent.ContainsKey(_em))
        {
            foreach (ZEventData zed in dicGlobalEvent[_em])
            {
                if (zed.m_callback.Equals(_cb))
                {
                    dicGlobalEvent[_em].Remove(zed);
                    break;
                }
            }
            if (dicGlobalEvent[_em].Count <= 0)
                dicGlobalEvent.Remove(_em);
        }
    }

    public static void Dispatch(Enum _em, params object[] args)
    {
        if (dicGlobalEvent.ContainsKey(_em))
        {
            List<ZEventData> list = dicGlobalEvent[_em];
            List<ZEventData> removeList = new List<ZEventData>();
            for (int i = 0, max = list.Count; i < max; ++i)
            {
                if (list[i].m_bOnce)
                    removeList.Add(list[i]);
                list[i].m_callback(args);
            }
            for (int i = 0, max = removeList.Count; i < max; ++i)
            {
                list.Remove(removeList[i]);
            }
            if (list.Count <= 0)
                dicGlobalEvent.Remove(_em);
        }
    }
}
