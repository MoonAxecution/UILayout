using System;
using Game.Project.Services.Interfaces;

namespace Game.Project.Services
{
    public class UserService : IUserService
    {
        public int Currency { get; private set; }
        
        public UserService()
        {
            Currency = 1000;
        }

        void IUserService.AddCurrency(int delta)
        {
            Currency += delta;
        }

        void IUserService.ReduceCurrency(int delta)
        {
            if (!HasCurrency(delta))
                throw new Exception("Currency is not enough");
            
            Currency -= delta;
        }
        
        bool IUserService.HasCurrency(int amount)
        {
            return HasCurrency(amount);
        }

        private bool HasCurrency(int amount)
        {
            return Currency >= amount;
        }
    }
}