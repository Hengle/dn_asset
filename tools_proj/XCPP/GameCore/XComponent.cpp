#include "XObject.h"


XComponent::XComponent()
{
}


XComponent::~XComponent()
{
}

void XComponent::OnInitial(XEntity* _obj)
{
	xenty = _obj;
	_double = false;
	_time = 0;
}

void XComponent::OnUninit()
{
	xenty = 0;
	_double = false;
	_time = 0;
	Unload();
}

void XComponent::OnUpdate(float delta)
{
}



void XComponent::Update(float delta)
{
	_time += delta;
	switch (state)
	{
	case FRAME:
		OnUpdate(delta);
		break;
	case DOUBLE:
		if (_double) OnUpdate(delta);
		_double = !_double;
		break;
	case TIMER:
		if (_time >= 1.0f)
		{
			OnUpdate(delta);
			_time = 0;
		}
		break;
	default:
		break;
	}
}

