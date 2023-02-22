using System;
namespace PlaylistBuilder.ViewModels
{
	public abstract partial class ViewModel : TinyViewModel
	{
		public ViewModel()
		{
		}

		protected virtual Task HandleException(Exception ex)
		{
			if(ex is UnauthorizedAccessException)
			{
				Navigation.NavigateTo("//Login");
			}

			Console.Write(ex);

			return Task.CompletedTask;
		}
	}
}

