// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace AI.Runtime {
    using UnityEngine;
    
    
    public class AIRuntimeValueHP : AIRunTimeBase {
        
        public int Int32mAIArgMaxHP;
        
        public int Int32mAIArgMinHP;
        
        public override void Init(AI.Runtime.AIRuntimeTaskData data) {
			base.Init(data);
			if(data.vars[0].val != null)
				Int32mAIArgMaxHP = (System.Int32)data.vars[0].val;
			if(data.vars[1].val != null)
				Int32mAIArgMinHP = (System.Int32)data.vars[1].val;
        }
        
        public override AIRuntimeStatus OnTick(XEntity entity) {
			return AITreeImpleted.ValueHPUpdate(entity, Int32mAIArgMaxHP, Int32mAIArgMinHP);
        }
    }
}
