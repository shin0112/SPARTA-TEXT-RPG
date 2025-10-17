using TEXT_RPG.Core;

namespace TEXT_RPG.Repository
{
    internal class MonsterRepository
    {
        public List<Monster> MonstersNo1 => [
            new Monster("Unity 훑어보기", 1, new Stats(5, 5, 5)),
            new Monster("C# 기본", 2, new Stats(7, 7, 10)),
            new Monster("C# 심화", 3, new Stats(9, 9, 10)),
        ];

        public List<Monster> SpecialMonsterNo1 => [
            new Monster("김영호 튜터", 5, new Stats(5, 5, 20)),
            new Monster("신찬용 튜터", 5, new Stats(5, 5, 20)),
            new Monster("이재현 튜터", 5, new Stats(5, 5, 20)),
            new Monster("진우원 튜터", 5, new Stats(5, 5, 20)),
            new Monster("하승우 튜터", 5, new Stats(5, 5, 20)),
            new Monster("나영웅 매니저", 5, new Stats(5, 5, 20)),
            new Monster("류은지 매니저", 5, new Stats(5, 5, 20)),
            new Monster("진수인 매니저", 5, new Stats(5, 5, 20)),
        ];

        public List<Monster> MonstersNo2 => [
            new Monster("머리 까진 면접관", 4, new Stats(4, 4, 20)),
            new Monster("내가 말하는데 조는 면접관", 5, new Stats(5, 5, 25)),
            new Monster("막말하는 면접관", 6, new Stats(6, 6, 30)),
        ];
    }
}
