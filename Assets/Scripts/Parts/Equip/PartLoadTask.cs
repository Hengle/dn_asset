﻿using UnityEngine;
using System.Collections.Generic;


public delegate void PartLoadCallback(BaseLoadTask part, bool needCombine);

public class PartLoadTask : BaseLoadTask
{
    public GameObject go = null;
    public Mesh mesh = null;
    public Texture tex = null;
    private PartLoadCallback m_PartLoadCb = null;
    private XEquipComponent m_equip = null;

    public PartLoadTask(EPartType p, XEquipComponent equip, PartLoadCallback partLoadCb)
        : base(p)
    {
        m_PartLoadCb = partLoadCb;
        m_equip = equip;
    }

    public override void Load(ref FashionPositionInfo newFpi, HashSet<string> loadedPath)
    {
        bool same = IsSamePart(ref newFpi);
        if (!same)
        {
            if (MakePath(ref newFpi, loadedPath))
            {
                mesh = XResources.Load<Mesh>(location, AssetType.Asset);
                tex = XResources.Load<Texture>(location, AssetType.TGA);
                if (processStatus == EProcessStatus.EProcessing)
                {
                    processStatus = EProcessStatus.EPreProcess;
                }
            }
        }
        if (m_PartLoadCb != null)
        {
            m_PartLoadCb(this, !same);
        }
    }

    public override void PostLoad()
    {
        base.PostLoad();
        if (m_equip == null || m_equip.skin == null || tex == null) return;
        m_equip.mpb.SetTexture(ShaderMgr.GetPartOffset(part), tex);
        m_equip.skin.SetPropertyBlock(m_equip.mpb);
    }

    public override void Reset()
    {
        base.Reset();
        if (tex != null)
        {
            XResources.SafeDestroy(tex);
            tex = null;
        }
        if (mesh != null)
        {
            XResources.SafeDestroy(mesh);
            mesh = null;
        }
    }

    public bool HasMesh()
    {
        return mesh != null;
    }
    
}
