using System.Linq;
using AutoMapper;
using RiotApiClient.Models;
using WardStatsTracker.Core.Models;

namespace WardStatsTracker.Infrastructure.MapperProfiles
{
    public class MatchDetailsProfile : Profile
    {
        public MatchDetailsProfile()
        {
            CreateMap<Player, ParticipantIdentityModel>();
            CreateMap<ParticipantStats, ParticipantStatsModel>()
                .ForMember(model => model.KeystonePerk, options =>
                    options.MapFrom(participant => participant.Perk0));
            CreateMap<HelperParticipant, GameParticipantModel>();
            CreateMap<MatchDetails, MatchDetailsModel>()
                .ForMember(model => model.Participants, options =>
                    options.MapFrom(src =>
                        src.Participants.Join(src.ParticipantIdentities,
                            participant => participant.ParticipantId,
                            identity => identity.ParticipantId,
                            (participant, identity) => new HelperParticipant(participant, identity)
                            ).ToList()));
        }

        // class to contain participant information and participant identity combined, used during mapping
        private class HelperParticipant
        {
            public HelperParticipant(GameParticipant participant, ParticipantIdentity identity)
            {
                ParticipantId = participant.ParticipantId;
                ChampionId = participant.ChampionId;
                Spell1Id = participant.Spell1Id;
                Spell2Id = participant.Spell2Id;
                Stats = participant.Stats;
                Identity = identity.Player;
            }
            
            public int ParticipantId { get; set; }
            public int ChampionId { get; set; }
            public int Spell1Id { get; set; }
            public int Spell2Id { get; set; }
            public ParticipantStats Stats { get; set; }
            public Player Identity { get; set; }
        }
    }
}