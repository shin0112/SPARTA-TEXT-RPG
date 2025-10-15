using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG.Scene
{
    internal class ShopScene
    {
        bool isBuy = false;

        public string shopIntroText = @"
[상점]
사는 게 쉽지 않지? 와서 박카스나 한 잔 마시고 해.  ...뭐해 돈 안 내고?

[보유 골드]
{Gold} G

[아이템 목록]
//{List} 삽입

//- 열공 머리띠    | 방어력 +3  | 취준의 결연한 의지를 드러내는 머리띠.    |  700 G
//- 버티컬 마우스  | 방어력 +10  |  손목터널증후군은 안 된다...                |  1500 G
//- 험언 밀러 의자    | 방어력 +20  |   허리 수술 2,000만 원                    |  3000 G

//- 제뜨스트림 볼펜    | 공격력 +5  | 부드러운 볼펜으로 필기감이 뛰어나다.       |  1000 G
//- 기계식 키보드 | 공격력 +15 | 두 손으로 잡고 힘껏 휘두르면 타격감이 좋다    |  2500 G
//- 전임자의 비밀노트   | 공격력 +30  |  대기업으로 이직한 전임자의 메모가..?! |  5000 G


1. 아이템 구매
2. 아이템 판매
0. 나가기

멀뚱멀뚱 서서 뭐 하고 있어? 언넝 골라~
>>
";



    }
}
