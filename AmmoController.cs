using System.Threading;
using Memory;

namespace GameHacking {

    class AmmoHacking {

        Mem memory;
        MemoryHelper memHelper = new MemoryHelper();

        private string arAmmoOffset = "0x140";
        private string pistolAmmoOffset = "0x12C";
        private bool infiniteArAmmoEnabled = false;
        private bool infinitePistolAmmoEnabled = false;

        private int pistolAmmoIncreaseAmount = 999;
        private int arAmmoIncreaseAmount = 999;

        public AmmoHacking(Mem memory) {
            
            this.memory = memory;
        }

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

        public void enableInfiniteArAmmo() {

            this.infiniteArAmmoEnabled = true;
        }
        public void disableInfiniteArAmmo() {

            this.infiniteArAmmoEnabled = false;
        }

        public void enableInfinitePistolAmmo() {

            this.infinitePistolAmmoEnabled = true;
        }
        public void disableInfinitePistolAmmo() {

            this.infinitePistolAmmoEnabled = false;
        }

        public bool getPistolAmmoStatus() {

            return this.infinitePistolAmmoEnabled;
        }

        public bool getArAmmoStatus() {

            return this.infiniteArAmmoEnabled;
        }

        public async void startThread() {

            while (true) {

                if (infiniteArAmmoEnabled)
                    memory.WriteMemory(memHelper.getAddress(this.arAmmoOffset), "int", this.arAmmoIncreaseAmount.ToString());

                if (infinitePistolAmmoEnabled)
                    memory.WriteMemory(memHelper.getAddress(this.pistolAmmoOffset), "int", this.pistolAmmoIncreaseAmount.ToString());

                await Task.Delay(100);
            }
        }
    }
}