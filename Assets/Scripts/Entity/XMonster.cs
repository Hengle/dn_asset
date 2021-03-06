﻿using UnityEngine;


public class XMonster : XEntity
{
    private int hitCnt = 0;
    private int maxHit = 4;

    public override void OnInitial()
    {
        _eEntity_Type |= EntityType.Monster;
        base.OnInitial();
        _layer = LayerMask.NameToLayer("Enemy");
        _speed = 0.001f;

        AttachComponent<XAIComponent>();
        AttachComponent<XNavComponent>();
        AttachComponent<XSkillComponent>();
        AttachComponent<XBeHitComponent>();
    }    
    
    protected override void InitAnim()
    {
        OverrideAnim(Clip.Idle, _present.AttackIdle);
        OverrideAnim(Clip.Death, present.Death);
        OverrideAnim(Clip.Run, present.Run);
        OverrideAnim(Clip.RunLeft, present.RunLeft);
        OverrideAnim(Clip.RunRight, present.RunRight);
        OverrideAnim(Clip.Freezed, present.Freeze);
        OverrideAnim(Clip.Walk, present.AttackWalk);

        string[] hits = _present.HitFly;
        string hit = hits == null || hits.Length == 0 ? null : hits[1];
        OverrideAnim(Clip.HitLanding, hit);
    }

    
   


    public override void OnHit(bool hit)
    {
        base.OnHit(hit);
        hitCnt++;
        if (hitCnt >= maxHit)
        {
           // OnDied();
        }
    }

}

