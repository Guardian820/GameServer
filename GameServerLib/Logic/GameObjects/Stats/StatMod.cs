namespace LeagueSandbox.GameServer.Logic.GameObjects.Stats
{
    public class StatMod
    {
        public virtual float BaseBonus { get; set; }
        public virtual float PercentBaseBonus { get; set; }

        public virtual float FlatBonus { get; set; }
        public virtual float PercentBonus { get; set; }
    }
}
