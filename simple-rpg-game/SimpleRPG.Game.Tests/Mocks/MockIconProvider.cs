using Blazorise;

namespace SimpleRPG.Game.Tests.Mocks
{
    public class MockIconProvider : IIconProvider
    {
        public bool IconNameAsContent => false;

        public string GetIconName(IconName name)
        {
            return string.Empty;
        }

        public string GetIconName(string customName)
        {
            return string.Empty;
        }

        public string Icon(object name, IconStyle iconStyle)
        {
            return string.Empty;
        }

        public void SetIconName(IconName name, string newName)
        {
        }
    }
}