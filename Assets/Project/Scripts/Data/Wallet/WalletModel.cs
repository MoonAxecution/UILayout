namespace Game.Project.Data
{
    public class WalletModel<TWalletData> where TWalletData : WalletData
    {
        private readonly TWalletData _walletData;

        public WalletModel(TWalletData data)
        {
            _walletData = data;
        }
    }
}