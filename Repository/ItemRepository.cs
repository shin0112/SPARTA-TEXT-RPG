using TEXT_RPG.Core;

namespace TEXT_RPG.Repository
{
    internal class ItemRepository
    {
        public static List<Item> InventoryItem = [
            //기본장착 아이템
            new Item("게이밍 슈트", 1, ItemType.Armor, "게임에 특화된 반팔 티셔츠. 목부분이 살짝 늘어나있다.", 200),
            new Item("수학의 정석", 2, ItemType.Weapon, "먼지가 켜켜이 쌓여 있다. 중고로 팔아도 쏠쏠할 듯.", 500),
    ];

        public static List<Item> ShopItem = [
            //공격 아이템
            new Item("제뜨스트림 볼펜", 5, ItemType.Weapon, "부드러운 볼펜으로 필기감이 뛰어나다.", 800),
            new Item("C# 참고서", 10, ItemType.Weapon, "알 것 같다! 모르겠다... 알 것 같다!!! 모르겠다...", 1500),
            new Item("기계식 키보드", 20, ItemType.Weapon, "두 손으로 잡고 힘껏 휘두르면 타격감이 좋다.", 2800),
            new Item("챗지삐띠", 30, ItemType.Weapon, "AI와 함께라면 두렵지 않아! 다만 경력자에게 이걸로 까불다간 박살난다...", 4000),
            new Item("맥북", 50, ItemType.Weapon, "일단 들고만 다녀도 뭔가 있어 보인다.", 6000),
            new Item("5090 그래픽카드", 70, ItemType.Weapon, "꿈의 그래픽카드. 이것만 있으면 뭐든 할 수 있다..!", 8000),
            new Item("전임자의 비밀노트", 100, ItemType.Weapon, "대기업으로 이직한 전임자의 메모가..?!", 10000),
            //방어 아이템
            new Item("열공 머리띠", 5, ItemType.Armor, "취준의 결연한 의지를 드러내는 머리띠.", 700),
            new Item("버티컬 마우스", 10, ItemType.Armor, "손목터널증후군은 안 된다...", 1500),
            new Item("정장 세트", 20, ItemType.Armor, "입고 있으면 사회의 일원이 된 것 같다.", 3000),
            new Item("공기팟", 30, ItemType.Armor, "상사의 잔소리를 노이즈캔슬링!", 5000),
            new Item("험언 밀러 의자", 50, ItemType.Armor, "허리 수술 2,000만 원", 7000),
            //체력 회복 아이템
            new Item("천하장사 소시지", 10, ItemType.HP, "빨간 줄을 뜯으면 뽀얀 속살이 드러난다.", 50),
            new Item("간나 초콜릿", 20, ItemType.HP, "달달한 향이 은은하게 퍼지는 초콜릿.", 100),
            new Item("삼각김밥 컵라면 세트", 40, ItemType.HP, "속이 든든한 편의점 국룰 조합.", 200),
            new Item("혜자 도시락", 70, ItemType.HP, "9첩반상의 혜자로움이 담긴 도시락.", 350),
            new Item("후라이드 치킨", 100, ItemType.HP, "치느님은 언제나 옳다.", 500),
            //스태미너 회복 아이템
            new Item("빠워에이드", 10, ItemType.Stamina, "마시면 힘이 날 것 같은 음료수이다.", 30),
            new Item("비타700", 20, ItemType.Stamina, "이봐 친구, 그거 알아? 비타700에는 자그마치 700mg의 비타민C가 들어있다는 놀라운 사실을!", 50),
            new Item("아이스 아메리카노", 30, ItemType.Stamina, "현대인의 필수품", 80),
            new Item("바카스", 40, ItemType.Stamina, "기운이 없다면 이걸로 리필하자. 단, 과다 복용은 새벽 3시까지 잠 못 듦.", 120),
            new Item("핫세븐", 70, ItemType.Stamina, "오늘은 이거 마시고 죽는 거다..!", 200),
            new Item("쌍화탕", 100, ItemType.Stamina, "기침, 감기, 인생의 쓴맛까지 치료해주는 만능 한방 드링크.", 300)
            ];

        public static List<Item> MonsterItem = [
            // 제뜨스트림 볼펜    | 공격력 +5  | 부드러운 볼펜으로 필기감이 뛰어나다.       |  800 G
            new Item("제뜨스트림 볼펜", 5, ItemType.Weapon, "부드러운 볼펜으로 필기감이 뛰어나다.", 800),
            new Item("C# 참고서", 10, ItemType.Weapon, "알 것 같다! 모르겠다... 알 것 같다!!! 모르겠다...", 1500),
            new Item("기계식 키보드", 20, ItemType.Weapon, "두 손으로 잡고 힘껏 휘두르면 타격감이 좋다.", 2800),
            new Item("챗지삐띠", 30, ItemType.Weapon, "AI와 함께라면 두렵지 않아! 다만 경력자에게 이걸로 까불다간 박살난다...", 4000),
            new Item("맥북", 50, ItemType.Weapon, "일단 들고만 다녀도 뭔가 있어 보인다.", 6000),
            new Item("5090 그래픽카드", 70, ItemType.Weapon, "꿈의 그래픽카드. 이것만 있으면 뭐든 할 수 있다..!", 8000),
            new Item("전임자의 비밀노트", 100, ItemType.Weapon, "대기업으로 이직한 전임자의 메모가..?!", 10000),
            //방어 아이템
            new Item("열공 머리띠", 5, ItemType.Armor, "취준의 결연한 의지를 드러내는 머리띠.", 700),
            new Item("버티컬 마우스", 10, ItemType.Armor, "손목터널증후군은 안 된다...", 1500),
            new Item("정장 세트", 20, ItemType.Armor, "입고 있으면 사회의 일원이 된 것 같다.", 3000),
            new Item("공기팟", 30, ItemType.Armor, "상사의 잔소리를 노이즈캔슬링!", 5000),
            new Item("험언 밀러 의자", 50, ItemType.Armor, "허리 수술 2,000만 원", 7000),
            //체력 회복 아이템
            new Item("천하장사 소시지", 10, ItemType.HP, "빨간 줄을 뜯으면 뽀얀 속살이 드러난다.", 50),
            new Item("간나 초콜릿", 20, ItemType.HP, "달달한 향이 은은하게 퍼지는 초콜릿.", 100),
            new Item("삼각김밥 컵라면 세트", 40, ItemType.HP, "속이 든든한 편의점 국룰 조합.", 200),
            new Item("혜자 도시락", 70, ItemType.HP, "9첩반상의 혜자로움이 담긴 도시락.", 350),
            new Item("후라이드 치킨", 100, ItemType.HP, "치느님은 언제나 옳다.", 500),
            //스태미너 회복 아이템
            new Item("빠워에이드", 10, ItemType.Stamina, "마시면 힘이 날 것 같은 음료수이다.", 30),
            new Item("비타700", 20, ItemType.Stamina, "이봐 친구, 그거 알아? 비타700에는 자그마치 700mg의 비타민C가 들어있다는 놀라운 사실을!", 50),
            new Item("아이스 아메리카노", 30, ItemType.Stamina, "현대인의 필수품", 80),
            new Item("바카스", 40, ItemType.Stamina, "기운이 없다면 이걸로 리필하자. 단, 과다 복용은 새벽 3시까지 잠 못 듦.", 120),
            new Item("핫세븐", 70, ItemType.Stamina, "오늘은 이거 마시고 죽는 거다..!", 200),
            new Item("쌍화탕", 100, ItemType.Stamina, "기침, 감기, 인생의 쓴맛까지 치료해주는 만능 한방 드링크.", 300)
];
    }
}
