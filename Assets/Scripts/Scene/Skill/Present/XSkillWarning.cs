﻿using System.Collections.Generic;
using UnityEngine;

public class XSkillWarning : XSkill
{

    private List<XFx> list;

    public XSkillWarning(ISkillHoster _host) : base(_host) { }

    public List<Vector3>[] warningPosAt { get; set; }

    public override void Execute()
    {
        base.Execute();

        if (current.Warning != null)
        {
            if (list == null) list = new List<XFx>();
            if (current.Warning.Count > 0)
                warningPosAt = new List<Vector3>[current.Warning.Count];
            for (int i = 0, max = current.Warning.Count; i < max; i++)
            {
                warningPosAt[i] = new List<Vector3>();
                var data = current.Warning[i];
                AddedTimerToken(XTimerMgr.singleton.SetTimer(data.At, OnTrigger, data));
            }
        }
    }

    public override void OnTrigger(object param)
    {
        XWarningData data = param as XWarningData;
        warningPosAt[data.Index].Clear();

        if (data.RandomWarningPos || data.Type == XWarningType.Warning_Multiple)
        {
            if (data.RandomWarningPos)
            {
                List<GameObject> item = new List<GameObject>();
                switch (data.Type)
                {
                    case XWarningType.Warning_All:
                    case XWarningType.Warning_Multiple:
                        IHitHoster[] hits = host.Hits;
                        int n = (data.Type == XWarningType.Warning_All) ? hits.Length : data.MaxRandomTarget;
                        for (int i = 0; i < hits.Length; i++)
                        {
                            bool counted = (data.Type == XWarningType.Warning_All) ? true : IsPickedInRange(n, hits.Length - i);
                            if (counted)
                            {
                                n--;
                                item.Add(hits[i].HitObject);
                            }
                        }
                        break;
                    case XWarningType.Warning_Target:
                        if (host.Target != null) item.Add(host.Target);
                        break;
                }

                for (int i = 0; i < item.Count; i++)
                {
                    for (int n = 0; n < data.PosRandomCount; n++)
                    {
                        int d = Random.Range(0, 360);
                        float r = Random.Range(0, data.PosRandomRange);
                        Vector3 v = r * XCommon.singleton.HorizontalRotateVetor3(Vector3.forward, d);
                        if (!string.IsNullOrEmpty(data.Fx))
                        {
                            var fx = XFxMgr.singleton.CreateAndPlay(
                                     data.Fx,
                                     item[i].gameObject,
                                     new Vector3(v.x, 0.05f - item[i].transform.position.y, v.z),
                                     data.Scale * Vector3.one,
                                     1,
                                     data.FxDuration);
                            list.Add(fx);
                        }
                        warningPosAt[data.Index].Add(item[i].transform.position + v);
                    }
                }
            }
            else if (data.Type == XWarningType.Warning_Multiple)
            {
                IHitHoster[] hits = host.Hits;
                int n = data.MaxRandomTarget;
                for (int i = 0; i < hits.Length; i++)
                {
                    if (IsPickedInRange(n, hits.Length - i))
                    {
                        n--;
                        if (!string.IsNullOrEmpty(data.Fx))
                        {
                            var fx = XFxMgr.singleton.CreateAndPlay(
                                      data.Fx,
                                      hits[i].HitObject,
                                      new Vector3(0, 0.05f - hits[i].Pos.y, 0),
                                      data.Scale * Vector3.one,
                                      1,
                                      data.FxDuration);
                            list.Add(fx);
                        }
                        warningPosAt[data.Index].Add(hits[i].Pos);
                    }
                }
            }
        }
        else
        {
            switch (data.Type)
            {
                case XWarningType.Warning_None:
                    {
                        Vector3 offset = host.Transform.rotation * new Vector3(data.OffsetX, data.OffsetY, data.OffsetZ);
                        var fx = XFxMgr.singleton.CreateAndPlay(
                                data.Fx,
                                host.Transform.gameObject,
                                offset,
                                data.Scale * Vector3.one,
                                1,
                                data.FxDuration);
                        list.Add(fx);
                        warningPosAt[data.Index].Add(host.Transform.position + offset);
                    }
                    break;
                case XWarningType.Warning_Target:
                    if (host.Target != null)
                    {
                        if (!string.IsNullOrEmpty(data.Fx))
                        {
                            var fx = XFxMgr.singleton.CreateAndPlay(
                                     data.Fx,
                                     host.Target.gameObject,
                                     new Vector3(0, 0.05f - host.Target.transform.position.y, 0),
                                     data.Scale * Vector3.one,
                                     1,
                                     data.FxDuration);
                            list.Add(fx);
                        }
                        warningPosAt[data.Index].Add(host.Target.transform.position);
                    }
                    else
                    {
                        Vector3 offset = host.Transform.rotation * new Vector3(data.OffsetX, data.OffsetY, data.OffsetZ);
                        var fx = XFxMgr.singleton.CreateAndPlay(
                                data.Fx,
                                host.Transform.gameObject,
                                offset,
                                data.Scale * Vector3.one,
                                1,
                                data.FxDuration);
                        list.Add(fx);
                        warningPosAt[data.Index].Add(host.Transform.position + offset);
                    }
                    break;
                case XWarningType.Warning_All:
                    IHitHoster[] hits = host.Hits;

                    for (int i = 0; i < hits.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(data.Fx))
                        {
                            XFxMgr.singleton.CreateAndPlay(
                                    data.Fx,
                                    hits[i].HitObject,
                                     new Vector3(0, 0.05f - hits[i].Pos.y, 0),
                                    data.Scale * Vector3.one,
                                    1,
                                    data.FxDuration);
                        }
                        warningPosAt[data.Index].Add(hits[i].Pos);
                    }
                    break;
            }
        }
    }

    public override void Clear()
    {
        if (list != null)
        {
            for (int i = 0, max = list.Count; i < max; i++)
            {
                list[i].DestroyXFx();
            }
            list.Clear();
            warningPosAt = null;
        }
        base.Clear();
    }

    private bool IsPickedInRange(int n, int d)
    {
        if (n >= d) return true;
        int i = Random.Range(0, d);
        return i < n;
    }

}

