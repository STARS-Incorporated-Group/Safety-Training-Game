namespace Backend.GameParams
{
    public class UserConfig
    {
        public float playerHeight { get; set; }
        public float brightness  { get; set; }
        public float fov { get; set; }
        public float sensitivity { get; set; }
        public float volume { get; set; }

        public UserConfig()
        {
        }

        public UserConfig(float playerHeight, float brightness, float fov, float sensitivity, float volume)
        {
            this.playerHeight = playerHeight;
            this.brightness = brightness;
            this.fov = fov;
            this.sensitivity = sensitivity;
            this.volume = volume;
        }
    }
}