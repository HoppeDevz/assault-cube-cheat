using Memory;
using System.Threading;

namespace GameHacking {

    class HealthHacking {

        private string playerBaseAddress = "0x17B0B8";
        private string healthOffset = "0xEC";
        private bool enabledInfinityHealth = false;
        private int restoreHealthAmount = 100;
        Mem memory;

        MemoryHelper memHelper = new MemoryHelper();

        public HealthHacking(Mem memory) {

            this.memory = memory;
        }

        public void enableInfiniteHealth() {

            this.enabledInfinityHealth = true;
        }

        public void disableInfinityHealth() {

            this.enabledInfinityHealth = false;
        }

        public void changeRestoreHealthAmount(int newAmount) {

            this.restoreHealthAmount = newAmount;
        }

        public void startThread() {

            while (true) {


                if (enabledInfinityHealth) {

                    Console.WriteLine("[HOPPUS-CHEAT] RESTORE PLAYER HEALTH");

                    memory.WriteMemory(memHelper.getAddress(this.healthOffset), "int", this.restoreHealthAmount.ToString());
                }

                Thread.Sleep(500);
            }
        }
    }
}