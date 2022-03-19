using Memory;
using System.Threading;

namespace GameHacking {

    internal class Program {

        static void Main() {

            Mem memory = new Mem();
    
            // "ac_client.exe"+0017B0B8 + 12C;


            // HEALTH "ac_client.exe"+0017B0B8 + EC;

            string ammoAddress = "ac_client.exe+0x17B0B8,0x140";
            string pistolAmmoAddress = "ac_client.exe+0x17B0B8,0x12C";

            string playerHealthAddress = "ac_client.exe+0x17B0B8,0xEC";

            string xCoordAddress = "ac_client.exe+0x17B0B8,0x2C";
            string yCoordAddress = "ac_client.exe+0x17B0B8,0x28";
            string zCoordAddress = "ac_client.exe+0x17B0B8,0x30";

            AmmoHacking ammoController = new AmmoHacking();
            HealthHacking healthHacking = new HealthHacking(memory);

            int PID = memory.GetProcIdFromName("ac_client");

            if (PID > 0) {

                memory.OpenProcess(PID);

                healthHacking.enableInfiniteHealth();
                healthHacking.startThread();

                /*
                while (true) {

                    ammoController.reloadAmmo(999, "pistol", memory);
                    Thread.Sleep(1000);
                }

                
                while (true) {
                    
                    float x = memory.ReadFloat(xCoordAddress);
                    float y = memory.ReadFloat(yCoordAddress);
                    float z = memory.ReadFloat(zCoordAddress);

                    Console.WriteLine("x:" + x + " y:" + y + " z:" + z);
                
                    memory.WriteMemory(ammoAddress, "int", "99999");
                    memory.WriteMemory(pistolAmmoAddress, "int", "999");
                    memory.WriteMemory(playerHealthAddress, "int", "99");
                    Console.WriteLine("Editing ammo amount...");

                    Thread.Sleep(1000);
                }
                */

                /*
                float increase;

                increase = float.Parse(Console.ReadLine());

                float x = memory.ReadFloat(xCoordAddress);
                float y = memory.ReadFloat(yCoordAddress);
                float z = memory.ReadFloat(zCoordAddress);

                z = z + increase;

                memory.WriteMemory(zCoordAddress, "float", z.ToString());
                */

            } else {

                Console.WriteLine("Game is closed!");
            }
        }
    }
}