/*
* <auto-generated>
*	 The code is generated by tools
*	 Edit manually this code will lead to incorrect behavior
* </auto-generated>
*/

#ifndef  __AIRuntimeValueDistance__
#define  __AIRuntimeValueDistance__

#include "../GameObject.h"
#include "../Vector3.h"
#include "../AIBehaviour.h"
#include "../AITreeImpleted.h"

class XEntity;

class AIRuntimeValueDistance :public AIBase
{
public:
	~AIRuntimeValueDistance();
	virtual void Init(AITaskData* data);
	virtual AIStatus OnTick(XEntity* entity);
	

private:
	GameObject* GameObjectmAIArgTarget;
	float floatmAIArgMaxDistance;
	
};

#endif