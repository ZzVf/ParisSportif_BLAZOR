using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFootAPI.Model
{
    public enum BetStatus
    {
        Pending = 0,
        Won = 1,
        Lost = 2,
        Canceled = 3
    }

    public enum BetPrediction
    {
        Club1Win = 0,
        Club2Win = 1,
        Draw = 2
    }

    public class Bet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Point { get; set; }

        public DateTime BetTiming { get; set; } = DateTime.Now;

        [Required]
        public BetStatus Status { get; set; } = BetStatus.Pending;

        [Required]
        public BetPrediction Prediction { get; set; }

        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client? Client { get; set; }

        public int MatchId { get; set; }

        [ForeignKey(nameof(MatchId))]
        public Match? Match { get; set; }
    }
}
