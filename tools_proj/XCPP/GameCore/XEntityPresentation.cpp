/*
 * <auto-generated>
 *	 The code is generated by tools
 *	 Edit manually this code will lead to incorrect behavior
 * </auto-generated>
 */

#include "XEntityPresentation.h"

XEntityPresentation::XEntityPresentation(void)
{
	name = UNITY_STREAM_PATH + "Table/XEntityPresentation.bytes";
	ReadTable();
}

void XEntityPresentation::ReadTable()
{
	Open(name.c_str());
	long long filesize =0;
	int lineCnt = 0;
	Read(&filesize);
	Read(&lineCnt);
	m_data.clear();
	for(int i=0;i<lineCnt;i++)
	{
		XEntityPresentationRow *row = new XEntityPresentationRow();
		
		Read(&(row->uid));
		ReadString(row->prefab);
		ReadString(row->name);
		ReadString(row->bonesuffix);
		ReadString(row->animlocation);
		ReadString(row->skilllocation);
		ReadString(row->curvelocation);
		Read(&(row->boundradius));
		ReadArray<float>(row->boundradiusoffset);
		Read(&(row->boundheight));
		ReadString(row->hugemonstercolliders);
		Read(&(row->scale));
		ReadString(row->uiavatarangle);
		Read(&(row->uiavatarscale));
		ReadString(row->avatarpos);
		Read(&(row->huge));
		ReadString(row->entergame);
		Read(&(row->angluarspeed));
		ReadString(row->idle);
		ReadString(row->attackidle);
		ReadString(row->fishingidle);
		ReadString(row->walk);
		ReadString(row->attackwalk);
		ReadString(row->run);
		ReadString(row->attackrun);
		ReadString(row->runleft);
		ReadString(row->attackrunleft);
		ReadString(row->runright);
		ReadString(row->attackrunright);
		ReadString(row->movefx);
		ReadString(row->freeze);
		ReadString(row->freezefx);
		ReadStringArray(row->hit_f);
		ReadStringArray(row->hit_l);
		ReadStringArray(row->hit_r);
		ReadArray<float>(row->hitbackoffsettimescale);
		ReadStringArray(row->hitfly);
		ReadArray<float>(row->hitflyoffsettimescale);
		ReadStringArray(row->hit_roll);
		ReadArray<float>(row->hitrolloffsettimescale);
		ReadArray<float>(row->hitback_recover);
		ReadArray<float>(row->hitfly_bounce_getup);
		Read(&(row->hitroll_recover));
		ReadString(row->hitfx);
		ReadString(row->death);
		ReadString(row->deathfx);
		ReadStringArray(row->hitcurves);
		ReadString(row->deathcurve);
		ReadString(row->a);
		ReadString(row->aa);
		ReadString(row->aaa);
		ReadString(row->aaaa);
		ReadString(row->aaaaa);
		ReadStringArray(row->otherskills);
		ReadString(row->skillnum);
		ReadString(row->dash);
		ReadString(row->ultra);
		ReadString(row->appear);
		ReadString(row->disappear);
		ReadString(row->fishingcast);
		ReadString(row->fishingpull);
		ReadString(row->fishingwait);
		ReadString(row->fishingwin);
		ReadString(row->fishinglose);
		ReadString(row->dance);
		ReadString(row->kiss);
		ReadString(row->inheritactionone);
		ReadString(row->inheritactiontwo);
		ReadString(row->atlas);
		ReadString(row->avatar);
		ReadString(row->atlas2);
		ReadString(row->avatar2);
		Read(&(row->shadow));
		ReadString(row->feeble);
		ReadString(row->feeblefx);
		ReadString(row->armorbroken);
		ReadString(row->superarmorrecoveryskill);
		ReadString(row->recoveryfx);
		ReadString(row->recoveryhitslowfx);
		ReadString(row->recoveryhitstopfx);
		m_data.push_back(row);
		m_map.insert(std::make_pair(row->uid, row));
	}
	this->Close();
}

void XEntityPresentation::GetRow(int idx,XEntityPresentationRow* row)
{
	size_t len = m_data.size();
	if(idx<(int)len)
	{
		*row = *m_data[idx];
	}
	else
	{
		LOG("eror, XEntityPresentation index out of range, size: "+tostring(len)+" idx: "+tostring(idx));
	}
}

void XEntityPresentation::GetByUID(uint idx, XEntityPresentationRow* row)
{
 *row = *m_map[idx];
}

int XEntityPresentation::GetLength()
{
	return (int)m_data.size();
}


extern "C"
{
	XEntityPresentation *xentitypresentation;

	int iGetXEntityPresentationLength()
	{
		if(xentitypresentation==NULL)
		{
			xentitypresentation = new XEntityPresentation();
		}
		return xentitypresentation->GetLength();
	}

	void iGetXEntityPresentationRow(int id,XEntityPresentationRow* row)
	{
		if(xentitypresentation==NULL)
		{
			xentitypresentation = new XEntityPresentation();
		}
		xentitypresentation->GetRow(id,row);
	}

	void iGetXEntityPresentationRowByID(uint id, XEntityPresentationRow* row)
	{
		if (xentitypresentation == NULL)
		{
		   xentitypresentation = new XEntityPresentation();
		}
		xentitypresentation->GetByUID(id, row);
	}
}