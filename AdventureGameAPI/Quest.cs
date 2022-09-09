using System.ComponentModel.DataAnnotations;

namespace AdventureGameAPI
{
    public class Quest
    {
        [Key]
        public int Id { get; set; }
        public string QuestName { get; set; }
        public string QuestDesc { get; set; }
        public string QuestReward { get; set; }
        public int QuestExp { get; set; }
        public bool CompletionStatus { get; set; }

    }
}
