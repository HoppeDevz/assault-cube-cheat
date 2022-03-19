using Memory;

namespace GameHacking {

    class AmmoHacking {

        private string playerBaseAddress = "0x17B0B8";
        private string arAmmoOffset = "0x140";
        private string pistolAmmoOffset = "0x12C";

        MemoryHelper memHelper = new MemoryHelper();

        public void reloadAmmo(int amount, string type, Mem memory) {

            switch (type) {

                case "pistol": {

                    memory.WriteMemory(memHelper.getAddress(this.pistolAmmoOffset), "int", amount.ToString());
                    break;
                }

                case "ar": {

                    memory.WriteMemory(memHelper.getAddress(this.arAmmoOffset), "int", amount.ToString());
                    break;
                }
            }
        }
    }
}