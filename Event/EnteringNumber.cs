namespace Event
{
    public class EnteringNumber
    {
        public event EventHandler<UserEnteredNumberEventArgs>? TakeNumber;

        public void ShowEnteredNumber(UserEnteredNumberEventArgs numberAndTime)
        {
            TakeNumber?.Invoke(this, numberAndTime);
        }
    }
}
