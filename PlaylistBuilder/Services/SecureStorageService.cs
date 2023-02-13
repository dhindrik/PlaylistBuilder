using System;

namespace PlaylistBuilder.Services
{
	public class SecureStorageService : ISecureStorageService
	{
        public async Task Save(string key, string value)
        {
            await SecureStorage.Default.SetAsync(key, value);
        }

        public async Task<bool> Contains(string key)
        {
            var savedValue = await SecureStorage.Default.GetAsync(key);

            if (savedValue == null)
            {
                return false;
            }

            return true;
        }

        public async Task<string> Get(string key)
        {
            var savedValue = await SecureStorage.Default.GetAsync(key);

            if(savedValue == null)
            {
                throw new KeyNotFoundException();
            }

            return savedValue;

        }
    }
}

