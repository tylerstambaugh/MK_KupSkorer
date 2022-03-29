namespace MK_KupSkorer.Models.PlayerModels
{
    public class PlayerDetail
    {
        public int PlayerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nickname { get; set; }

        public double TotalPoints { get; set; }

        public int TotalBonusPoints { get; set; }
    }
}
