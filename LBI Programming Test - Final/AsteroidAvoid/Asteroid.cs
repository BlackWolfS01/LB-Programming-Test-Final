namespace AsteroidAvoid
{
    public class Asteroid
    {
        public Vector3 Location { get; set; }
        public Vector3 Velocity { get; set; }
        public float Radius { get; set; }
        public int Id { get; set; }

        public bool Destroyed { get; set; } = false;

        public Asteroid(Vector3 location, Vector3 velocity, float radius, int id)
        {
            Location = location;
            Velocity = velocity;
            Radius = radius;
            Id = id;
        }

        public float ProximityRadius() { return this.Radius * 4; }
    }
}
