using TEXT_RPG.Core;

namespace TEXT_RPG.Repository
{
    internal class MonsterRepository
    {
        public List<Monster> MonstersNo1 { get; } = [
            new Monster("이력서 괴물", 1, new Stats(5, 1, 5), new Reward(1, 10, new List<int>{ })),
            new Monster("자소서 슬라임", 2, new Stats(7, 2, 10), new Reward(2, 20, new List<int>{ })),
            new Monster("취업난 드래곤", 3, new Stats(9, 3, 10), new Reward(3, 30, new List<int>{ })),
        ];

        public List<Monster> SpecialMonstersNo1 { get; } = [
            new Monster("김영호 튜터", 5, new Stats(5, 5, 20), new Reward(5, 50, new List<int>{1})),
            new Monster("신찬용 튜터", 5, new Stats(5, 5, 20), new Reward(5, 50, new List<int>{1})),
            new Monster("이재현 튜터", 5, new Stats(5, 5, 20), new Reward(5, 50, new List<int>{1})),
            new Monster("진우원 튜터", 5, new Stats(5, 5, 20), new Reward(5, 50, new List<int>{1})),
            new Monster("하승우 튜터", 5, new Stats(5, 5, 20), new Reward(5, 50, new List<int>{1})),
            new Monster("나영웅 매니저", 5, new Stats(5, 5, 20), new Reward(5, 50, new List<int>{8})),
            new Monster("류은지 매니저", 5, new Stats(5, 5, 20), new Reward(5, 50, new List<int>{8})),
            new Monster("진수인 매니저", 5, new Stats(5, 5, 20), new Reward(5, 50, new List<int>{8})),
        ];

        public List<Monster> MonstersNo2 { get; } = [
            new Monster("머리 까진 면접관", 4, new Stats(4, 4, 20), new Reward(4, 40, new List<int>{ })),
            new Monster("내가 말하는데 조는 면접관", 5, new Stats(5, 5, 25), new Reward(5, 50, new List<int>{ })),
            new Monster("막말하는 면접관", 6, new Stats(6, 6, 30), new Reward(6, 60, new List<int>{ })),
            ];

        public Dictionary<int, List<List<Monster>>> DungeonMonsters { get; }

        public List<Monster> SpecialMonstersNo2 { get; } = [];

        public MonsterRepository()
        {
            DungeonMonsters = new Dictionary<int, List<List<Monster>>>
            {
                { 1, new() { MonstersNo1, SpecialMonstersNo1 } },
                { 2, new() { MonstersNo2, SpecialMonstersNo2 } }
            };
        }
    }
}
