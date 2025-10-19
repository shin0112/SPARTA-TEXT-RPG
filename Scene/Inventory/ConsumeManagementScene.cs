using TEXT_RPG.Core;
using TEXT_RPG.Manager;

namespace TEXT_RPG.Scene.Inventory
{
    internal class ConsumeManagementScene
    {
        public void ConsumeManagement()
        {
            Console.Clear();
            UIHelper.ColorWriteLine("인벤토리 - 소모품 관리", "Yellow");
            Console.WriteLine("소모품을 사용하세요.\n");
            Console.WriteLine("[아이템 목록]\n");
        }
    }
}
