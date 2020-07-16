namespace AsteroidAvoid
{
    public class Ship
    {
        public Vector3 Location { get; set; }
        public Vector3 Velocity { get; set; }
        public float Radius { get; set; }

        public bool Destroyed { get; set; } = false;

        public Ship(Vector3 location, float radius)
        {
            Location = location;
            Radius = radius;
            Velocity = Vector3.ZeroVector;
            Destroyed = false;
        }

        public float ProximityRadius() { return this.Radius * 3;  }
    }
}
