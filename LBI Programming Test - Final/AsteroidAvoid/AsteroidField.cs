using System;
using System.Collections;
using System.Collections.Generic;

namespace AsteroidAvoid
{
    public class AsteroidField
    {
        List<Asteroid> Asteroids = new List<Asteroid>();
        float AsteroidFieldRadius = 10000.0f;
        int AsteroidId = 1;

        public int AsteroidCount { get { return Asteroids.Count; } }

        public AsteroidField()
        {
        }

        public void Initialize(float fieldRadius, float spawnRadius, int count, int rndSeed, float maxVelocity, float minRadius, float maxRadius)
        {
            AsteroidFieldRadius = fieldRadius;
            Asteroids = new List<Asteroid>();
            AsteroidId = 1;
            Random rnd = new Random(rndSeed);

            for (int i = 0; i < count; ++i)
            {
                float radius = ((float)rnd.NextDouble()) * (maxRadius - minRadius) + minRadius;
                Vector3 location = Vector3.RndNormalVector(ref rnd) * spawnRadius;
                Vector3 velocity = Vector3.RndNormalVector(ref rnd) * (1.0f + (float)rnd.NextDouble() * (maxVelocity - 1.0f));
                SpawnAsteroid(location, velocity, radius, AsteroidId);
                AsteroidId++;
            }
        }

        public Asteroid SpawnAsteroid(Vector3 location, Vector3 velocity, float radius, int id)
        {
            Asteroid ast = new Asteroid(location, velocity, radius, id);
            Asteroids.Add(ast);
            return ast;
        }


        public void UpdatePositions(float dt)
        {
            foreach (var ast in Asteroids)
            {
                ast.Location += ast.Velocity * dt;
            }
        }

        public bool FieldStable()
        {
            bool stable = true;
            foreach (var ast in Asteroids)
            {
                stable = (stable && (ast.Velocity == Vector3.ZeroVector));
            }
            return stable;
        }


        public void TrimField(float time)
        {
            int count = Asteroids.Count;
            for (int testIndex = count - 1; testIndex >= 0; --testIndex)
            {
                Asteroid ast = Asteroids[testIndex];
                if (ast.Location.Length() > AsteroidFieldRadius)
                {
                    Console.WriteLine("Asteroid {0} passed outside of field at Location {1} : {2} at time {3:0.000}", ast.Id, ast.Location.ToString(), ast.Location.Length(), time);
                    Asteroids.RemoveAt(testIndex);
                }
            }
        }

        public void CollideWithShip(Ship ship, float time)
        {
            // Hey this is Programmer1073, what is this asteroid collision stuff?
            // We're on a research vessel, de-prioritizing this task.

            //Couldn't get the Optimization to work properly
            //if (Check_AsteroidsWithinRange_Ship(ship) == false)
            //return;

            if (Check_AsteroidsWithinRange_Ship(ship) == false)
                Console.WriteLine("Ship Check False");
            else Console.WriteLine("Ship Check True");

            foreach (Asteroid ast in Asteroids)
            {
                // Programmer1073:: if close enough to asteroid, bad things happen, at least log it.
                if (ast.Location.Dist(ship.Location) <= ship.Radius)
                {
                    Console.WriteLine("Ship Destroyed by collision with Asteroid {0} at time {1} location {2}", ast.Id, time, ast.Location.ToString());
                    ship.Destroyed = true;
                    break;
                }
            }   
        }

        /*
        public void CollideWithShip(Ship ship, Time time) {

             List<Asteroid> ClosestAsteroids = AsteroidsInProximityOfShip(ship);

            if (ClosestAsteroids.Count == 0)
                return;

            foreach (Asteroid ast in ClosestAsteroids)
             {
                // Programmer1073:: if close enough to asteroid, bad things happen, at least log it.
                if (ship.Location.Length() <= ship.Radius)
                {
                    Console.WriteLine("Ship Destroyed by collision with Asteroid {0} at time {1} location {2}", ast.Id, time, ast.Location.ToString());
                    ship.Destroyed = true;
                    break;
                }
            }
            ClosestAsteroids.Clear();
        }

        */

        public void CollideWithAsteroids(float time)
        {
            // Programmer1073:Seriously -- Asteroid-Asteroid collision -- this is way to complicated
            // de-prioritizing this task
            if (Check_AseroidsWithinRange_Asteroids() == false)
                return;
           
            
            for (int outer = 0; outer < Asteroids.Count; ++outer)
            {
                for (int inner = Asteroids.Count - 1; inner >= 0; --inner)
                {
                    // if something or the other, asteroids hit each other
                    if (Asteroids[outer].Location.Dist(Asteroids[inner].Location) <= Asteroids[inner].Radius)
                    {
                        Console.WriteLine("  Asteroid {0} Destroyed by collision with Asteroid {1} at time {2} :: {3}", Asteroids[inner].Id, Asteroids[outer].Id, time, Asteroids[outer].Location.ToString());
                        Asteroids[outer].Destroyed = true;
                        Asteroids[inner].Destroyed = true;
                    }
                }
            }

            for (int delIndex = Asteroids.Count - 1; delIndex >= 0; --delIndex)
            {
                if (Asteroids[delIndex].Destroyed)
                {
                    Asteroids.RemoveAt(delIndex);
                }
            }
        }

        /*
         public void CollideWithAsteroids(float time)
        {
            // Programmer1073:Seriously -- Asteroid-Asteroid collision -- this is way to complicated
            // de-prioritizing this task


            
            List<AsteroidNode> ClosestAsteroids = AsteroidsInProximityOfOthers();
            if(ClosestAsteroids.Count == 0)
                return;
           
            foreach(AsteroidNode an in ClosestAsteroids)
            {
                for(int i = an.secondary.Count - 1; i >= 0; i--)
                {
                    // if something or the other, asteroids hit each other
                    if (an.secondary[i].Location.Length() <= an.primary.Radius)
                    {
                        Console.WriteLine("  Asteroid {0} Destroyed by collision with Asteroid {1} at time {2} :: {3}", an.primary.Id, an.secondary[i].Id, time, an.secondary[i].Location.ToString());
                        ClearAsteroid(an.primary.Id);
                        ClearAsteroid(an.secondary[i].Id);
                    }
                }
            }

            ClosestAsteroids.Clear();
            
          
             Original Code Section       
            
            for (int outer = 0; outer<Asteroids.Count; ++outer)
            {
                for (int inner = 0; inner<Asteroids.Count; ++inner)
                {

                    // if something or the other, asteroids hit each other
                    if (Asteroids[outer].Location.Length() <= Asteroids[inner].Radius)
                    {
                        Console.WriteLine("  Asteroid {0} Destroyed by collision with Asteroid {1} at time {2} :: {3}", Asteroids[inner].Id, Asteroids[outer].Id, time, Asteroids[outer].Location.ToString());

                        Asteroids[outer].Destroyed = true;
                        Asteroids[inner].Destroyed = true;
                    }
}
            }

            for (int delIndex = Asteroids.Count - 1; delIndex >= 0; --delIndex)
            {
                if (Asteroids[delIndex].Destroyed)
                {
                    Asteroids.RemoveAt(delIndex);
                }
            }
        }

        */
        /*    UTILITY METHODS   */
        public void ClearAsteroid(int id)
        {
            Console.WriteLine("Asteroid " + Asteroids[id].Id + "Destroyed");
            Asteroids[id].Destroyed = true;
            Asteroids.RemoveAt(id);
        }

        private bool Check_AsteroidsWithinRange_Ship(Ship ship)
        {
            Asteroid[] _Asteroids = Asteroids.ToArray();
            int i = 0, r = _Asteroids.Length - 1;
            while (i <= r)
            {
                int m = 1 + (r - 1) / 2;
                try
                {

                    if (_Asteroids[m].Location.Dist(ship.Location)
                        <= ship.ProximityRadius())
                    {
                        return true;
                    }

                    if (_Asteroids[m].Location.Dist(ship.Location)
                        > ship.ProximityRadius())
                    {
                        i = m + 1;
                        r = m - 1;
                    }
                }
                catch
                {
                    break;
                }
            }
            return false;
        }

        private bool Check_AseroidsWithinRange_Asteroids()
        {
            Asteroid[] _Asteroids = Asteroids.ToArray();
            int i = 0, r = _Asteroids.Length - 1;
            while(i <= r)
            {
                int m = 1 + (r - 1) / 2;
                try
                {

                    if (_Asteroids[m].Location.Dist(_Asteroids[r].Location)
                        < _Asteroids[m].ProximityRadius())
                    {
                        return true;
                    }

                    if (_Asteroids[m].Location.Dist(_Asteroids[r].Location)
                        > _Asteroids[m].ProximityRadius())
                    {
                        i = m + 1;
                        r = m - 1;
                    }
                }
                catch {
                    break;
                }
            }
            return false;
        }

        private List<Asteroid> AsteroidsInProximityOfShip(Ship ship)
        {
            List<Asteroid> ClosestAsteroids = new List<Asteroid>();
            foreach (Asteroid ast in Asteroids)
            {
                if (MinkovskiDist(ship.Location.getVectorAsArray(), ast.Location.getVectorAsArray(), 2)
                            <= ship.ProximityRadius())
                {
                    Console.WriteLine("Asteroid: " + ast.Id);
                    ClosestAsteroids.Add(ast);
                }
                if(MinkovskiDist(ship.Location.getVectorAsArray(), ast.Location.getVectorAsArray(), 2)
                    > ship.ProximityRadius())
                {
                    ClosestAsteroids.Remove(ast);
                }
            }
            return ClosestAsteroids;
        }

        protected Asteroid GetAsteroidWithID(int id)
        {
            foreach(Asteroid asteroid in Asteroids)
            {
                if(asteroid.Id == id)
                {
                    return asteroid;
                }
            }
            return null;
        }

        public List<AsteroidNode> AsteroidsInProximityOfOthers()
        {
            List<AsteroidNode> ClosestAsteroids = new List<AsteroidNode>();
            for(int i = 0; i < Asteroids.Count; i++)
            {
                for(int j = Asteroids.Count - 1; j >= 0; j--)
                {
                    if(MinkovskiDist(Asteroids[i].Location.getVectorAsArray(), Asteroids[j].Location.getVectorAsArray(), 2)
                        < Asteroids[i].ProximityRadius())
                    {
                        AsteroidNode TempNode = new AsteroidNode(Asteroids[i]);
                        TempNode.AddAsteroid(Asteroids[j]);
                        ClosestAsteroids.Add(TempNode);
                    }
                }      
            }
          
            /*
            foreach(AsteroidNode an in ClosestAsteroids)
            {
                if (an.primary.Destroyed)
                {
                    ClosestAsteroids.Remove(an);
                }
                else
                {
                    for(int i = Asteroids.Count - 1; i >= 0; i--)
                    {
                        if(MinkovskiDist(an.primary.Location.getVectorAsArray(),
                            Asteroids[i].Location.getVectorAsArray(), 2) < an.primary.ProximityRadius())
                        {
                            an.AddAsteroid(Asteroids[i]);
                        }

                        if (MinkovskiDist(an.primary.Location.getVectorAsArray(),
                            Asteroids[i].Location.getVectorAsArray(), 2) > an.primary.ProximityRadius())
                        {
                            an.RemoveAsteroid(Asteroids[i]);
                        }
                    }
                }
            }*/
            return ClosestAsteroids;
        }

        private float MinkovskiDist(float[] v1, float[] v2, float p)
        {
            float distance = 0.0f;
            for(int i = 0; i < v1.Length; i++)
            {
                distance += (float)Math.Round(Math.Abs(v1[i] - v2[i] * p));
            }
            return (float) Math.Round(distance * (1.0 / p));
        }

        public class AsteroidNode
        {
            public Asteroid primary;
            public List<Asteroid> secondary = new List<Asteroid>();

            public AsteroidNode(Asteroid p) {
                this.primary = p;
            }

            public void AddAsteroid(Asteroid s) {
                this.secondary.Add(s);
            }

            public void RemoveAsteroid(Asteroid s) {
                this.secondary.Remove(s);
            }
        }
    }
}