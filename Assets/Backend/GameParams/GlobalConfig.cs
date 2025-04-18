namespace Backend.GameParams
{
    public class GlobalConfig
    {
        public float movementSpeed { get; set; }
        public float jumpHeight { get; set; }
        public float gravityScale { get; set; }
        public float maxFallSpeed { get; set; }
        
        public GlobalConfig()
        {
        }

        public GlobalConfig(float movementSpeed, float jumpHeight, float gravityScale, float maxFallSpeed)
        {
            this.movementSpeed = movementSpeed;
            this.jumpHeight = jumpHeight;
            this.gravityScale = gravityScale;
            this.maxFallSpeed = maxFallSpeed;
        }
    }
}