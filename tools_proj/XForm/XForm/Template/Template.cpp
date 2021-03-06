/*
 * <auto-generated>
 *	 The code is generated by tools
 *	 Edit manually this code will lead to incorrect behavior
 * </auto-generated>
 */

#include "[*Table*].h"

[*Table*]::[*Table*](void)
{
	name = UNITY_STREAM_PATH + "Table/[*Table*].bytes";
	ReadTable();
}

void [*Table*]::ReadTable()
{
	Open(name.c_str());
	long long filesize =0;
	int lineCnt = 0;
	Read(&filesize);
	Read(&lineCnt);
	m_data.clear();
	for(int i=0;i<lineCnt;i++)
	{
		[*Table*]Row *row = new [*Table*]Row();
		[**read**]
		m_data.push_back(row);
		[\\]m_map.insert(std::make_pair(row->[*uid*], row));
	}
	this->Close();
}

void [*Table*]::GetRow(int idx,[*Table*]Row* row)
{
	size_t len = m_data.size();
	if(idx<(int)len)
	{
		*row = *m_data[idx];
	}
	else
	{
		LOG("eror, [*Table*] index out of range, size: "+tostring(len)+" idx: "+tostring(idx));
	}
}

[\\]void [*Table*]::GetByUID(uint idx, [*Table*]Row* row)
[\\]{
[\\] *row = *m_map[idx];
[\\]}

int [*Table*]::GetLength()
{
	return (int)m_data.size();
}


extern "C"
{
	[*Table*] *[*table*];

	int iGet[*Table*]Length()
	{
		if([*table*]==NULL)
		{
			[*table*] = new [*Table*]();
		}
		return [*table*]->GetLength();
	}

	void iGet[*Table*]Row(int id,[*Table*]Row* row)
	{
		if([*table*]==NULL)
		{
			[*table*] = new [*Table*]();
		}
		[*table*]->GetRow(id,row);
	}

	[\\]void iGet[*Table*]RowByID(uint id, [*Table*]Row* row)
	[\\]{
	[\\]	if ([*table*] == NULL)
	[\\]	{
	[\\]	   [*table*] = new [*Table*]();
	[\\]	}
	[\\]	[*table*]->GetByUID(id, row);
	[\\]}
}