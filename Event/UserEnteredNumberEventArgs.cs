namespace Event
{
    public class UserEnteredNumberEventArgs
    {
        public int Input { get; set; }
        public DateTime EnteredAt { get; set; }

        public UserEnteredNumberEventArgs(int input, DateTime enteredAt)
        {
            Input = input;
            EnteredAt = enteredAt;
        }
    }
}
