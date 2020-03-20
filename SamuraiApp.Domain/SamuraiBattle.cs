namespace SamuraiApp.Domain
{
    /// <summary>
    /// Join Entity Class for Samurais and Battles, because EF Core 3 is not following alone on mapping objects to effectively handle relationships
    /// </summary>
    public class SamuraiBattle
    {
        public int BattleId { get; set; }
        public int SamuraiId { get; set; }
        public Samurai Samurai { get; set; }
        public Battle Battle { get; set; }

    }
}