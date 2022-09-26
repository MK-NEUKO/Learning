namespace ExaptionHandling
{
    public class ExceptionHandler : IExceptionThrower
    {
        public void IThrowAnException()
        {
			Console.WriteLine("Hallo");
        }

		private void ShowError(Exception exception)
		{
			Console.WriteLine(exception.Message); ;
		}
	}
}
