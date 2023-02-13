using System;
namespace PlaylistBuilder.Services
{
	public interface ISecureStorageService
    {
		Task Save(string key, string value);
        Task<bool> Contains(string key);
        Task<string> Get(string key);	
	}
}

