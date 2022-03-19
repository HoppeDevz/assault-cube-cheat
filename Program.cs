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

            AmmoHacking ammoController = new AmmoHacking(memory);
            HealthHacking healthHacking = new HealthHacking(memory);
            CoordsHacking coordsHacking = new CoordsHacking(memory);

            int PID = memory.GetProcIdFromName("ac_client");

            if (PID > 0) {

                memory.OpenProcess(PID);

                healthHacking.startThread();
                ammoController.startThread();

                int option = 0;

                while (true) {

                    Console.WriteLine("===========HOPPE CHEAT===========");
                    Console.WriteLine("INFINITE WEAPON_AMMO: " + (ammoController.getPistolAmmoStatus() ? "[ON]" : "[OFF]"));
                    Console.WriteLine("INFINITE AR_AMMO: " + (ammoController.getArAmmoStatus() ? "[ON]" : "[OFF]"));
                    Console.WriteLine("INFINITE HEALTH: " + (healthHacking.getInfiniteHealthStatus() ? "[ON]" : "[OFF]"));

                    Console.WriteLine();

                    Console.WriteLine("1 - Enable infinite pistol ammo");
                    Console.WriteLine("2 - Enable infinite ar ammo");
                    Console.WriteLine("3 - Enable infinite health");
                    Console.WriteLine("4 - Disable infinite pistol ammo");
                    Console.WriteLine("5 - Disable infinite ar ammo");
                    Console.WriteLine("6 - Disable infinite ar ammo");
                    Console.WriteLine("7 - Change player coords");

                    option = int.Parse(Console.ReadLine());

                    if (option == 1) {

                        ammoController.enableInfinitePistolAmmo();
                    }

                    if (option == 2) {

                        ammoController.enableInfiniteArAmmo();
                    }

                    if (option == 3) {

                        healthHacking.enableInfiniteHealth();
                    }

                    if (option == 4) {

                        ammoController.disableInfinitePistolAmmo();
                    }

                    if (option == 5) {

                        ammoController.disableInfiniteArAmmo();
                    }

                    if (option == 6) {

                        healthHacking.disableInfinityHealth();
                    }

                    if (option == 7) {

                        Console.Write("Value that will be increased on the x axis: ");
                        float xVal = float.Parse(Console.ReadLine());

                        Console.Write("Value that will be increased on the y axis: ");
                        float yVal = float.Parse(Console.ReadLine());

                        Console.Write("Value that will be increased on the z axis: ");
                        float zVal = float.Parse(Console.ReadLine());

                        coordsHacking.increasePlayerPosition(xVal, yVal, zVal);
                    }

                    Console.Clear();
                }
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