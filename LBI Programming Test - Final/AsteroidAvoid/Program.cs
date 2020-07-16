using System;

/*
 * Author Information:
 * Matthew John Werner
 * email: matthewwerner17@gmail.com
 * phone: 12627190217
 * 
 * Start Date: July 1, 2020 - 1230
 * Latest Updates: July 2, 2020 - 1350
 */
// Welcome! This is the Lost Boys Interactive programming test

// You are on board an exploration ship headed for the moons of Jupiter.  
// En route, the ship has entered an asteroid field, a small collision has disabled all engines!

// You are the head of engineering, and the captain has just ordered you to 
// engange all sensors to track the asteroids in the local field.  
// The captain wants to know how much time you have to fix the engines before
// you are likely to be struck by an asteroid!

// 1) You've inherited this code ] a sloppy planet-sider
//    - Get the code to run!
//    Input Args: <ScannerRadius> <AsteroidSpawnRadius> <AsteroidCount> <Seed> <MaxAsteroidVelocity> <MinAsteroidRadius> <MaxAsteroidRadius> <ShipRadius>
//    Example Inputs:  INPUTS 400 300 100 2341 5 10 20 50 
//    Example Output: 
//      Asteroid 41 passed outside of field at Location x:283.929, y:-37.619, z:284.485 : 403.686 at time 22.000
//      Asteroid 92 passed outside of field at Location x:172.785, y:-215.557, z:289.951 : 400.4885 at time 24.000
//      Asteroid 46 passed outside of field at Location x:124.671, y:-358.486, z:-128.681 : 400.7669 at time 25.000
//      Asteroid 100 passed outside of field at Location x:-92.094, y:241.190, z:305.704 : 400.1356 at time 26.000
//      Asteroid 86 passed outside of field at Location x:11.946, y:403.445, z:-14.042 : 403.8663 at time 26.000
//      Asteroid 10 passed outside of field at Location x:251.192, y:-230.048, z:210.802 : 400.571 at time 27.000
//      Asteroid 30 passed outside of field at Location x:-333.414, y:120.540, z:-190.859 : 402.6433 at time 29.000
//      Asteroid 49 passed outside of field at Location x:334.410, y:218.754, z:37.209 : 401.3325 at time 33.000
//      Asteroid 3 passed outside of field at Location x:60.110, y:-350.897, z:187.770 : 402.4917 at time 33.000
//      Asteroid 7 passed outside of field at Location x:190.154, y:-111.966, z:337.111 : 402.9129 at time 34.000
//      Asteroid 32 passed outside of field at Location x:-51.798, y:-221.042, z:332.152 : 402.3275 at time 35.000
//      Asteroid 98 passed outside of field at Location x:328.685, y:-199.753, z:116.882 : 401.9907 at time 36.000
//      Asteroid 35 passed outside of field at Location x:-242.774, y:-308.729, z:-89.409 : 402.7982 at time 36.000
//      Asteroid 27 passed outside of field at Location x:280.697, y:-43.223, z:-284.563 : 402.0382 at time 36.000
//      Asteroid 78 passed outside of field at Location x:-199.334, y:235.305, z:-257.351 : 401.6611 at time 37.000
//      Asteroid 16 passed outside of field at Location x:-306.793, y:166.392, z:198.389 : 401.4555 at time 38.000
//      Asteroid 15 passed outside of field at Location x:-190.809, y:-72.905, z:-346.328 : 402.077 at time 40.000
//      Asteroid 40 passed outside of field at Location x:253.482, y:311.273, z:10.833 : 401.5733 at time 41.000
//      Asteroid 97 passed outside of field at Location x:398.781, y:-46.185, z:26.324 : 402.3091 at time 43.000
//      Asteroid 76 passed outside of field at Location x:58.962, y:193.022, z:-346.507 : 400.9999 at time 44.000
//      Asteroid 45 passed outside of field at Location x:159.820, y:-296.062, z:-218.173 : 400.9921 at time 44.000
//      Asteroid 59 passed outside of field at Location x:-331.365, y:206.851, z:-93.899 : 401.7552 at time 45.000
//      Asteroid 68 passed outside of field at Location x:-377.370, y:-49.381, z:-126.682 : 401.1172 at time 46.000
//      Asteroid 39 passed outside of field at Location x:-315.921, y:-62.844, z:-241.566 : 402.629 at time 46.000
//      Asteroid 18 passed outside of field at Location x:309.901, y:36.350, z:252.150 : 401.1729 at time 47.000
//      Asteroid 17 passed outside of field at Location x:-369.827, y:-118.294, z:97.504 : 400.3407 at time 48.000
//      Asteroid 24 passed outside of field at Location x:-63.513, y:-326.201, z:224.496 : 401.0477 at time 49.000
//      Asteroid 65 passed outside of field at Location x:162.912, y:364.460, z:-37.525 : 400.9727 at time 50.000
//      Asteroid 55 passed outside of field at Location x:104.041, y:-93.983, z:375.554 : 400.8714 at time 53.000
//      Asteroid 33 passed outside of field at Location x:79.115, y:-154.505, z:363.104 : 402.462 at time 53.000
//      Asteroid 61 passed outside of field at Location x:41.747, y:397.362, z:-49.357 : 402.5857 at time 57.000
//      Asteroid 80 passed outside of field at Location x:1.674, y:294.593, z:-271.539 : 400.6508 at time 60.000
//      Asteroid 77 passed outside of field at Location x:272.434, y:206.575, z:210.139 : 401.3128 at time 60.000
//      Asteroid 75 passed outside of field at Location x:-327.819, y:121.246, z:-196.880 : 401.1576 at time 61.000
//      Asteroid 20 passed outside of field at Location x:341.373, y:-162.367, z:137.527 : 402.2587 at time 61.000
//      Asteroid 21 passed outside of field at Location x:305.402, y:168.332, z:-198.091 : 401.0565 at time 65.000
//      Asteroid 82 passed outside of field at Location x:184.162, y:-195.823, z:-297.399 : 400.8846 at time 67.000
//      Asteroid 51 passed outside of field at Location x:-222.617, y:-186.411, z:275.164 : 400.0286 at time 67.000
//      Ship Destroyed by collision with Asteroid 90 at time 67 location x:-34.768, y:55.373, z:15.239
//      The Ship will be destroyed in 67 seconds!
//
//  Asteroid Movement:  Assume extremely simple movement.  The asteroids teleport to their new locations in 1 second intervals.  
//                      No need to calculate precise collision in a time step, simple distance checks at set intervals will suffice.


// 2) The situation may not be as bad as expected!  The asteroids are really ice chunks.  
//  It has been determined that if an asteroid strikes another asteroid they are both vaporized!
//   - Enable AsteroidField.AsteroidAsteroidCollision() to eliminate asteroids that strike each other

//    Input Args: <ScannerRadius> <AsteroidSpawnRadius> <AsteroidCount> <Seed> <MaxAsteroidVelocity> <MinAsteroidRadius> <MaxAsteroidRadius> <ShipRadius>
//    Example Inputs:  INPUTS 400 300 100 2341 5 10 20 50 
//    Example Output: 
//  Asteroid 5 Destroyed by collision with Asteroid 1 at time 0 :: x:116.109, y:-229.113, z:-151.646
//  Asteroid 39 Destroyed by collision with Asteroid 15 at time 0 :: x:-142.486, y:-6.866, z:-266.594
//  Asteroid 82 Destroyed by collision with Asteroid 19 at time 0 :: x:7.383, y:-171.308, z:-245.725
//  Asteroid 78 Destroyed by collision with Asteroid 26 at time 0 :: x:-158.499, y:198.746, z:-151.543
//  Asteroid 55 Destroyed by collision with Asteroid 36 at time 0 :: x:-57.211, y:-208.822, z:202.281
//  Asteroid 49 Destroyed by collision with Asteroid 43 at time 0 :: x:273.426, y:120.730, z:7.624
//  Asteroid 93 Destroyed by collision with Asteroid 44 at time 0 :: x:6.094, y:-287.928, z:-70.854
//  Asteroid 58 Destroyed by collision with Asteroid 51 at time 0 :: x:-199.666, y:-82.716, z:209.975
//  Asteroid 96 Destroyed by collision with Asteroid 54 at time 0 :: x:160.772, y:151.752, z:-202.680
//  Asteroid 66 Destroyed by collision with Asteroid 65 at time 0 :: x:152.414, y:184.589, z:-181.714
//  Asteroid 84 Destroyed by collision with Asteroid 81 at time 0 :: x:293.339, y:22.454, z:-38.542
//  Asteroid 27 Destroyed by collision with Asteroid 22 at time 1 :: x:179.808, y:-11.092, z:-239.512
//  Asteroid 79 Destroyed by collision with Asteroid 3 at time 3 :: x:-36.132, y:-267.274, z:152.973
//  Asteroid 60 Destroyed by collision with Asteroid 31 at time 4 :: x:-171.339, y:33.039, z:-236.744
//  Asteroid 85 Destroyed by collision with Asteroid 50 at time 6 :: x:212.450, y:215.960, z:32.438
//  Asteroid 94 Destroyed by collision with Asteroid 21 at time 10 :: x:234.252, y:154.894, z:-146.127
//  Asteroid 71 Destroyed by collision with Asteroid 4 at time 20 :: x:-218.325, y:91.490, z:-215.335
//Asteroid 41 passed outside of field at Location x:283.929, y:-37.619, z:284.485 : 403.686 at time 22.000
//Asteroid 92 passed outside of field at Location x:172.785, y:-215.557, z:289.951 : 400.4885 at time 24.000
//Asteroid 46 passed outside of field at Location x:124.671, y:-358.486, z:-128.681 : 400.7669 at time 25.000
//Asteroid 100 passed outside of field at Location x:-92.094, y:241.190, z:305.704 : 400.1356 at time 26.000
//Asteroid 86 passed outside of field at Location x:11.946, y:403.445, z:-14.042 : 403.8663 at time 26.000
//Asteroid 10 passed outside of field at Location x:251.192, y:-230.048, z:210.802 : 400.571 at time 27.000
//Asteroid 30 passed outside of field at Location x:-333.414, y:120.540, z:-190.859 : 402.6433 at time 29.000
//Asteroid 7 passed outside of field at Location x:190.154, y:-111.966, z:337.111 : 402.9129 at time 34.000
//Asteroid 32 passed outside of field at Location x:-51.798, y:-221.042, z:332.152 : 402.3275 at time 35.000
//Asteroid 98 passed outside of field at Location x:328.685, y:-199.753, z:116.882 : 401.9907 at time 36.000
//Asteroid 35 passed outside of field at Location x:-242.774, y:-308.729, z:-89.409 : 402.7982 at time 36.000
//Asteroid 16 passed outside of field at Location x:-306.793, y:166.392, z:198.389 : 401.4555 at time 38.000
//Asteroid 40 passed outside of field at Location x:253.482, y:311.273, z:10.833 : 401.5733 at time 41.000
//Asteroid 97 passed outside of field at Location x:398.781, y:-46.185, z:26.324 : 402.3091 at time 43.000
//Asteroid 76 passed outside of field at Location x:58.962, y:193.022, z:-346.507 : 400.9999 at time 44.000
//Asteroid 45 passed outside of field at Location x:159.820, y:-296.062, z:-218.173 : 400.9921 at time 44.000
//Asteroid 59 passed outside of field at Location x:-331.365, y:206.851, z:-93.899 : 401.7552 at time 45.000
//Asteroid 68 passed outside of field at Location x:-377.370, y:-49.381, z:-126.682 : 401.1172 at time 46.000
//Asteroid 18 passed outside of field at Location x:309.901, y:36.350, z:252.150 : 401.1729 at time 47.000
//  Asteroid 28 Destroyed by collision with Asteroid 13 at time 47 :: x:10.423, y:-242.817, z:-58.850
//Asteroid 17 passed outside of field at Location x:-369.827, y:-118.294, z:97.504 : 400.3407 at time 48.000
//Asteroid 24 passed outside of field at Location x:-63.513, y:-326.201, z:224.496 : 401.0477 at time 49.000
//Asteroid 33 passed outside of field at Location x:79.115, y:-154.505, z:363.104 : 402.462 at time 53.000
//Asteroid 61 passed outside of field at Location x:41.747, y:397.362, z:-49.357 : 402.5857 at time 57.000
//Asteroid 80 passed outside of field at Location x:1.674, y:294.593, z:-271.539 : 400.6508 at time 60.000
//Asteroid 77 passed outside of field at Location x:272.434, y:206.575, z:210.139 : 401.3128 at time 60.000
//Asteroid 75 passed outside of field at Location x:-327.819, y:121.246, z:-196.880 : 401.1576 at time 61.000
//Asteroid 20 passed outside of field at Location x:341.373, y:-162.367, z:137.527 : 402.2587 at time 61.000
//Ship Destroyed by collision with Asteroid 90 at time 67 location x:-34.768, y:55.373, z:15.239
//The Ship will be destroyed in 67 seconds!



// 3) The asteroid field is denser than we thought.  It has been determined that the program takes
//    so long to run that we may be destroyed before we determine which asteroid will strike us and
//    what action to take!
// - Optimize the code to process the collisions in less time

//    Input Args: <ScannerRadius> <AsteroidSpawnRadius> <AsteroidCount> <Seed> <MaxAsteroidVelocity> <MinAsteroidRadius> <MaxAsteroidRadius> <ShipRadius>
//    Example Inputs:  INPUTS 10000 9000 10000 2341 5 10 20 50 
//    Example Output: 
//
//  Asteroid 5977 Destroyed by collision with Asteroid 3472 at time 0 :: x:-2390.266, y:-3273.384, z:-8036.266
//  Asteroid 9590 Destroyed by collision with Asteroid 8755 at time 0 :: x:2786.185, y:-2865.465, z:-8064.338
//  Asteroid 1957 Destroyed by collision with Asteroid 1104 at time 0 :: x:3451.451, y:-380.038, z:-8300.191
//  Asteroid 7023 Destroyed by collision with Asteroid 2938 at time 0 :: x:1440.129, y:679.337, z:-8855.036
//  Asteroid 9579 Destroyed by collision with Asteroid 315 at time 0 :: x:-1909.580, y:2080.508, z:-8546.185
//  Asteroid 2138 Destroyed by collision with Asteroid 632 at time 0 :: x:1404.758, y:3777.447, z:-8049.136
//  Asteroid 7570 Destroyed by collision with Asteroid 2918 at time 0 :: x:4183.914, y:-3738.556, z:-7034.311
//  Asteroid 4729 Destroyed by collision with Asteroid 3736 at time 0 :: x:-5577.584, y:-208.316, z:-7059.058
//  Asteroid 9535 Destroyed by collision with Asteroid 1459 at time 0 :: x:4154.823, y:-590.961, z:-7961.862
//  Asteroid 9186 Destroyed by collision with Asteroid 1949 at time 0 :: x:5397.529, y:-542.570, z:-7179.026
//  Asteroid 9024 Destroyed by collision with Asteroid 4391 at time 0 :: x:-5134.620, y:1996.863, z:-7116.577
//  Asteroid 8178 Destroyed by collision with Asteroid 5729 at time 0 :: x:1910.309, y:4088.034, z:-7787.383
//  Asteroid 9372 Destroyed by collision with Asteroid 8768 at time 0 :: x:-127.675, y:-6109.755, z:-6608.121
//  Asteroid 9863 Destroyed by collision with Asteroid 9142 at time 0 :: x:-802.747, y:-6361.923, z:-6318.010
//  Asteroid 1354 Destroyed by collision with Asteroid 994 at time 0 :: x:1926.571, y:-6127.132, z:-6305.255
//  Asteroid 5028 Destroyed by collision with Asteroid 787 at time 0 :: x:2464.017, y:-5235.376, z:-6893.891
//  Asteroid 8538 Destroyed by collision with Asteroid 1731 at time 0 :: x:-4158.728, y:-4388.964, z:-6664.371
//  Asteroid 3501 Destroyed by collision with Asteroid 200 at time 0 :: x:5813.332, y:-2831.729, z:-6254.623
//  Asteroid 6806 Destroyed by collision with Asteroid 3722 at time 0 :: x:6125.853, y:-2015.708, z:-6281.354
//  ... Log trimmed, very long ....
// Ship Destroyed by collision with Asteroid 7268 at time 1971 location x:-15.181, y:47.811, z:-38.675
// The Ship will be destroyed in 1971 seconds!

//================================================================================
// Suggestions
//  -Do not try to match the log output exactly!  The last 2 lines of output, given the same inputs, should match however.
//  -Progress from 1 to 2 to 3.  
//  -Make sure the code is working at each step before proceeding
//  -Get as far as you can, but don't panic if you can't finish.  Each task is progressivley more difficult!
//  -Section 3 run-time is very long, use a lower asteroid count until you have it tuned up. 

    
namespace AsteroidAvoid
{
    class Program
    {
        static AsteroidField AsteroidField = null; 
        static Ship Ship = null;
        protected enum ConsoleInputType
        {
            ConsoleArgs,
            InputArgs
        }

        static protected ConsoleInputType inputType;

        static public void Main(string[] args)
        {
            Console.WriteLine("Asteroid Avoid, Lost Boys Programming Test\n");
            Console.WriteLine("Playable Modes: Original - Functionality works exactly as original programmed.\n" +
                "                   Test - Enables test mode which allows you to test specific functions");
            Console.WriteLine("Select Mode: Type ORIGINAL or TEST");
            string selection = Console.ReadLine();
            try
            {
                if (selection.ToLower() == "original")
                    inputType = ConsoleInputType.ConsoleArgs;
                if (selection.ToLower() == "test")
                    inputType = ConsoleInputType.InputArgs;
            }
            catch
            {
                Console.WriteLine("Error: Please select either ORIGINAL or TEST");
            }

            if(inputType == ConsoleInputType.ConsoleArgs)
            {
                foreach(string a in args)
                {
                    Console.WriteLine(a);
                }
            }

            // Extremely naive parse block -- please leave these args as is!  You may add additional args if you wish.
            // No need to "fix" this -- Keeping it simple on purpose.
            // <ScannerRadius> <AsteroidSpawnRadius> <AsteroidCount> <Seed> <MaxAsteroidVelocity> <MinAsteroidRadius> <MaxAsteroidRadius> <ShipRadius>
            float ScannerRadius = 0.0f;
            float AsteroidSpawnRadius = 0.0f;
            int AsteroidCount = 0;
            int Seed = 0;
            float MaxAsteroidVelocity = 0.0f;
            float MinAsteroidRadius = 0.0f;
            float MaxAsteroidRadius = 0.0f;
            float ShipRadius = 0.0f;
            switch (inputType)
            {
                case ConsoleInputType.ConsoleArgs:
                    // Extremely naive parse block -- please leave these args as is!  You may add additional args if you wish.
                    // No need to "fix" this -- Keeping it simple on purpose.
                    // <ScannerRadius> <AsteroidSpawnRadius> <AsteroidCount> <Seed> <MaxAsteroidVelocity> <MinAsteroidRadius> <MaxAsteroidRadius> <ShipRadius>
                    Console.WriteLine("Original Mode");
                    ScannerRadius = float.Parse(args[0]);
                    AsteroidSpawnRadius = float.Parse(args[1]);
                    AsteroidCount = int.Parse(args[2]);
                    Seed = int.Parse(args[3]);
                    MaxAsteroidVelocity = float.Parse(args[4]);
                    MinAsteroidRadius = float.Parse(args[5]);
                    MaxAsteroidRadius = float.Parse(args[6]);
                    ShipRadius = float.Parse(args[7]);
                    break;

                case ConsoleInputType.InputArgs:
                    Console.WriteLine("Test Modde");
                    string[] userInputs = GetInputs();
                    ScannerRadius = float.Parse(userInputs[0]);
                    AsteroidSpawnRadius = float.Parse(userInputs[1]);
                    AsteroidCount = int.Parse(userInputs[2]);
                    Seed = int.Parse(userInputs[3]);
                    MaxAsteroidVelocity = float.Parse(userInputs[4]);
                    MinAsteroidRadius = float.Parse(userInputs[5]);
                    MaxAsteroidRadius = float.Parse(userInputs[6]);
                    ShipRadius = float.Parse(userInputs[7]);
                    break;

            }
            

            // sanity clamping
            AsteroidSpawnRadius = Math.Min(ScannerRadius, AsteroidSpawnRadius);
            MaxAsteroidVelocity = Math.Max(1.0f, MaxAsteroidVelocity);

            // Program run time
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            // Spawn the ship
            Ship = new Ship(Vector3.ZeroVector, ShipRadius);

            // Spawn some asteroids
            AsteroidField = new AsteroidField();
            AsteroidField.Initialize(ScannerRadius, AsteroidSpawnRadius, AsteroidCount, Seed, MaxAsteroidVelocity, MinAsteroidRadius, MaxAsteroidRadius);
            
            // Tick simulation in 1 sec intervals
            
            float dt = 1.0f;
            float time = 0.0f;
            while (true)
            {
                // update positions
                AsteroidField.UpdatePositions(dt);

                // remove asteroids outside the field
                AsteroidField.TrimField(time);

                // detect ship collision
                AsteroidField.CollideWithShip(Ship, time);

                // detect asteroid-asteroid collision
                AsteroidField.CollideWithAsteroids(time);

                //Console.WriteLine("{0} :: Asteroids Remaining: {1}", time, AsteroidField.AsteroidCount);

                // The asteroid field has either vacated all asteroids, or they are all stationary
                if (AsteroidField.FieldStable())
                {
                    Console.WriteLine("The Ship is safe indefinitely!");
                    break;
                }
                // Ship is scrap...
                else if(Ship.Destroyed)
                {
                    Console.WriteLine("The Ship will be destroyed in {0} seconds!", time);
                    break;
                }

               

                time += dt;
            }

            sw.Stop();
            Console.WriteLine("Time ellapsed {0:0.000}s", sw.Elapsed.TotalSeconds);
            
            Console.ReadLine();
        }

        private static string[] GetInputs()
        {
            string[] inputs = new string[8];
            string[] variables = { "Sensor Radius", "Asteroid Spawn Radius", "Asteroid Count", 
                            "Seed", "Max Asteroid Velocity", "Min Asteroid Radius", "Max Asteroid Radius",
                                "Ship Radius"};
            for (int i = 0; i < inputs.Length; i++)
            {
                Console.WriteLine(variables[i]);
                inputs[i] = Console.ReadLine();
            }
            return inputs;
        }
    }
}
