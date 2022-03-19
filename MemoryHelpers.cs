

namespace GameHacking {

    public class MemoryHelper {

        private string procName = "ac_client.exe+";
        private string playerBaseAddress = "0x17B0B8";

        public string getAddress(string offset) {

            return this.procName + this.playerBaseAddress + "," + offset;
        }
    }
}