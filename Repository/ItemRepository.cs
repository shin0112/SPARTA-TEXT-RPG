using TEXT_RPG.Core;

namespace TEXT_RPG.Repository
{
    internal class ItemRepository
    {
        public static List<Item> MonsterItem = [
            // 제뜨스트림 볼펜    | 공격력 +5  | 부드러운 볼펜으로 필기감이 뛰어나다.       |  800 G
            new Item("제뜨스트림 볼펜", 5, ItemType.Weapon, "부드러운 볼펜으로 필기감이 뛰어나다.", 800),
        ];
    }
}
