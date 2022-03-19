using Memory;
using System.Threading;

namespace GameHacking {

    public class CoordsHacking {

        private string xAxisOffset = "0x2C";
        private string yAxisOffset = "0x28";
        private string zAxisOffset = "0x30";

        Mem memory;

        MemoryHelper memHelper = new MemoryHelper();

        public CoordsHacking(Mem memory) {

            this.memory = memory;
        }

        public void increasePlayerPosition(float increaseX, float increaseY, float increaseZ) {

            float xAxisInMemory = memory.ReadFloat(memHelper.getAddress(this.xAxisOffset));
            float yAxisInMemory = memory.ReadFloat(memHelper.getAddress(this.yAxisOffset));
            float zAxisInMemory = memory.ReadFloat(memHelper.getAddress(this.zAxisOffset));

            float xAxisValueIncreased = xAxisInMemory + increaseX;
            float yAxisValueIncreased = yAxisInMemory + increaseY;
            float zAxisValueIncreased = zAxisInMemory + increaseZ;

            memory.WriteMemory(memHelper.getAddress(this.xAxisOffset), "float", xAxisValueIncreased.ToString());
            memory.WriteMemory(memHelper.getAddress(this.yAxisOffset), "float", yAxisValueIncreased.ToString());
            memory.WriteMemory(memHelper.getAddress(this.zAxisOffset), "float", zAxisValueIncreased.ToString());
        }
    }
}