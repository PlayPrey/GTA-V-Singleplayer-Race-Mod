using System;
using GTA;
using GTA.Native;
using GTA.Math;

namespace SPraceMod.Races
{
    class Race01 : Script
    {

        


        Vehicle raceCar01;
        Vehicle raceCar02;
        Ped racer01;
        Ped racer02;
        Vector3 spawnPointPlayer = new Vector3(648.682f, 3502.916f, 33.27346f);
        Vector3 racer01Spawn = new Vector3(637.395f, 3505.451f, 35.62923f);
        Vector3 raceCar01Spawn = new Vector3(638.435f, 3502.02f, 33.58217f);
        TaskSequence racer01Task;
        TaskSequence racer02Task;
        Vector3 raceCar02Spawn = new Vector3(638.435f, 3498.105f, 33.3917f);


        float racerSpeed = 200f;


        Vector3 p01 = new Vector3(412.771f, 3502.336f, 34.02979f);
        Vector3 p02 = new Vector3(330.752f, 3583.387f, 32.6484f);
        Vector3 p03 = new Vector3(905.267f, 3633.396f, 32.01043f);

       
        int CurrentCheckpoint;

        public Race01()
        {
            Interval = 250;
            Tick += Race01_Tick;


           
        }

       

        internal void Initialize(int NumberOfRacers, string VehicleModel)
        {

            raceCar01 = World.CreateVehicle(VehicleModel, raceCar01Spawn, 95f);
            racer01 = World.CreatePed(GTA.Native.PedHash.Barry, racer01Spawn);
            raceCar02 = World.CreateVehicle(VehicleModel, raceCar02Spawn, 98f);
            racer02 = World.CreatePed(GTA.Native.PedHash.Bankman, racer01Spawn);
            SetupTasksequences();
            raceCar01.MarkAsNoLongerNeeded();
            raceCar02.MarkAsNoLongerNeeded();
            racer01.MarkAsNoLongerNeeded();
            racer02.MarkAsNoLongerNeeded();
            racer01.Task.PerformSequence(racer01Task);
            racer02.Task.PerformSequence(racer02Task);
            OnCheckpoint(0);
            
        }
        void SetupTasksequences()
        {

            racer01Task = new TaskSequence();
            
            racer01Task.AddTask.WarpIntoVehicle(raceCar01, VehicleSeat.Driver);
            racer01Task.AddTask.DriveTo(raceCar01, p01, 5f, racerSpeed, (int)DrivingStyle.AvoidTrafficExtremely);
            racer01Task.AddTask.DriveTo(raceCar01, p02, 5f, racerSpeed, (int)DrivingStyle.AvoidTrafficExtremely);
            racer01Task.AddTask.DriveTo(raceCar01, p03, 5f, racerSpeed, (int)DrivingStyle.AvoidTrafficExtremely);
            
            racer01Task.Close();

            racer02Task = new TaskSequence();

            racer02Task.AddTask.WarpIntoVehicle(raceCar02, VehicleSeat.Driver);
            racer02Task.AddTask.DriveTo(raceCar02, p01, 5f, racerSpeed, (int)DrivingStyle.AvoidTrafficExtremely);
            racer02Task.AddTask.DriveTo(raceCar02, p02, 5f, racerSpeed, (int)DrivingStyle.AvoidTrafficExtremely);
            racer02Task.AddTask.DriveTo(raceCar02, p03, 5f, racerSpeed, (int)DrivingStyle.AvoidTrafficExtremely);

            racer02Task.Close();
        }



        void Race01_Tick(object sender, EventArgs e)
        {

            if (Game.Player.Character.Position.DistanceTo(p01) < 10f && CurrentCheckpoint == 0)
            {

                CurrentCheckpoint += 1;
                OnCheckpoint(1);

                UI.Notify("Reached Checkpoint 1/NAN");
            }
            if (Game.Player.Character.Position.DistanceTo(p02) < 10f && CurrentCheckpoint == 1)
            {

                CurrentCheckpoint += 1;
                OnCheckpoint(2);


                UI.Notify("Reached Checkpoint 2/NAN");
            }
            if (Game.Player.Character.Position.DistanceTo(p03) < 10f && CurrentCheckpoint == 1)
            {

                CurrentCheckpoint += 1;
                OnCheckpoint(3);


                UI.Notify("Reached Checkpoint 3/NAN");
            }
        }

        void OnCheckpoint(int cpointID)
        {

           // Blip Checkpoint = World.CreateBlip(new Vector3(0f, 0f, 0f), 8f);

            if(cpointID == 0)
            {
                //Checkpoint.Position = Point01;
                if (Game.Player.Character.IsInVehicle())
                {
                    Vehicle oldCar = Game.Player.Character.CurrentVehicle;
                    oldCar.Delete();
                }

                Vehicle NewCar = World.CreateVehicle("BTYPE", spawnPointPlayer, 98.702f);
                Game.Player.Character.Task.WarpIntoVehicle(NewCar, VehicleSeat.Driver);

                
            }
            if (cpointID == 1 && CurrentCheckpoint == 1)
            {
                //Checkpoint.Position = Point02;
            }
            if (cpointID == 2 && CurrentCheckpoint == 2)
            {
                //Checkpoint.Remove();
            }
        }

    }
}
